using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Models.Helps;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository
{
    public class GmailEmailServiceRepository : IGmailEmailService
    {
        private readonly BiblioteContext biblioteContext;
        public SmtpConfigurationsModels SmtpConfiguration => this.biblioteContext.SmtpConfigurationsModels.AsNoTracking().FirstOrDefault();
        public GmailEmailServiceRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        //public async Task<bool> OriginalData()
        //{
        //    if (await this.ExistAsync())
        //        return await this.CreateAsync(DataLocal());
        //    else
        //        return false;
        //}
        private SmtpConfigurationsModels DataLocal()
        {
            // Departamento
            return new SmtpConfigurationsModels
            {
                Activo = true,
                Hora1 = DateTime.Now.TimeOfDay,
                Hora2 = DateTime.Now.TimeOfDay,
                Host = "smtp.gmail.com",
                Password = "junior1123",
                Port = 587,
                Ssl = true,
                MailSender = "assoft2018@gmail.com"
            };
        }
        public bool SendEmailMessage(EmailMessage message)
        {
            if (SmtpConfiguration == null)
            {
                return false;
            }

            var success = false;
            var smtp = new SmtpClient
            {
                Host = SmtpConfiguration.Host,
                Port = SmtpConfiguration.Port,
                EnableSsl = SmtpConfiguration.Ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SmtpConfiguration.MailSender, SmtpConfiguration.Password)
            };
            smtp.SendCompleted += (s, e) =>
            {
                // após o envio pode chamar o Dispose
                smtp.Dispose();
            };
            using (var smtMessge = new MailMessage(SmtpConfiguration.MailSender, message.ToEmail))
            {
                smtMessge.Subject = message.Subject;
                smtMessge.Body = message.Body;
                smtMessge.IsBodyHtml = message.IsHtml;
                if (message.filenames.Count > 0)
                {
                    foreach (var item in message.filenames)
                        smtMessge.Attachments.Add(new Attachment(item.ToString()));
                }
                smtp.Send(smtMessge);

                success = true;
            }
            return success;
        }
        public async Task<bool> SendEmailMessageAsync(EmailMessage message)
        {
            if (SmtpConfiguration == null)
            {
                return false;
            }
            var success = false;

            var smtp = new SmtpClient
            {
                Host = SmtpConfiguration.Host,
                Port = SmtpConfiguration.Port,
                EnableSsl = SmtpConfiguration.Ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SmtpConfiguration.MailSender, SmtpConfiguration.Password)
            };
            smtp.SendCompleted += (s, e) =>
            {
                // após o envio pode chamar o Dispose
                smtp.Dispose();
            };
            using (var smtMessge = new MailMessage(SmtpConfiguration.MailSender, message.ToEmail))
            {
                smtMessge.Subject = message.Subject;
                smtMessge.Body = message.Body;
                smtMessge.IsBodyHtml = message.IsHtml;
                if (message.filenames.Count > 0)
                {
                    foreach (var item in message.filenames)
                        smtMessge.Attachments.Add(new Attachment(item.ToString()));
                }
                await smtp.SendMailAsync(smtMessge);

                success = true;
            }
            return success;
        }
        public async Task<bool> SendEmailMessageAsync(EmailMessage
                                                      message,
                                                      string UserName,
                                                      string Password)
        {
            if (SmtpConfiguration == null)
            {
                return false;
            }
            var success = false;

            var smtp = new SmtpClient
            {
                Host = SmtpConfiguration.Host,
                Port = SmtpConfiguration.Port,
                EnableSsl = SmtpConfiguration.Ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(UserName, Password)
            };
            smtp.SendCompleted += (s, e) =>
            {
                // após o envio pode chamar o Dispose
                smtp.Dispose();
            };
            using (var smtMessge = new MailMessage(SmtpConfiguration.MailSender, message.ToEmail))
            {
                smtMessge.Subject = message.Subject;
                smtMessge.Body = message.Body;
                smtMessge.IsBodyHtml = message.IsHtml;
                if (message.filenames.Count > 0)
                {
                    foreach (var item in message.filenames)
                        smtMessge.Attachments.Add(new Attachment(item.ToString()));
                }
                await smtp.SendMailAsync(smtMessge);

                success = true;
            }
            return success;
        }
    }
}
