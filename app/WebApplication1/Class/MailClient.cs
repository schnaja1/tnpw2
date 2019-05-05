using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApplication1.Class
{
    public static class MailClient
    {
        // email a heslo 
        //tnpw2testemail@seznam.cz password
        //tnpw2testmail@gmail.com passtheword

        public static void sendMail(string to, string subject, string body)
        {
            string from = "tnpw2testmail@gmail.com";
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, "passtheword");
            smtp.Timeout = 20000;

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;

            smtp.Send(mail);
        }
    }
}