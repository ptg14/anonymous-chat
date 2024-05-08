using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat.Chat
{
    public partial class ChatBox : UserControl
    {
        public MessageData chatbox_info;
        public OpenFileDialog fileDialog = new OpenFileDialog();
        public string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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
            TextChatModel textModel = null;

            if (chatbox_info.Attachment != null && chatbox_info.AttachmentType.Contains("image"))
            {
                chatModel = new ImageChatModel()
                {
                    Author = chatbox_info.User,
                    Image = Image.FromStream(new MemoryStream(chatbox_info.Attachment)),
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
                /*

                    SEND MESSSAGE TO SERVER HERE

                */
                // check file attachment
                if (chatModel != null)
                {
                    AddMessage(chatModel);
                    CancelAttachment(null, null);
                }
                // check text message
                if (textModel != null)
                {
                    AddMessage(textModel);
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
            BT_file.Width = 30;
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
