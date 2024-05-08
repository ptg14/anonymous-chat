using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat.Chat
{
    public partial class ChatItem : UserControl
    {
        public IChatModel ChatModel { get; set; }
        public ChatItem()
        {
            InitializeComponent();
            bodyTextBox.Text = "No messages were found.";
            authorLabel.Text = "System " + DateTime.Now.ToShortTimeString();
        }

        public ChatItem(IChatModel chatModel)
        {
            InitializeComponent();

            if (chatModel == null)
            {
                chatModel = new TextChatModel()
                {
                    Author = "System",
                    Body = "Lịch sử tin nhắn bị lỗi",
                    Inbound = true,
                    Time = DateTime.Now
                };
            }

            ChatModel = chatModel;

            if (chatModel.Inbound)
            {
                bodyPanel.Dock = DockStyle.Left;
                authorLabel.Dock = DockStyle.Left;
                bodyPanel.BackColor = Color.FromArgb(100, 101, 165);
                bodyTextBox.BackColor = Color.FromArgb(100, 101, 165);
            }
            else
            {
                bodyPanel.Dock = DockStyle.Right;
                authorLabel.Dock = DockStyle.Right;
                bodyTextBox.TextAlign = HorizontalAlignment.Right;
            }

            //Fills in the label. 
            if (chatModel.Time > DateTime.Today)
            {
                authorLabel.Text = $"{chatModel.Author ?? "System"}, {chatModel.Time.ToShortTimeString()}";
            }
            else
            {
                authorLabel.Text = $"{chatModel.Author ?? "System"}, {chatModel.Time.ToShortDateString()}";
            }

            switch (chatModel.Type)
            {
                case "text":
                    var textmodel = chatModel as TextChatModel;
                    bodyTextBox.Text = textmodel.Body.Trim();
                    break;
                case "image":
                    var imagemodel = chatModel as ImageChatModel;
                    bodyTextBox.Visible = false;
                    bodyPanel.BackgroundImage = imagemodel.Image;
                    bodyPanel.BackColor = Color.GhostWhite;
                    bodyPanel.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case "attachment":
                    var attachmentmodel = chatModel as AttachmentChatModel;
                    bodyPanel.BackColor = Color.OrangeRed;
                    bodyTextBox.BackColor = Color.OrangeRed;
                    bodyTextBox.Text = "Click to download: " + attachmentmodel.Filename;
                    bodyTextBox.Click += DownloadAttachment;
                    break;
                default:
                    break;
            }
        }

        void DownloadAttachment(object sender, EventArgs e)
        {
            var attachmentmodel = ChatModel as AttachmentChatModel;
            if (attachmentmodel.Attachment != null)
            {
                string fullpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", attachmentmodel.Filename);
                int count = 1;
                while (System.IO.File.Exists(fullpath))
                {
                    string file = System.IO.Path.GetFileNameWithoutExtension(fullpath);
                    string ext = System.IO.Path.GetExtension(fullpath);
                    string dir = System.IO.Path.GetDirectoryName(fullpath);

                    fullpath = System.IO.Path.Combine(dir, $"{file}({count++}){ext}");
                }

                System.IO.File.WriteAllBytes(fullpath, attachmentmodel.Attachment);
                MessageBox.Show("Attachment " + attachmentmodel.Filename + " was downloaded to the path " + fullpath, "File Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Attachment " + attachmentmodel.Filename + " could not be found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ResizeBubbles(int maxwidth)
        {
            if (ChatModel == null)
            {
                return;
            }
            else
            {
                SuspendLayout();

                switch (ChatModel.Type)
                {
                    case "image":
                        var imagemodel = ChatModel as ImageChatModel;
                        if (imagemodel.Image.Width < maxwidth + (Width - bodyPanel.Width))
                        {
                            bodyPanel.Width = imagemodel.Image.Width;

                            Height = imagemodel.Image.Height + (Height - bodyPanel.Height);
                        }
                        else
                        {
                            double ratio = (double)maxwidth / (double)imagemodel.Image.Width;
                            int adjheight = (int)(imagemodel.Image.Height * ratio);

                            bodyPanel.Width = maxwidth;
                            Height = adjheight + (Height - bodyPanel.Height);
                        }
                        break;
                    case "text":
                        var textmodel = ChatModel as TextChatModel;
                        string body = textmodel.Body;
                        TextChange(bodyTextBox.Text);
                        break;
                    case "attachment":
                        var attachmodel = ChatModel as AttachmentChatModel;
                        TextChange(bodyTextBox.Text);
                        break;
                    default:
                        break;
                }
            }

            ResumeLayout();

            void TextChange(string body)
            {
                int fontheight = bodyTextBox.Font.Height;
                var gfx = this.CreateGraphics();
                int lines = 1;
                double stringwidth = gfx.MeasureString(body, bodyTextBox.Font).Width;

                if (stringwidth < maxwidth + bodyPanel.Width - bodyTextBox.Width)
                {
                    bodyPanel.Width = (int)(stringwidth + bodyPanel.Width - bodyTextBox.Width + 5);
                }
                else
                {
                    lines = 0;
                    bodyPanel.Width = maxwidth + bodyPanel.Width - bodyTextBox.Width;
                    string noescapebody = body.Replace("\r\n", string.Empty).Replace("\r\n", string.Empty);
                    stringwidth = gfx.MeasureString(noescapebody, bodyTextBox.Font).Width;

                    while (stringwidth > 0)
                    {
                        stringwidth -= bodyPanel.Width;
                        lines++;
                    }
                }
                if (body.Contains("\n"))
                {
                    while (body.Contains("\r\n"))
                    {
                        body = body.Remove(body.IndexOf("\r\n"), "\r\n".Length);
                        lines++;
                    }
                    while (body.Contains("\n"))
                    {
                        body = body.Remove(body.IndexOf("\n"), "\n".Length);
                        lines++;
                    }
                }

                Height = (lines * fontheight) + Height - bodyTextBox.Height;
            }
        }

    }
}
