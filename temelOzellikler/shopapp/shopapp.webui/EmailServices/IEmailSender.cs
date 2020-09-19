using System.Threading.Tasks;

namespace shopapp.webui.EmailServices
{
    public interface IEmailSender
    {
         

        Task SendEmailAsync(string email,string subject, string htmlMessage);


    }
}