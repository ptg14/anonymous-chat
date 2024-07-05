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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Google.Protobuf.WellKnownTypes;

namespace anonymous_chat
{
    public partial class Main : Form
    {
        private static FirestoreDb db = FireBase.dataBase;
        public int UID;
        public int toUID;
        public bool random = false;
        public string userName;
        private bool addFriendVisible = false;
        private Dictionary<UserData, ChatBox> friendList = new Dictionary<UserData, ChatBox>();
        private Dictionary<GroupChat, ChatBox> groupList = new Dictionary<GroupChat, ChatBox>();
        private ChatBox AI = new ChatBox(new MessageData());
        private ChatBox Random = new ChatBox(new MessageData());
        public Call call;

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
                Thread connectThread = new Thread(ConnectToServer);
                connectThread.IsBackground = true;
                connectThread.Start();
                LoadList();
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
                byte[] message = Encoding.UTF8.GetBytes(text);
                stream.Write(message, 0, message.Length);
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

        private async void ReceiveMessages()
        {
            byte[] data = new byte[100 * 1024 * 1024];
            while (isConnected)
            {
                int bytes = 0;
                try
                {
                    bytes = await stream.ReadAsync(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                    Debug.WriteLine("False connect to server: " + ex);
                    isConnected = false;
                    Thread connectThread = new Thread(ConnectToServer);
                    connectThread.IsBackground = true;
                    connectThread.Start();
                }

                if (bytes == 0)
                {
                    break;
                }

                try
                {
                    string receivedMessage = Encoding.UTF8.GetString(data, 0, bytes);
                    Debug.WriteLine(receivedMessage);
                    //MessageBox.Show("Receive:\n" + receivedMessage);


                    string[] parts = receivedMessage.Split('=');

                    if (parts[0] == "FILE")
                    {
                        // Extract file name and size from the header
                        string[] fileInfo = parts[1].Split(':');
                        string fileName = fileInfo[0];
                        long fileSize;
                        if (!long.TryParse(fileInfo[1], out fileSize))
                        {
                            Debug.WriteLine("Invalid file size: " + fileInfo[1]);
                            continue;
                        }
                        string[] mode = fileName.Split("~");
                        string dowhat = mode[0];
                        string content = mode[1];
                        int senderID = 0;
                        int receiverID = 0;
                        string folderPath;
                        string filePath;
                        if (dowhat == "SETAVATAR")
                        {
                            string[] nameAndEx = content.Split(".");
                            string folderPathRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                            folderPath = Path.Combine(folderPathRoot, nameAndEx[0]);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            filePath = Path.Combine(folderPath, fileName);
                        }
                        else if (dowhat == "FINDLOGO"){
                            // Define the folder path and the file name
                            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                            fileName = "FINDLOGO.png";
                            filePath = Path.Combine(folderPath, fileName);

                            // Ensure the directory exists
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                        }
                        else
                        {
                            string[] send = dowhat.Split("-");
                            senderID = int.Parse(send[0]);
                            receiverID = int.Parse(send[1]);
                            if (receiverID < 10000)
                            {
                                string folderPathroot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, receiverID.ToString());
                                folderPath = Path.Combine(folderPathroot, senderID.ToString());
                            }
                            else
                            {
                                string folderPath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                                string folderPath2 = Path.Combine(folderPath1, receiverID.ToString());
                                folderPath = Path.Combine(folderPath2, senderID.ToString());
                            }
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            filePath = Path.Combine(folderPath, fileName);
                        }

                        // Prepare to receive the file
                        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            long totalBytesReceived = 0;
                            byte[] fileBuffer = new byte[100 * 1024 * 1024];

                            while (totalBytesReceived < fileSize)
                            {
                                int bytesReadfile = await stream.ReadAsync(fileBuffer, 0, fileBuffer.Length);
                                fileStream.Write(fileBuffer, 0, bytesReadfile);
                                totalBytesReceived += bytesReadfile;
                            }
                        }

                        if (dowhat == "FINDLOGO")
                        {
                            // Load the resized image into a MemoryStream to avoid locking the file
                            using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                            {
                                PB_findResult.Image = Image.FromStream(ms);
                            }
                        }
                        else if (dowhat != "SETAVATAR")
                        {
                            IChatModel chatModel;
                            IChatModel saveChatModel;
                            byte[] fileContent = File.ReadAllBytes(filePath);
                            string author = "";
                            string attachmentName = "";
                            string type = "";
                            DateTime datetime = DateTime.Now;
                            nameConvert(ref author, ref attachmentName, ref type, ref datetime, content);
                            switch (type)
                            {
                                case "image":
                                    chatModel = new ImageChatModel()
                                    {
                                        Author = author,
                                        Time = datetime,
                                        ImageName = attachmentName,
                                        Image = Image.FromFile(filePath),
                                        path = filePath,
                                        Inbound = true,
                                    };
                                    saveChatModel = new ImageChatModel()
                                    {
                                        Author = author,
                                        Time = datetime,
                                        ImageName = attachmentName,
                                        path = filePath,
                                        Inbound = true,
                                    };
                                    break;
                                default:
                                    chatModel = new AttachmentChatModel()
                                    {
                                        Author = author,
                                        Filename = attachmentName,
                                        Time = datetime,
                                        Attachment = fileContent,
                                        path = filePath,
                                        Inbound = true,
                                    };
                                    saveChatModel = new AttachmentChatModel()
                                    {
                                        Author = author,
                                        Filename = attachmentName,
                                        Time = datetime,
                                        path = filePath,
                                        Inbound = true,
                                    };
                                    break;
                            }
                            if (receiverID == 999)
                            {
                                if (this.IsHandleCreated) // Check if the handle has been created
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        if (chatModel != null)
                                        {
                                            Random.AddMessage(chatModel);
                                            if (toUID != 999)
                                            {
                                                friendPanel.friendList[999].hasMessage();
                                            }
                                        }
                                    });
                                }
                            }
                            else if (receiverID == UID)
                            {
                                UserData userSender = friendList.Keys.FirstOrDefault(user => user.UID == senderID);
                                // Update TB_remessage on the UI thread
                                if (this.IsHandleCreated) // Check if the handle has been created
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        if (userSender != null && chatModel != null)
                                        {
                                            friendList[userSender].AddMessage(chatModel);
                                            if (receiverID != toUID)
                                            {
                                                friendPanel.friendList[receiverID].hasMessage();
                                            }
                                        }
                                    });
                                }
                                string json = JsonConvert.SerializeObject(saveChatModel);
                                saveChat(senderID, receiverID, json);
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
                                            if (chatModel != null)
                                            {
                                                groupList[groupSender].AddMessage(chatModel);
                                                if (groupSender.GroupUID != toUID)
                                                {
                                                    friendPanel.friendList[groupSender.GroupUID].hasMessage();
                                                }
                                            }
                                        });
                                    }
                                }
                                string json = JsonConvert.SerializeObject(saveChatModel);
                                saveChat(senderID, receiverID, json);
                            }
                        }
                        else
                        {
                            string[] nameAndEx = content.Split(".");
                            int avatarUID = int.Parse(nameAndEx[0]);
                            string folderPathRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                            folderPath = Path.Combine(folderPathRoot, nameAndEx[0]);
                            filePath = Path.Combine(folderPath, fileName);
                            string newFilePath = Path.Combine(folderPath, "SETAVATAR~" + nameAndEx[0] + "70x70.png");
                            if (File.Exists(filePath))
                            {
                                ResizeImage(filePath, newFilePath, 70, 70);
                                this.Invoke((MethodInvoker)delegate
                                {
                                    try
                                    {
                                        using (var ms = new MemoryStream(File.ReadAllBytes(newFilePath)))
                                        {
                                            friendPanel.friendList[avatarUID].PB_avatar.Image = Image.FromStream(ms);
                                            friendListPanel.friendList[avatarUID].PB_avatar.Image = Image.FromStream(ms);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("Change avatar: " + ex.Message, "ERROR");
                                    }
                                });
                            }
                        }
                    }
                    else if (parts[0] == "DISCONNECT")
                    {
                        int disconnectUID = int.Parse(parts[1]);
                        if (friendPanel.friendList.ContainsKey(disconnectUID))
                        {
                            friendPanel.friendList[disconnectUID].changeOnlineStatus(false);
                            friendListPanel.friendList[disconnectUID].changeOnlineStatus(false);
                        }
                    }
                    else if (parts[0] == "UIDCONNECT")
                    {
                        int connectUID = int.Parse(parts[1]);
                        if (friendPanel.friendList.ContainsKey(connectUID))
                        {
                            friendPanel.friendList[connectUID].changeOnlineStatus(true);
                            friendListPanel.friendList[connectUID].changeOnlineStatus(true);
                        }
                    }
                    else if (parts[0] == "RANDOMACCEPTED")
                    {
                        random = true;
                        TextChatModel system = new TextChatModel()
                        {
                            Author = "System",
                            Time = DateTime.Now,
                            Body = "Người nhắn ngẫu nhiên đã tham gia cuộc trò chuyện.",
                            Inbound = true
                        };
                        this.Invoke((MethodInvoker)delegate
                        {
                            Random.ChatPanel.Controls.Clear();
                            Random.AddMessage(system);
                            Random.BT_send.Enabled = true;
                            friendPanel.friendList[999].changeOnlineStatus(true);
                        });
                    }
                    else if (parts[0] == "RANDOMCANCELLED")
                    {
                        random = false;
                        TextChatModel system = new TextChatModel()
                        {
                            Author = "System",
                            Time = DateTime.Now,
                            Body = "Người nhắn ngẫu nhiên đã thoát cuộc trò chuyện.",
                            Inbound = true
                        };
                        this.Invoke((MethodInvoker)delegate
                        {
                            Random.AddMessage(system);
                            Random.BT_send.Enabled = false;
                            friendPanel.friendList[999].changeOnlineStatus(false);
                        });
                    }
                    else if (parts[0] == "RANDOMREJECTED")
                    {
                        TextChatModel system = new TextChatModel()
                        {
                            Author = "System",
                            Time = DateTime.Now,
                            Body = "Hiện tại không tìm thấy ai, xin đợi.",
                            Inbound = true
                        };
                        this.Invoke((MethodInvoker)delegate
                        {
                            Random.ChatPanel.Controls.Clear();
                            Random.AddMessage(system);
                            friendPanel.friendList[999].changeOnlineStatus(false);
                        });
                    }
                    else if (parts[0] == "FRIENDREQUEST" || parts[0] == "FRIENDACCEPTED" || parts[0] == "FRIENDREJECTED" || parts[0] == "GROUPREQUEST" || parts[0] == "CALLREQUEST")
                    {
                        notiPanel.addNoti(receivedMessage);
                        BT_noti.BackColor = Color.Red;
                    }
                    else if (parts[0] == "CALLACCEPTED")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            call.LB_log.ForeColor = Color.Green;
                            call.LB_log.Text = "Cuộc gọi được chấp nhận";
                        });
                        call.Start();
                    }
                    else if (parts[0] == "CALLREJECTED")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            call.LB_log.ForeColor = Color.Red;
                            call.LB_log.Text = "Cuộc gọi bị từ chối";
                        });
                    }
                    else if (parts[0] == "ENDCALL")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            call.LB_log.ForeColor = Color.Red;
                            call.LB_log.Text = "Cuộc gọi đã kết thúc";
                        });
                    }
                    else if (parts[0] == "CAMOFF")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            call.PB_you.Image = Properties.Resources.user300x300;
                        });
                    }
                    else if (parts[0] == "MICOFF")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            call.PBar_resound.Value = call.PBar_resound.Minimum;
                        });
                    }
                    else
                    {
                        int senderID = 0;
                        int receiverID = 0;
                        TextChatModel? textMessage = new TextChatModel();
                        string json = "";
                        try
                        {
                            string[] ids = parts[0].Split(">");

                            senderID = int.Parse(ids[0]);
                            receiverID = int.Parse(ids[1]);

                            json = parts[1];
                            textMessage = JsonConvert.DeserializeObject<TextChatModel>(json);
                            textMessage.Inbound = true;
                            json = JsonConvert.SerializeObject(textMessage);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message, "ERROR");
                        }

                        // Check if the message is sent to you
                        if (receiverID == 999)
                        {
                            if (this.IsHandleCreated) // Check if the handle has been created
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (textMessage != null)
                                    {
                                        Random.AddMessage(textMessage);
                                        if (toUID != 999)
                                        {
                                            friendPanel.friendList[999].hasMessage();
                                        }
                                    }
                                });
                            }
                        }
                        else if (receiverID == UID)
                        {
                            UserData userSender = friendList.Keys.FirstOrDefault(user => user.UID == senderID);
                            // Update TB_remessage on the UI thread
                            if (this.IsHandleCreated) // Check if the handle has been created
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (userSender != null && textMessage != null)
                                    {
                                        friendList[userSender].AddMessage(textMessage);
                                        if (userSender.UID != toUID)
                                        {
                                            friendPanel.friendList[userSender.UID].hasMessage();
                                        }
                                    }
                                });
                            }
                            saveChat(senderID, receiverID, json);
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
                                        if (textMessage != null)
                                        {
                                            groupList[groupSender].AddMessage(textMessage);
                                            if (receiverID != toUID)
                                            {
                                                friendPanel.friendList[groupSender.GroupUID].hasMessage();
                                            }
                                        }
                                    });
                                }
                            }
                            saveChat(senderID, receiverID, json);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Receive message: " + ex.Message, "ERROR");
                }
            }
        }

        private void nameConvert(ref string name, ref string attachmentName, ref string type, ref DateTime datetime, string input)
        {
            string[] nameAndDateTime = input.Split(';');
            string[] nameAndType = nameAndDateTime[0].Split(',');
            type = nameAndType[1];
            string[] nameAndAttach = nameAndType[0].Split('+');
            name = nameAndAttach[0];
            attachmentName = nameAndAttach[1];
            string[] noExtension = nameAndDateTime[1].Split('.');
            DateTime.TryParseExact(noExtension[0], "d_M_yyyy_H_m_s", null, System.Globalization.DateTimeStyles.None, out datetime);
        }

        public void saveChat(int senderID, int receiverID, string json)
        {
            string folderPath;
            if (receiverID >= 10000)
            {
                folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                folderPath = Path.Combine(folderPath, receiverID.ToString());
            }
            else
            {
                folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, receiverID.ToString());
                folderPath = Path.Combine(folderPath, senderID.ToString());
            }
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath;
            if (receiverID < 10000)
            {
                filePath = Path.Combine(folderPath, $"{senderID}-{receiverID}~history.txt");
            }
            else
            {
                filePath = Path.Combine(folderPath, $"{receiverID}~history.txt");
            }

            // Ensure newline for each entry if the file already exists
            if (File.Exists(filePath))
            {
                json = Environment.NewLine + json;
            }

            // Append the JSON string to the specified file
            File.AppendAllText(filePath, json);
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
                PB_friendAvatar.Image = Properties.Resources.Simsimi50x50;
                return;
            }
            if (chatUID == 999)
            {
                foreach (var otherChatBox in friendList.Values)
                {
                    otherChatBox.Visible = false;
                }
                Random.Visible = true;
                Random.BringToFront();
                LB_friendName.Text = "Random";
                PB_friendAvatar.Image = Properties.Resources.random50x50;
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
                BT_call.Visible = true;
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
                BT_call.Visible = false;
            }
            string folderPathRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
            string folderPath = Path.Combine(folderPathRoot, toUID.ToString());
            string filePath = Path.Combine(folderPath, "SETAVATAR~" + toUID + ".png");
            try
            {
                if (File.Exists(filePath))
                {
                    PB_friendAvatar.Image = Image.FromFile(filePath);
                }
                else
                {
                    if (toUID < 10000)
                    {
                        PB_friendAvatar.Image = Properties.Resources.user50x50;
                    }
                    else
                    {
                        PB_friendAvatar.Image = Properties.Resources.friend50x50;
                    }
                    Send("GETAVATAR=" + UID + ">" + toUID);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Set chat avatar: " + ex.Message, "ERROR");
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

        public async Task LoadFriendList()
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

                    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                    folderPath = Path.Combine(folderPath, friend.UID.ToString());
                    string fileName = $"SETAVATAR~{friend.UID}70x70.png";
                    string filePath = Path.Combine(folderPath, fileName);
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                            {
                                friendPanel.friendList[friend.UID].PB_avatar.Image = Image.FromStream(ms);
                                friendListPanel.friendList[friend.UID].PB_avatar.Image = Image.FromStream(ms);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Load friend: " + ex.Message, "ERROR");
                        }
                    }

                    filePath = Path.Combine(folderPath, $"{friend.UID}-{UID}~history.txt");
                    if (File.Exists(filePath))
                    {
                        IChatModel chatModel;
                        foreach (string line in File.ReadLines(filePath))
                        {
                            // Deserialize the line to a JObject for inspection
                            var jObject = JObject.Parse(line);

                            // Determine the type based on a property, e.g., "Type"
                            string type = jObject["Type"]?.ToString();

                            switch (type)
                            {
                                case "text":
                                    chatModel = new TextChatModel();
                                    chatModel = JsonConvert.DeserializeObject<TextChatModel>(line);
                                    break;
                                case "image":
                                    chatModel = new ImageChatModel();
                                    chatModel = JsonConvert.DeserializeObject<ImageChatModel>(line);
                                    (chatModel as ImageChatModel).Image = Image.FromFile((chatModel as ImageChatModel).path);
                                    break;
                                case "attachment":
                                    chatModel = new AttachmentChatModel();
                                    chatModel = JsonConvert.DeserializeObject<AttachmentChatModel>(line);
                                    (chatModel as AttachmentChatModel).Attachment = File.ReadAllBytes((chatModel as AttachmentChatModel).path);
                                    break;
                                default:
                                    chatModel = null;
                                    Debug.WriteLine("Unknown type or type property missing");
                                    break;
                            }

                            friendList[friend].AddMessage(chatModel);
                        }
                    }
                }
            });
        }

        public async Task LoadGroupList()
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

                    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UID.ToString());
                    folderPath = Path.Combine(folderPath, group.GroupUID.ToString());
                    string fileName = $"SETAVATAR~{group.GroupUID}70x70.png";
                    string filePath = Path.Combine(folderPath, fileName);
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                            {
                                friendPanel.friendList[group.GroupUID].PB_avatar.Image = Image.FromStream(ms);
                                friendListPanel.friendList[group.GroupUID].PB_avatar.Image = Image.FromStream(ms);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Load group: " + ex.Message, "ERROR");
                        }
                    }

                    filePath = Path.Combine(folderPath, $"{group.GroupUID}~history.txt");
                    if (File.Exists(filePath))
                    {
                        IChatModel chatModel;
                        foreach (string line in File.ReadLines(filePath))
                        {
                            // Deserialize the line to a JObject for inspection
                            var jObject = JObject.Parse(line);

                            // Determine the type based on a property, e.g., "Type"
                            string type = jObject["Type"]?.ToString();

                            switch (type)
                            {
                                case "text":
                                    chatModel = new TextChatModel();
                                    chatModel = JsonConvert.DeserializeObject<TextChatModel>(line);
                                    break;
                                case "image":
                                    chatModel = new ImageChatModel();
                                    chatModel = JsonConvert.DeserializeObject<ImageChatModel>(line);
                                    (chatModel as ImageChatModel).Image = Image.FromFile((chatModel as ImageChatModel).path);
                                    break;
                                case "attachment":
                                    chatModel = new AttachmentChatModel();
                                    chatModel = JsonConvert.DeserializeObject<AttachmentChatModel>(line);
                                    (chatModel as AttachmentChatModel).Attachment = File.ReadAllBytes((chatModel as AttachmentChatModel).path);
                                    break;
                                default:
                                    chatModel = null;
                                    Debug.WriteLine("Unknown type or type property missing");
                                    break;
                            }

                            groupList[group].AddMessage(chatModel);
                        }
                    }
                }
            });
        }

        public async void LoadList()
        {
            friendPanel.Controls.Clear();
            friendPanel.friendList.Clear();
            friendListPanel.Controls.Clear();
            friendListPanel.friendList.Clear();
            await LoadFriendList();
            await LoadGroupList();
            Thread avatar = new Thread(LoadAvatar);
            avatar.IsBackground = true;
            avatar.Start();
        }

        private async void LoadAvatar()
        {
            foreach (UserData friend in friendList.Keys)
            {
                Send("GETAVATAR=" + UID + ">" + friend.UID);
                await Task.Delay(100);
            }
            foreach (GroupChat group in groupList.Keys)
            {
                Send("GETAVATAR=" + UID + ">" + group.GroupUID);
                await Task.Delay(100);
            }
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

            Send("FINDLOGO=" + UID + ">" + TB_friendUID.Text);
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
            else if (friendPanel.friendList.ContainsKey(int.Parse(TB_friendUID.Text)))
            {
                TB_findResult.Text = "Đã là bạn bè";
                return;
            }
            // send to server
            string friendRequestMessage = $"FRIENDREQUEST={UID}>{TB_friendUID.Text}";
            Send(friendRequestMessage);
        }

        private void BT_refresh_Click(object sender, EventArgs e)
        {
            reLoadList();
        }

        public void reLoadList()
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
            if (!friendPanel.friendList.ContainsKey(142))
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
            else
            {
                friendPanel.ScrollControlIntoView(friendPanel.friendList[142]);
            }
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
            if (!friendPanel.friendList.ContainsKey(999))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    friendPanel.addFriend(999, "Random");
                });

                Random.main = this;
                mainChat.Controls.Add(Random);

                Random.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                Random.BackColor = SystemColors.Window;
                Random.Location = new Point(0, 0);
                Random.Margin = new Padding(3, 4, 3, 4);
                Random.Name = "Random";
                Random.Size = new Size(619, 440);
                Random.Visible = false;
                Random.BT_send.Enabled = false;
            }
            else
            {
                friendPanel.ScrollControlIntoView(friendPanel.friendList[999]);
            }
            Random.ChatPanel.Controls.Clear();
            random = false;
            Send("RANDOMREQUEST=" + UID);
        }

        private void BT_logOut_Click(object sender, EventArgs e)
        {
            if (File.Exists("credentials.json"))
            {
                File.Delete("credentials.json");
            }
            Program.RestartApplication();
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
            try
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(originalFile))) // Read the original file into a MemoryStream.
                {
                    using (Bitmap originalBitmap = new Bitmap(ms)) // Create a Bitmap from the MemoryStream.
                    {
                        using (Bitmap newImage = new Bitmap(width, height))
                        {
                            using (Graphics graphics = Graphics.FromImage(newImage))
                            {
                                graphics.CompositingQuality = CompositingQuality.HighQuality;
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.DrawImage(originalBitmap, 0, 0, width, height);
                            }

                            newImage.Save(newFile, ImageFormat.Png);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error resizing image: {ex.Message}", "ERROR");
            }
        }

        private void BT_call_Click(object sender, EventArgs e)
        {
            call = new Call();
            call.main = this;
            call.Show();
            Send("CALLREQUEST=" + UID + ">" + toUID);
        }
    }
}
