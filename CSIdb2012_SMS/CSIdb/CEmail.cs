using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CSIdb
{
   public static class CEmail
    {
        public static bool SendEmail(string[] ToList, string From, string Subject, string Message, bool htmlFlag=false)
        {
            bool SentOK = false;
            int ilen = ToList.Length;
            if (ilen == 0)
            {
                return SentOK;
            }


            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("CSI_NoReply@controlsysinc.com");
                for(int i=0; i<ilen; i++)
                message.To.Add(new MailAddress(ToList[i]+"@controlsysinc.com"));
                // message.To.Add(new MailAddress("jtgreer@controlsysinc.com"));

                message.Subject = Subject;
                message.IsBodyHtml = htmlFlag; //to make message body as html  
                message.Body = Message;
                smtp.Port = 25; //SSL 465; //TLS 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("CSI_NoReply@controlsysinc.com", "6013558594");

                //   Mail Server DNS = relay-hosting.secureserver.net
                //    Mail Server TCP Port = 25
                //  smtp.DeliveryMethod = SmtpDeliveryFormat.SevenBit;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                SentOK = true;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                SentOK = false;
                string error = ex.ToString();
                
                 //  MessageBox.Show(error);
            }


            return SentOK;
        }

        public static void SendEmailwithAttachment(string to, string from, string subject, string body, Attachment filename)
        {
            using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = subject;
                mm.Body = body;
               
                //if (postedFile.ContentLength > 0)
                //{
                //    string fileName = Path.GetFileName(filename);
                //    mm.Attachments.Add(new Attachment(postedFile.InputStream, fileName));
                //}
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("CSI_NoReply@controlsysinc.com", "6013558594");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                try
                {
                    smtp.Send(mm);
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                }
            }
        } // End send email
    }
}
