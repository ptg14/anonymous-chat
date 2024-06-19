using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static anonymous_chat.Chat.AttachmentChatModel;

namespace anonymous_chat.Chat
{
    public partial class ChatBox : UserControl
    {
        public MessageData chatbox_info;
        public OpenFileDialog fileDialog = new OpenFileDialog();
        public string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public Main main;
        public string filePath;

        public ChatBox(MessageData input_info)
        {
            InitializeComponent();

            chatbox_info = input_info;

            TB_message.Text = input_info.ChatPlaceholder;

            TB_message.Enter += ChatEnter;
            TB_message.Leave += ChatLeave;
            BT_send.Click += SendMessage;
            BT_file.Click += BuildAttachment;
            BT_clear.Click += CancelAttachment;

            TB_message.KeyDown += OnEnter;

        }

        public void AddMessage(IChatModel message)
        {
            var chatItem = new ChatItem(message);
            chatItem.Name = "chatItem" + ChatPanel.Controls.Count;
            chatItem.Dock = DockStyle.Top;
            ChatPanel.Controls.Add(chatItem);
            chatItem.BringToFront();

            chatItem.ResizeBubbles((int)(ChatPanel.Width * 0.6));

            ChatPanel.ScrollControlIntoView(chatItem);
        }

        void ChatLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_message.Text))
            {
                TB_message.Text = chatbox_info.ChatPlaceholder;
                TB_message.ForeColor = Color.Gray;
            }
        }

        void ChatEnter(object sender, EventArgs e)
        {
            TB_message.ForeColor = Color.Black;
            if (TB_message.Text == chatbox_info.ChatPlaceholder)
            {
                TB_message.Text = "";
            }
        }

        async void SendMessage(object sender, EventArgs e)
        {
            string chatmessage = TB_message.Text;

            IChatModel chatModel = null;
            IChatModel saveChatModel = null;
            TextChatModel textModel = null;

            if (chatbox_info.Attachment != null && chatbox_info.AttachmentType.Contains("image"))
            {
                chatModel = new ImageChatModel()
                {
                    Author = chatbox_info.User,
                    Image = Image.FromStream(new MemoryStream(chatbox_info.Attachment)),
                    path = filePath,
                    ImageName = chatbox_info.AttachmentName,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now,
                };
                saveChatModel = new ImageChatModel()
                {
                    Author = chatbox_info.User,
                    path = filePath,
                    ImageName = chatbox_info.AttachmentName,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now,
                };
            }
            else if (chatbox_info.Attachment != null)
            {
                chatModel = new AttachmentChatModel()
                {
                    Author = chatbox_info.User,
                    Attachment = chatbox_info.Attachment,
                    path = filePath,
                    Filename = chatbox_info.AttachmentName,
                    Read = true,
                    Inbound = false,
                    Time = DateTime.Now
                };
                saveChatModel = new AttachmentChatModel()
                {
                    Author = chatbox_info.User,
                    path = filePath,
                    Filename = chatbox_info.AttachmentName,
                    Read = true,
                    Inbound = false,
                    Time = DateTime.Now
                };
            }

            if (!string.IsNullOrWhiteSpace(chatmessage) && chatmessage != chatbox_info.ChatPlaceholder)
            {
                textModel = new TextChatModel()
                {
                    Author = chatbox_info.User,
                    Body = chatmessage,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
            }

            try
            {
                // check file attachment
                if (chatModel != null)
                {
                    chatModel.Author = main.userName;
                    AddMessage(chatModel);
                    FileInfo fileInfo = new FileInfo(filePath);
                    string textJson;
                    if (chatModel.Type == "image")
                    {
                        textJson = main.UID + "-" + main.toUID + "~" + chatModel.Author + $"+{(chatModel as ImageChatModel).ImageName},{chatModel.Type};{chatModel.Time.Day}_{chatModel.Time.Month}_{chatModel.Time.Year}_{chatModel.Time.Hour}_{chatModel.Time.Minute}_{chatModel.Time.Second}" + fileInfo.Extension;
                    }
                    else
                    {
                        textJson = main.UID + "-" + main.toUID + "~" + chatModel.Author + $"+{(chatModel as AttachmentChatModel).Filename},{chatModel.Type};{chatModel.Time.Day}_{chatModel.Time.Month}_{chatModel.Time.Year}_{chatModel.Time.Hour}_{chatModel.Time.Minute}_{chatModel.Time.Second}" + fileInfo.Extension;
                    }

                    string folderPathroot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, main.UID.ToString());
                    string folderPath = Path.Combine(folderPathroot, main.toUID.ToString());
                    string destinationFilePath = Path.Combine(folderPath, textJson);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    try
                    {
                        // Copy the file
                        File.Copy(filePath, destinationFilePath, overwrite: true);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");
                    }

                    saveChatModel.Author = main.userName;
                    if (saveChatModel.Type == "image")
                    {
                        (saveChatModel as ImageChatModel).path = destinationFilePath;
                    }
                    else
                    {
                        (saveChatModel as AttachmentChatModel).path = destinationFilePath;
                    }
                    string json = JsonConvert.SerializeObject(saveChatModel);
                    main.saveChat(main.toUID, main.UID, json);
                    //MessageBox.Show(textJson);
                    main.SendFile(destinationFilePath);

                    CancelAttachment(null, null);
                }
                // check text message
                if (textModel != null)
                {
                    textModel.Author = main.userName;
                    AddMessage(textModel);
                    if (main.toUID != 0)
                    {
                        if (main.toUID == 142)
                        {
                            using (var client = new HttpClient())
                            {
                                var content = new FormUrlEncodedContent(new[]
                                {
                                    new KeyValuePair<string, string>("text", chatmessage),
                                    new KeyValuePair<string, string>("lc", "vn"),
                                    new KeyValuePair<string, string>("key", "")
                                });

                                var response = await client.PostAsync("https://api.simsimi.vn/v2/simtalk", content);
                                Debug.WriteLine(await response.Content.ReadAsStringAsync());

                                if (response.IsSuccessStatusCode)
                                {
                                    var responseString = await response.Content.ReadAsStringAsync();
                                    var simsimiResponse = JsonConvert.DeserializeObject<SimsimiResponse>(responseString);

                                    var textChatModel = new TextChatModel
                                    {
                                        Inbound = true,
                                        Read = false,
                                        Time = DateTime.Now,
                                        Author = "AI",
                                        Body = simsimiResponse.message
                                    };
                                    AddMessage(textChatModel);
                                }
                            }
                        }
                        else
                        {
                            string json = JsonConvert.SerializeObject(textModel);
                            if (main.toUID != 999){
                                main.saveChat(main.toUID, main.UID, json);
                            }
                            string textJson = main.UID + ">" + main.toUID + "=" + json;
                            main.Send(textJson);
                        }
                    }
                    TB_message.Text = string.Empty;
                }
            }
            catch (Exception exc)
            {
                textModel = new TextChatModel()
                {
                    Author = chatbox_info.User,
                    Body = "The message could not be processed. Please see the reason below.\r\n" + exc.Message,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
                AddMessage(textModel);
            }
        }

        void BuildAttachment(object sender, EventArgs e)
        {
            fileDialog.InitialDirectory = initialdirectory;
            fileDialog.Reset();
            fileDialog.Multiselect = false;

            var result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selected = fileDialog.FileName;
                filePath = selected;
                try
                {
                    var file = File.ReadAllBytes(selected);
                    if (file.Length > 100 * 1024 * 1024)
                    {
                        MessageBox.Show("The attachment provided " + fileDialog.SafeFileName + " is too big to be sent by SMS. Please select another.", "Attachment not added.");
                        return;
                    }
                    else
                    {
                        chatbox_info.Attachment = file;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an issue with retrieving the file.", "File Operation Error");
                }
            }
            else
            {
                return;
            }

            if (chatbox_info.Attachment != null)
            {
                string smallname = fileDialog.SafeFileName;
                chatbox_info.AttachmentName = fileDialog.SafeFileName;

                string name = Path.GetFileNameWithoutExtension(smallname);
                string extension = Path.GetExtension(smallname);
                BT_file.FlatAppearance.BorderColor = Color.Red;
                if (smallname.Length > 12)
                {
                    smallname = name.Substring(0, 7) + ".." + extension;
                }
                //BT_file.Text = smallname;
                LB_fileName.Text = smallname;

                BT_clear.Visible = true;
                chatbox_info.AttachmentType = Type.GetMimeType(extension);
            }
        }

        void CancelAttachment(object sender, EventArgs e)
        {
            //BT_file.Text = string.Empty;
            LB_fileName.Text = string.Empty;
            BT_file.FlatAppearance.BorderColor = Color.Black;
            chatbox_info.Attachment = null;
            chatbox_info.AttachmentName = null;
            chatbox_info.AttachmentType = null;
            BT_clear.Visible = false;
            BT_file.Width = 50;
        }

        async void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                SendMessage(this, null);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (var control in ChatPanel.Controls)
            {
                if (control is ChatItem)
                {
                    (control as ChatItem).ResizeBubbles((int)(ChatPanel.Width * 0.6));
                }
            }
        }

    }
}
