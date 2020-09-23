using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Models.Helps;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository.Interfaces
{
    public interface IGmailEmailService //: IRepository<SmtpConfigurationsModels>
    {
        SmtpConfigurationsModels SmtpConfiguration { get; }
        bool SendEmailMessage(EmailMessage message);
        Task<bool> SendEmailMessageAsync(EmailMessage message);
        Task<bool> SendEmailMessageAsync(EmailMessage message, string UserName, string Password);
        //Task<bool> OriginalData();
    }
}
