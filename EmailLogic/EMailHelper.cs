using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace OnlineAdmissionSystem.EmailLogic
{
    public class EMailHelper : IEMailHelper
    {
        string smtpAddress;
        int portNumber;
        bool enableSSL;
        string emailFromAddress;
        string emailToAddress;
        string subject;
        string password;
        string body;

        public EMailHelper()
        {
             smtpAddress = "smtp.live.com";
             portNumber = 587;
             enableSSL = true;
             emailFromAddress = "naveen.nrb@hotmail.com"; //Sender Email Address  
             password = "dnbP@55w0rd"; //Sender Password  
             emailToAddress = "naveen.aimit.2010@gmail.com"; //Receiver Email Address  
             subject = "Hello";
             body = "Hello, This is Email sending test using gmail.";

        }
        public bool SendEmail(string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(this.emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
                return false;
            }
        }
    }
}