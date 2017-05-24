using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using MailKit;

namespace FormData
{
    enum MessageType
    {
        Unknown,
        Message,
        Newsletter
    }

    class Message : IComparable<Message>, IEquatable<Message>
    {
        static readonly Regex trimmer = new Regex(@"\s+");
        private List<string> lines = new List<string>();

        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Age { get; private set; }
        public string Size { get; private set; }
        public string Body { get; private set; }
        public UniqueId UniqueId { get; private set; }
        public MessageType Type { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Message(UniqueId id, string bodyText, DateTime date)
        {
            lines = new List<string>();
            this.UniqueId = id;
            this.Date = date;
            this.Type = MessageType.Unknown;
            ProcessBody(bodyText);
        }

        public int CompareTo(Message m)
        {
            return this.Email.CompareTo(m.Email);
        }

        public bool Equals(Message m)
        {
            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(m, null)) return false;

            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, m)) return true;

            //Check whether the products' properties are equal. 
            return Email.Equals(m.Email) && Name.Equals(m.Name);
        }

        public override int GetHashCode()
        {
            //Get hash code for the Name field if it is not null. 
            int hashMessageName = Name == null ? 0 : Name.GetHashCode();

            //Get hash code for the Email field. 
            int hashMessageEmail = Email.GetHashCode();

            //Calculate the hash code for the product. 
            return hashMessageName ^ hashMessageEmail;
        }
        public override string ToString()
        {
            if (Name != null)
            {
                return Name;
            }
            else
            {
                return "Empty Message";
            }
        }

        private void ProcessBody(string bodyText)
        {
            using (var reader = new StringReader(bodyText))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                RemoveJunkFields();

                string MsgType = GetMessageField("data_name");
                switch (MsgType)
                {
                    case "contact-form.xlsx":
                        AddContactForm();
                        break;
                    case "newsletter-signup.xls":
                        AddNewsLetter();
                        break;
                    default:
                        Debug.Print(MsgType);
                        Type = MessageType.Unknown;
                        break;
                }
            }
        }

        private void AddNewsLetter()
        {
            Type = MessageType.Newsletter;

            FirstName = GetMessageField("first_name");
            LastName = GetMessageField("last_name");
            Name = this.FirstName + " " + this.LastName;
            Email = GetMessageField("email");
            Size = GetMessageField("customer_size");
        }

        private void AddContactForm()
        {

            Type = MessageType.Message;

            Age = GetMessageField("customer_age");
            Email = GetMessageField("customer_email");
            Phone = GetMessageField("customer_phone");
            Size = GetMessageField("customer_size");

            //Name = trimmer.Replace(GetMessageField("customer_name"), " ");
            Name = GetMessageField("customer_name");

            string[] s = Name.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);
            FirstName = s[0];
            LastName = String.Join(" ", s.Skip(1).ToArray());

            // Should only have the customer_message left...
            int index = lines.FindIndex(item => item.StartsWith("customer_message"));
            if (index != -1)
            {
                string[] substrings = lines[index].Split('=');
                lines.RemoveAt(index);

                StringBuilder sbBody = new StringBuilder(substrings[1].Trim(), 2000);
                foreach (string l in lines)
                {
                    sbBody.AppendLine(l.Trim());
                }
                Body = sbBody.ToString();
            }
        }

        private string GetMessageField(string field)
        {
            string value = "";

            int index = lines.FindIndex(item => item.StartsWith(field));
            if(index != -1)
            {
                string[] substrings = lines[index].Split('=');
                lines.RemoveAt(index);
                value = WebUtility.HtmlDecode(substrings[1].Trim());
            }
            return value;
        }

        private void RemoveJunkFields()
        {
            string[] junk = { "form_checked =", "thanks_url =", "customer_number =", "submit =", "IP:" };
            foreach(string j in junk)
            {
                int index = lines.FindIndex(item => item.StartsWith(j));
                if (index != -1)
                {
                    lines.RemoveAt(index);
                }
            }
        }

        public string GetLine()
        {
            return String.Format("{0},{1},{2}", Email, FirstName, LastName);
        }
    }

    class MessageCompareByName : IComparer<Message>
    {
        public int Compare(Message a, Message b)
        {
            return a.LastName.CompareTo(b.LastName);
        }
    }
}
