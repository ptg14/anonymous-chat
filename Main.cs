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
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace anonymous_chat
{
    public partial class Main : Form
    {
        private static FirestoreDb db = FireBase.dataBase;
        public int UID;
        public int toUID;
        public string userName;
        private bool addFriendVisible = false;
        private Dictionary<UserData, ChatBox> friendList = new Dictionary<UserData, ChatBox>();
        private Dictionary<GroupChat, ChatBox> groupList = new Dictionary<GroupChat, ChatBox>();
        ChatBox AI = new ChatBox(new MessageData());

        public Main()
        {
            InitializeComponent();

            bool saveLogin = false;
            if (File.Exists("credentials.json"))
            {
                string userJson = File.ReadAllText("credentials.json");
                UserData user = JsonConvert.DeserializeObject<UserData>(userJson);
                UID = user.UID;
                userName = user.UserName;
                saveLogin = true;
            }
            if ((saveLogin == true || SignIn_SignUp.ShowAndTryGetInput(out UID, out userName, this)) && FireBase.setEnironmentVariables())
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = $"SETAVATAR~{UID}.png";
                string filePath = Path.Combine(folderPath, fileName);
                if (File.Exists(filePath))
                {
                    using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                    {
                        BT_avatar.Image = Image.FromStream(ms);
                    }
                }
                LB_name.Text = userName;
                LB_UID.Text = "UID: " + UID.ToString();
                isOnline();
                LoadList();
                Thread connectThread = new Thread(ConnectToServer);
                connectThread.IsBackground = true;
                connectThread.Start();
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
                    client = new TcpClient("127.0.0.1", 8888);
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
            Send("UIDCONNECT=" + UID);
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

        public async void SendFile(string filePath)
        {
            if (isConnected && stream != null)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string header = $"FILE={fileInfo.Name}:{fileInfo.Length}";
                    byte[] headerBytes = Encoding.ASCII.GetBytes(header);
                    await stream.WriteAsync(headerBytes, 0, headerBytes.Length);

                    // Now send the file
                    byte[] fileBuffer = new byte[100 * 1024 * 1024];
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        int bytesRead;
                        while ((bytesRead = await fileStream.ReadAsync(fileBuffer, 0, fileBuffer.Length)) > 0)
                        {
                            await stream.WriteAsync(fileBuffer, 0, bytesRead);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending file: {ex.Message}", "ERROR");
                }
            }
        }

        private void ReceiveMessages()
        {
            while (isConnected)
            {
                byte[] data = new byte[100 * 1024 * 1024];
                int bytes = 0;
                try
                {
                    bytes = stream.Read(data, 0, data.Length);
                }
                catch (IOException ex)
                {
                    // Handle the exception here
                    MessageBox.Show(ex.Message, "ERROR");
                    isConnected = false;
                    Thread connectThread = new Thread(ConnectToServer);
                    connectThread.IsBackground = true;
                    connectThread.Start();
                    break;
                }

                string receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
                //MessageBox.Show("Receive:\n" + receivedMessage);


                string[] parts = receivedMessage.Split('=');

                if (parts[0] == "FRIENDREQUEST" || parts[0] == "FRIENDACCEPTED" || parts[0] == "FRIENDREJECTED" || parts[0] == "GROUPREQUEST")
                {
                    notiPanel.addNoti(receivedMessage);
                    BT_noti.BackColor = Color.Red;
                }
                else
                {
                    string[] ids = parts[0].Split(">");

                    int senderID = int.Parse(ids[0]);
                    int receiverID = int.Parse(ids[1]);

                    string json = parts[1];
                    IChatModel receivedModel = null;

                    JObject jObject = JObject.Parse(json);
                    if (jObject.ContainsKey("Type"))
                    {
                        string type = (string)jObject["Type"];
                        switch (type)
                        {
                            case "text":
                                receivedModel = new TextChatModel();
                                receivedModel = JsonConvert.DeserializeObject<TextChatModel>(json);
                                receivedModel.Inbound = true;
                                break;
                            case "image":
                                receivedModel = new ImageChatModel();
                                receivedModel = JsonConvert.DeserializeObject<ImageChatModel>(json);
                                receivedModel.Inbound = true;
                                break;
                            case "attachment":
                                receivedModel = new AttachmentChatModel();
                                receivedModel = JsonConvert.DeserializeObject<AttachmentChatModel>(json);
                                receivedModel.Inbound = true;
                                break;
                            default:
                                // Handle unexpected type
                                MessageBox.Show($"Received an object of unexpected type: {type}");
                                break;
                        }
                    }

                    // Check if the message is sent to you
                    if (receiverID == UID)
                    {
                        UserData userSender = friendList.Keys.FirstOrDefault(user => user.UID == senderID);
                        // Update TB_remessage on the UI thread
                        if (this.IsHandleCreated) // Check if the handle has been created
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (userSender != null && receivedModel != null)
                                {
                                    friendList[userSender].AddMessage(receivedModel);
                                }
                            });
                        }

                    }
                    else
                    {
                        GroupChat groupSender = groupList.Keys.FirstOrDefault(group => group.GroupUID == receiverID);
                        if (groupSender != null)
                        {
                            // Update TB_remessage on the UI thread
                            if (this.IsHandleCreated) // Check if the handle has been created
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (receivedModel != null)
                                    {
                                        groupList[groupSender].AddMessage(receivedModel);
                                    }
                                });
                            }
                        }
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

        public void openChat(int chatUID)
        {
            toUID = chatUID;
            if (chatUID == 142)
            {
                foreach (var otherChatBox in friendList.Values)
                {
                    otherChatBox.Visible = false;
                }
                AI.Visible = true;
                AI.BringToFront();
                LB_friendName.Text = "Simsimi";
                return;
            }
            else if (toUID < 10000)
            {
                UserData selectedUserData = friendList.Keys.FirstOrDefault(user => user.UID == chatUID);
                if (selectedUserData == null)
                {
                    // create a new ChatBox for this friend
                    ChatBox newChatBox = new ChatBox(new MessageData());
                    newChatBox.main = this;

                    mainChat.Controls.Add(newChatBox);

                    newChatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    newChatBox.BackColor = SystemColors.Window;
                    newChatBox.Location = new Point(0, 0);
                    newChatBox.Margin = new Padding(3, 4, 3, 4);
                    newChatBox.Name = $"newChatBox{selectedUserData.UID}";
                    newChatBox.Size = new Size(619, 440);
                    newChatBox.Visible = false;

                    friendList.Add(selectedUserData, newChatBox);
                }
                // Show the existing ChatBox and hide the others
                foreach (var otherChatBox in friendList.Values)
                {
                    otherChatBox.Visible = otherChatBox == friendList[selectedUserData];
                }
                foreach (var otherChatBox in groupList.Values)
                {
                    otherChatBox.Visible = false;
                }
                friendList[selectedUserData].Visible = true;
                friendList[selectedUserData].BringToFront();
                LB_friendName.Text = selectedUserData.UserName;
            }
            else if (toUID > 10000)
            {
                GroupChat selectedGroup = groupList.Keys.FirstOrDefault(group => group.GroupUID == chatUID);
                if (selectedGroup == null)
                {
                    // create a new ChatBox for this group
                    ChatBox newChatBox = new ChatBox(new MessageData());
                    newChatBox.main = this;

                    mainChat.Controls.Add(newChatBox);

                    newChatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    newChatBox.BackColor = SystemColors.Window;
                    newChatBox.Location = new Point(0, 0);
                    newChatBox.Margin = new Padding(3, 4, 3, 4);
                    newChatBox.Name = $"newChatBox{selectedGroup.GroupUID}";
                    newChatBox.Size = new Size(619, 440);
                    newChatBox.Visible = false;

                    groupList.Add(selectedGroup, newChatBox);
                }
                // Show the existing ChatBox and hide the others
                foreach (var otherChatBox in groupList.Values)
                {
                    otherChatBox.Visible = otherChatBox == groupList[selectedGroup];
                }
                foreach (var otherChatBox in friendList.Values)
                {
                    otherChatBox.Visible = false;
                }
                groupList[selectedGroup].Visible = true;
                groupList[selectedGroup].BringToFront();
                LB_friendName.Text = selectedGroup.GroupName;
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

        public async void LoadFriendList()
        {
            // Query the database for the user's friend list
            Query query = db.Collection("Friends").WhereEqualTo("UID", UID).WhereEqualTo("isFriend", true);

            var querySnapshot = await query.GetSnapshotAsync();
            //MessageBox.Show($"Number of documents returned by the query: {querySnapshot.Count}");

            foreach (DocumentSnapshot document in querySnapshot.Documents)
            {
                // Get the friend's UID and user name
                Friends friend = document.ConvertTo<Friends>();
                DocumentSnapshot userSnapshot = await db.Collection("Users").Document(friend.FriendUID.ToString()).GetSnapshotAsync();
                UserData user = userSnapshot.ConvertTo<UserData>();

                this.Invoke((MethodInvoker)delegate
                {
                    // create a new ChatBox for each friend
                    ChatBox newChatBox = new ChatBox(new MessageData());
                    newChatBox.main = this;

                    mainChat.Controls.Add(newChatBox);

                    newChatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    newChatBox.BackColor = SystemColors.Window;
                    newChatBox.Location = new Point(0, 0);
                    newChatBox.Margin = new Padding(3, 4, 3, 4);
                    newChatBox.Name = $"newChatBox{user.UID}";
                    newChatBox.Size = new Size(619, 440);
                    newChatBox.Visible = false;

                    friendList.Add(user, newChatBox);
                });
            }

            this.Invoke((MethodInvoker)delegate
            {
                foreach (UserData friend in friendList.Keys)
                {
                    friendPanel.addFriend(friend.UID, friend.UserName);
                    friendListPanel.addFriend(friend.UID, friend.UserName);
                }
            });
        }

        public async void LoadGroupList()
        {
            // Query the database for the user's group list
            Query query = db.Collection("Group").WhereArrayContains("MemberUID", UID);

            var querySnapshot = await query.GetSnapshotAsync();
            //MessageBox.Show($"Number of documents returned by the query: {querySnapshot.Count}");

            foreach (DocumentSnapshot document in querySnapshot.Documents)
            {
                // Get the group's UID and group name
                GroupChat group = document.ConvertTo<GroupChat>();

                this.Invoke((MethodInvoker)delegate
                {
                    // create a new ChatBox for each group
                    ChatBox newChatBox = new ChatBox(new MessageData());
                    newChatBox.main = this;

                    mainChat.Controls.Add(newChatBox);

                    newChatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    newChatBox.BackColor = SystemColors.Window;
                    newChatBox.Location = new Point(0, 0);
                    newChatBox.Margin = new Padding(3, 4, 3, 4);
                    newChatBox.Name = $"newChatBox{group.GroupUID}";
                    newChatBox.Size = new Size(619, 440);
                    newChatBox.Visible = false;

                    groupList.Add(group, newChatBox);
                });
            }

            this.Invoke((MethodInvoker)delegate
            {
                foreach (GroupChat group in groupList.Keys)
                {
                    friendPanel.addFriend(group.GroupUID, group.GroupName);
                    friendListPanel.addFriend(group.GroupUID, group.GroupName);
                }
            });
        }

        public void LoadList()
        {
            friendPanel.Controls.Clear();
            LoadFriendList();
            LoadGroupList();
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
            string friendRequestMessage = $"FRIENDREQUEST={UID}>{TB_friendUID.Text}";
            Send(friendRequestMessage);
        }

        private void BT_refresh_Click(object sender, EventArgs e)
        {
            foreach (var pair in friendList)
            {
                pair.Value.Dispose();
            }
            foreach (var pair in groupList)
            {
                pair.Value.Dispose();
            }
            friendList.Clear();
            groupList.Clear();
            LoadList();
        }

        private void BT_AI_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                friendPanel.addFriend(142, "Simsimi");
            });

            AI.main = this;
            mainChat.Controls.Add(AI);

            AI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AI.BackColor = SystemColors.Window;
            AI.Location = new Point(0, 0);
            AI.Margin = new Padding(3, 4, 3, 4);
            AI.Name = "Simsimi";
            AI.Size = new Size(619, 440);
            AI.Visible = false;
        }

        private void BT_setting_Click(object sender, EventArgs e)
        {
            setting.Visible = !setting.Visible;
            setting.BringToFront();
        }

        private void BT_noti_Click(object sender, EventArgs e)
        {
            notiPanel.Visible = !notiPanel.Visible;
            BT_noti.BackColor = Color.White;
            notiPanel.BringToFront();
        }

        private void BT_listFriends_Click(object sender, EventArgs e)
        {
            friendListPanel.Visible = !friendListPanel.Visible;
            friendListPanel.BringToFront();
        }

        private void BT_random_Click(object sender, EventArgs e)
        {

        }

        private void BT_logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_avatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Define the folder path and the file name
                    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                    string fileName = $"SETAVATAR~{UID}.png";
                    string filePath = Path.Combine(folderPath, fileName);

                    // Ensure the directory exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Resize and save the selected image
                    ResizeImage(openFileDialog.FileName, filePath, 50, 50);

                    // Load the resized image into a MemoryStream to avoid locking the file
                    using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                    {
                        BT_avatar.Image = Image.FromStream(ms);
                    }

                    SendFile(filePath);
                }
            }
        }

        public void ResizeImage(string originalFile, string newFile, int width, int height)
        {
            using (Image originalImage = Image.FromFile(originalFile))
            {
                using (Bitmap newImage = new Bitmap(width, height))
                {
                    using (Graphics graphics = Graphics.FromImage(newImage))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(originalImage, 0, 0, width, height);
                    }
                    if (File.Exists(newFile))
                    {
                        File.Delete(newFile);
                    }
                    newImage.Save(newFile, ImageFormat.Png);
                }
            }
        }
    }
}
