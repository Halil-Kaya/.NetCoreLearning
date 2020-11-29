using System.Threading.Tasks;

namespace identityLearning.EmailServices
{
    public interface IEmailSender
    {
        
        Task SendEmailAsync(string email,string subject, string htmlMessage);

    }
}