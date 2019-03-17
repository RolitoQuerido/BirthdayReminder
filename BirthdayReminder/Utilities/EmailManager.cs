using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BirthdayReminder.Utilities
{
    public class EmailManager
    {
        public EmailManager()
        {

        }

        public void SendBirthdayEmail(string body)
        {
            var from = ConfigurationManager.AppSettings["emailFrom"];
            var to = ConfigurationManager.AppSettings["emailTo"];
            var subject = ConfigurationManager.AppSettings["emailSubject"];

            var client = new SmtpClient("smtp.office365.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, ConfigurationManager.AppSettings["emailPassword"]),
                EnableSsl = true
            };

            var mail = new MailMessage(from, to, subject, body);
            client.Send(mail);
        }
    }
}
