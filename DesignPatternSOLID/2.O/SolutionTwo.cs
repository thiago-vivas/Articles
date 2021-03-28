using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Linq;

namespace DesignPatternSOLID._2.O
{
    public class MailClass
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
    }

    public interface IValidation<T>
    {
        bool Validate(T mail);
    }


    public class DomainValidation : IValidation<MailClass>
    {
        public bool Validate(MailClass mail)
        {
            if (mail.Recipient.ToString().EndsWith("@thiago.com"))
                return false;

            return true;
        }
    }
    public class BodyValidation : IValidation<MailClass>
    {
        public bool Validate(MailClass mail)
        {
            if (string.IsNullOrEmpty(mail.Body))
                return false;

            return true;
        }
    }

    public class Main
    {
        public void SendMail(MailClass mailClass, List<IValidation<MailClass>> validations)
        {
            List<bool> validationsResult = new List<bool>();
            validations.ForEach(x => validationsResult.Add(x.Validate(mailClass)));

            if (!validationsResult.Any(x => !x))
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("email", "password"),
                    EnableSsl = true,
                };

                smtpClient.SendAsync("thiago@thiago.com", mailClass.Recipient, mailClass.Subject, mailClass.Body, null);
            };
        }
    }
}
