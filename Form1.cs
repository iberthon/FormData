using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FormData
{
    public partial class Form1 : Form
    {
        private List<Message> messages;
        private CheckBox ChkMsg;
        private CheckBox ChkNews;
        private int SplitterDistanceMax;

        public Form1()
        {
            InitializeComponent();

            // Initialise using the width of the scroll bar
            SplitterDistanceMax = 20;

            messages = new List<Message>();

            ChkMsg = new CheckBox()
            {
                Checked = true,
            };

            ChkNews = new CheckBox()
            {
                Checked = true
            };
        }

        private void GetMessages()
        {
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string server = ConfigurationManager.AppSettings["server"];

            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(server, 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(username, password);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                StatusLabelCount.Text = String.Format("{0} Message{1} / {2} Recent", inbox.Count, inbox.Count != 1 ? "s" : "", inbox.Recent);

                foreach (var s in inbox.Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId))
                {
                    string bodyText = "";

                    if (s.TextBody != null)
                    {
                        var body = inbox.GetBodyPart(s.UniqueId, s.TextBody);
                        bodyText = body.ToString();
                    }

                    if (s.HtmlBody != null)
                    {
                        var body = inbox.GetBodyPart(s.UniqueId, s.HtmlBody);
                        bodyText = body.ToString();
                    }

                    Message msg = new Message(s.UniqueId, bodyText, s.Date.DateTime);
                    messages.Add(msg);
                }
                client.Disconnect(true);

                Debug.Print(String.Format("1. MessageGrid Width={0}", MessageGrid.Width));

                // Need to use a BindingSource if list can be updated outside of grid... http://stackoverflow.com/questions/16695885/binding-listt-to-datagridview-in-winform
                MessageGrid.DataSource = messages;

                MessageGrid.Columns["Body"].Visible = false;
                MessageGrid.Columns["FirstName"].Visible = false;
                MessageGrid.Columns["LastName"].Visible = false;
                MessageGrid.Columns["Type"].Visible = false;
                MessageGrid.Columns["UniqueId"].Visible = false;

                foreach(DataGridViewColumn c in MessageGrid.Columns)
                {
                    if(c.Visible == true)
                    {
                        SplitterDistanceMax += c.Width;
                    }
                }
                splitContainer1.SplitterDistance = SplitterDistanceMax;

                var MsgCount = messages.Count(n => n.Type == MessageType.Message);
                var NewsCount = messages.Count(n => n.Type == MessageType.Newsletter);

                ChkMsg.Text = String.Format("{0} Message{1}", MsgCount, MsgCount != 1 ? "s" : "");
                ToolStripControlHost ChkMessages = new ToolStripControlHost(ChkMsg);
                statusStrip1.Items.Insert(2, ChkMessages);

                ChkNews.Text = String.Format("{0} Newsletter{1}", NewsCount, NewsCount != 1 ? "s" : "");
                ToolStripControlHost ChkNewsLetters = new ToolStripControlHost(ChkNews);
                statusStrip1.Items.Insert(3, ChkNewsLetters);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMessages();
        }

        private void MessageGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Message msg = messages[e.RowIndex];

            if (msg.Type == MessageType.Message)
            {
                richTextBox1.Text = String.Format("{0}", msg.Body);
            }
            else
            {
                richTextBox1.Text = "Newsletter Signup - message is blank";
            }

        }

        private void MessageGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in MessageGrid.Rows)
            {
                Message msg = messages[r.Index];

                if (msg.Type == MessageType.Newsletter)
                {
                    r.DefaultCellStyle.BackColor = System.Drawing.Color.SandyBrown;
                }
            }

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "CSV File|*.csv|Text File|*.txt",
                Title = "Export Data For MailChimp",
                FileName = "MailChimp.csv"
            };
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                var MessageList = messages.Where(n => n.Type == MessageType.Message).ToList();
                var NewsList = messages.Where(n => n.Type == MessageType.Newsletter).ToList();
                var ExportList = new List<Message>();

                if (ChkMsg.Checked == true)
                {
                    ExportList.AddRange(MessageList);
                }
                if (ChkNews.Checked == true)
                {
                    ExportList.AddRange(NewsList);
                }

                if (ExportList.Count() > 0)
                {
                    StatusProgress1.Maximum = ExportList.Count();
                    StatusProgress1.Value = 0;

                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        foreach (Message m in ExportList.Distinct())
                        {
                            writer.WriteLine(m.GetLine());
                            StatusProgress1.PerformStep();
                        }
                    }

                    //StatusProgress1.Value = 0;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string server = ConfigurationManager.AppSettings["server"];

            MessageBox.Show("This isn't working right now...", "Sorry!", MessageBoxButtons.OK);

            /*
                        Message m = messages[MessageGrid.CurrentRow.Index];

                        Debug.Print(String.Format("Selected Row: {0} - {1} {2}", MessageGrid.CurrentRow.Index, m.UniqueId, m.Email));

                        using (var client = new ImapClient())
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, e1) => true;
                            client.Connect(server, 993, true);
                            client.AuthenticationMechanisms.Remove("XOAUTH2");
                            client.Authenticate(username, password);

                            var inbox = client.Inbox;
                            inbox.Open(FolderAccess.ReadWrite);

                            inbox.AddFlags(m.UniqueId, MessageFlags.Deleted, true);
                            if (client.Capabilities.HasFlag(ImapCapabilities.UidPlus))
                            {
                                client.Inbox.Expunge(new UniqueId[] { m.UniqueId });
                            }
                            else
                            {
                                client.Inbox.Expunge();
                            }

                            client.Disconnect(true);
                        }
              */
        }

        private void BtnReply_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This isn't working right now...", "Sorry!", MessageBoxButtons.OK);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // prevent the splitter being moved - it's positioned to show all the visible columns in the grid
            splitContainer1.SplitterDistance = SplitterDistanceMax;
        }
    }
}
