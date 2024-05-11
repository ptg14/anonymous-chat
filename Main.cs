using anonymous_chat.Chat;
using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_Server.DataBase;
using System.Diagnostics;

namespace anonymous_chat
{
    public partial class Main : Form
    {
        private static FirestoreDb db = FireBase.dataBase;
        public int UID;
        public int toUID;
        public string userName;
        private bool addFriendVisible = false;
        public Dictionary<int, ChatBox> chatBoxes = new Dictionary<int, ChatBox>();
        ChatBox AI = new ChatBox(new MessageData());

        public Main()
        {
            InitializeComponent();

            if (SignIn_SignUp.ShowAndTryGetInput(out UID, out userName, this))
            {
                LB_name.Text = userName;
                chatBox.chatbox_info.User = userName;
                LB_UID.Text = "UID: " + UID.ToString();
                isOnline();
                LoadFriendList();
                Thread connectThread = new Thread(ConnectToServer);
                connectThread.IsBackground = true;
                connectThread.Start();
                chatBox.main = this;
            }
            else
            {
                // The user has not signed in
                Load += (s, e) => Close();
            }
        }

        private TcpClient client;
        private NetworkStream stream;
        public bool isConnected;

        private void ConnectToServer()
        {
            // Try to connect to the server until successful
            while (true)
            {
                try
                {
                    client = new TcpClient("192.168.1.6", 8888);
                    break; // Connection successful, exit the loop
                }
                catch (SocketException)
                {
                    // Connection failed, wait and then try again
                    Thread.Sleep(1000);
                }
            }
            isConnected = true;

            stream = client.GetStream(); // Get the stream for sending and receiving data

            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        public void Send(string text)
        {
            if (isConnected)
            {
                byte[] message = Encoding.ASCII.GetBytes(text);
                stream.Write(message, 0, message.Length); // Send the message to the server
            }
        }

        private void ReceiveMessages()
        {
            while (isConnected)
            {
                byte[] data = new byte[256];
                int bytes = 0;
                try
                {
                    bytes = stream.Read(data, 0, data.Length);
                }
                catch (IOException ex)
                {
                    // Handle the exception here
                    Send("An error occurred: " + ex.Message);
                    break;
                }

                string receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
                MessageBox.Show(receivedMessage);

                string[] parts = receivedMessage.Split(new string[] { "=>" }, StringSplitOptions.None);
                int senderUID = int.Parse(parts[0]);

                // Extract the toUID from the string before the JSON object starts
                int toUIDIndex = parts[1].IndexOf(':');
                string recipientUIDString = (toUIDIndex > 0) ? parts[1].Substring(0, toUIDIndex) : parts[1];
                int recipientUID = int.Parse(recipientUIDString);

                // If the toUID was extracted from the string, the chatDataJson should start from the JSON object
                string chatDataJson = (toUIDIndex > 0) ? parts[1].Substring(toUIDIndex) : parts[2];

                // Deserialize the chat data json to a dictionary to access the Type property
                var chatDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(chatDataJson);

                // Get the type of the chat data
                string chatDataType = chatDataDictionary["Type"].ToString();

                IChatModel chatData;

                // Deserialize the chat data json to the appropriate model based on the type
                switch (chatDataType)
                {
                    case "text":
                        chatData = TextChatModel.ReadText(chatDataJson);
                        break;
                    case "image":
                        chatData = ImageChatModel.ReadImage(chatDataJson);
                        break;
                    case "attachment":
                        chatData = AttachmentChatModel.ReadAttachment(chatDataJson);
                        break;
                    default:
                        throw new Exception("Unknown chat data type: " + chatDataType);
                }
                chatData.Inbound = true;

                // Check if the message is sent to you
                if (recipientUID == UID)
                {
                    // Update TB_remessage on the UI thread
                    if (this.IsHandleCreated) // Check if the handle has been created
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (chatBoxes.ContainsKey(senderUID))
                            {
                                chatBoxes[senderUID].AddMessage(chatData);
                            }
                        });
                    }
                }
            }
        }

        private async void isOnline()  // Create a new async method
        {
            // Get the user's public IP address
            string ip = await GetPublicIPAddressAsync();

            // Create a new Online object
            Online online = new Online
            {
                UID = UID,
                IP = ip,
                Searching = false
            };

            // Add the Online object to the Online collection in the Firestore database
            await db.Collection("Online").Document(UID.ToString()).SetAsync(online);
        }

        private void LBox_listFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBox_listFriends.SelectedIndex != -1)
            {
                // An item is selected
                string selectedFriend = LBox_listFriends.SelectedItem.ToString();
                if (selectedFriend == "AI")
                {
                    // Show the AI ChatBox
                    foreach (var otherChatBox in chatBoxes.Values)
                    {
                        otherChatBox.Visible = false;
                    }
                    AI.BringToFront();
                    toUID = 10000;
                    return;
                }
                toUID = int.Parse(selectedFriend);

                // Check if a ChatBox already exists for this friend
                if (chatBoxes.ContainsKey(toUID))
                {
                    chatBox.Visible = false;
                    // Show the existing ChatBox and hide the others
                    foreach (var otherChatBox in chatBoxes.Values)
                    {
                        otherChatBox.Visible = otherChatBox == chatBoxes[toUID];
                    }
                    chatBoxes[toUID].BringToFront();
                }
                else
                {
                    // Create a new ChatBox for this friend
                    ChatBox newChatBox = new ChatBox(new MessageData());
                    newChatBox.main = this;
                    chatBoxes.Add(toUID, newChatBox);

                    mainChat.Controls.Add(newChatBox);

                    newChatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    newChatBox.BackColor = SystemColors.Window;
                    newChatBox.Location = chatBox.Location;
                    newChatBox.Margin = new Padding(3, 4, 3, 4);
                    newChatBox.Name = $"newChatBox{toUID}";
                    newChatBox.Size = chatBox.Size;

                    // Hide the other newChatBoxes
                    chatBox.Visible = false;
                    foreach (var otherChatBox in chatBoxes.Values)
                    {
                        otherChatBox.Visible = otherChatBox == newChatBox;
                    }
                    newChatBox.BringToFront();
                }
            }
        }


        public async Task<string> GetPublicIPAddressAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("https://api.ipify.org");
            }
        }

        private void BT_search_Click(object sender, EventArgs e)
        {
            if (addFriendVisible)
            {
                addFriendVisible = false;
                addFriend.Visible = false;
            }
            else
            {
                addFriendVisible = true;
                addFriend.Visible = true;
            }
        }

        private async void LoadFriendList()
        {
            // Query the database for the user's friend list
            Query query = db.Collection("Friends").WhereEqualTo("UID", UID).WhereEqualTo("isFriend", true);

            var querySnapshot = await query.GetSnapshotAsync();
            //MessageBox.Show($"Number of documents returned by the query: {querySnapshot.Count}");

            this.Invoke((MethodInvoker)delegate
            {
                // Clear the friend list
                LBox_listFriends.Items.Clear();

                // Add each friend to the friend list
                foreach (DocumentSnapshot document in querySnapshot.Documents)
                {
                    try
                    {
                        Friends friend = document.ConvertTo<Friends>();
                        //MessageBox.Show($"FriendUID: {friend.FriendUID}");
                        LBox_listFriends.Items.Add(friend.FriendUID);
                        //MessageBox.Show($"Added {friend.FriendUID} to the ListBox");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            });
        }

        private async void BT_findFriend_Click(object sender, EventArgs e)
        {
            if (TB_friendUID.Text == "")
            {
                TB_findResult.Text = "Nhập UID của bạn bè";
                return;
            }
            if (TB_friendUID.Text == UID.ToString())
            {
                TB_findResult.Text = "Đây là UID của bạn";
                return;
            }

            // Query the database for the UID
            DocumentSnapshot snapshot = await db.Collection("Users").Document(TB_friendUID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                TB_findResult.Text = "UID không tồn tại";
                return;
            }

            // The UID exists in the database
            // Get the user data
            UserData user = snapshot.ConvertTo<UserData>();

            // Display the user's name
            TB_findResult.Text = user.UserName;
        }

        private void BT_addFriend_Click(object sender, EventArgs e)
        {
            if (TB_friendUID.Text == "")
            {
                TB_findResult.Text = "Nhập UID của bạn bè";
                return;
            }
            else if (TB_friendUID.Text == UID.ToString())
            {
                TB_findResult.Text = "Đây là UID của bạn";
                return;
            }
            // send to server
            string friendRequestMessage = $"FRIENDREQUEST: {UID}=>{TB_friendUID.Text}";
        }

        private void BT_refresh_Click(object sender, EventArgs e)
        {
            LoadFriendList();
            foreach (var otherChatBox in chatBoxes.Values)
            {
                otherChatBox.Visible = false;
            }
            chatBox.Visible = true;
        }

        private void BT_AI_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                LBox_listFriends.Items.Insert(0, "AI");
            });

            AI.main = this;
            mainChat.Controls.Add(AI);

            AI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AI.BackColor = SystemColors.Window;
            AI.Location = chatBox.Location;
            AI.Margin = new Padding(3, 4, 3, 4);
            AI.Name = "AI";
            AI.Size = chatBox.Size;
        }
    }
}
