using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace identityLearning.TwoFactorService
{
    public class EmailSender
    {

        private readonly TwoFactorOptions _twoFactorOptions;

        private readonly TwoFactorService _twoFactorService;

        public EmailSender(IOptions<TwoFactorOptions> options,TwoFactorService twoFactorService){

            this._twoFactorOptions = options.Value;
            this._twoFactorService = twoFactorService;

        }

        public string Send(string EmailAddress){
            string code = _twoFactorService.GetCodeVerification().ToString();

            Execute(EmailAddress,code).Wait();

            return code;
        }

        private async Task Execute(string email, string code)
        {
            var client = new SendGridClient(_twoFactorOptions.SendGrid_ApiKey);
            var from = new EmailAddress("hibrahimkayahik@gmail.com");
            var subject = "İki Adımlı Kimlik Doğrulama Kodunuz";
            var to = new EmailAddress(email);
            var htmlContent = $"<h2>Siteye giriş yapabilmek için  doğrulama kodunuz aşağıdadır.</h2><h3>Kodunuz:{code}</h3>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}