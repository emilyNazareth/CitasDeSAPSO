using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CitasSAPSO.Models
{
    public class MailModels
    {
        private string From;
        private string To;
        private string Message;
        private string Subject;
        private int Files;
        private string DE = "DAVID.ALVARADOELIZONDO@ucr.ac.cr";
        private string PASS = "Maythe4bwy.";


        public string error = "";

        public MailModels(string FROM, string TO, string Message, string Subject, int files)
        {
            this.From = FROM;
            this.To = TO;
            this.Message = Message;
            this.Subject = Subject;
            this.Files = files;

        }

        public bool SendMail()
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.ucr.ac.cr");

                mail.From = new MailAddress(this.From);
                mail.To.Add(this.To);
                mail.Subject = this.Subject;
                mail.Body = this.Message;

                if(this.Files == 1)
                {
                    string file = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/img/FO102621.png");
                    Attachment data = new Attachment(file);
                    mail.Attachments.Add(data);
                }else if(this.Files == 2)
                {
                    string file = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/img/FO102633.png");
                    Attachment data = new Attachment(file);
                    mail.Attachments.Add(data);
                }
                


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(this.DE, this.PASS);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error: " + ex.Message;
            }

            return false;

        }

    }
}