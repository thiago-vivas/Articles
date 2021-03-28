using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DesignPatternSOLID._2.O
{
    public class MailSender
    {

        public void SendMail(string subject, string body, string recipient)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("email", "password"),
                EnableSsl = true,
            };

            //validate recipient's domain
            if (!recipient.ToString().EndsWith("@thiago.com"))
            {
                Console.WriteLine("Mail destinatary not in the domain");
                return;
            }

            //validate body
            if (string.IsNullOrEmpty(body))
            {
                Console.WriteLine("Mail body is empty.");
                return;
            }

            smtpClient.SendAsync("thiago@thiago.com", recipient, subject, body, null);
        }
    }

}
