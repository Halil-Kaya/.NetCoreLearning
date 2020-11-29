using System.Net.Mail;

namespace identityLearning.Helper
{
    public static class PasswordReset
    {

        public static void PasswordResetSendEmail(string link){

            MailMessage mail = new MailMessage();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;

            mail.From = new MailAddress("hibrahimkayahik@gmail.com");
            
            mail.To.Add("halilibrahim.kaya@stu.fsm.edu.tr");

            mail.Subject = $"www.bidibidi.com::Şifre Sıfırlama";
            mail.Body = "<h2>Şifrenizi Yenilemek için lütfen aşağıdaki linke tıklayınız</h2><hr/>";
            mail.Body += $"<a href='{link}'>şifre yenileme linki</a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("hibrahimkayahik@gmail.com","74859623g!");

            smtpClient.Send(mail);




        }
        
    }
}