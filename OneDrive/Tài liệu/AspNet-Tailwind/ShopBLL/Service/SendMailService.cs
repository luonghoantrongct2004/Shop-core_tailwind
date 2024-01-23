using System;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Shop.BLL.Service.IServices;
using Shop.DAL.Entity.Mail;


public class SendMailService : ISendMailService
{
    private readonly MailSetting mailSettings;

    private readonly ILogger<SendMailService> logger;

    public SendMailService (IOptions<MailSetting> _mailSettings, ILogger<SendMailService> _logger) {
        mailSettings = _mailSettings.Value;
        logger = _logger;
        logger.LogInformation("Create SendMailService");
    }

   
    public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
       var message = new MimeMessage ();
        message.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
        message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
        message.To.Add (MailboxAddress.Parse (email));
        message.Subject = subject;


        var builder = new BodyBuilder();
        builder.HtmlBody = htmlMessage;
        message.Body = builder.ToMessageBody();

        // dùng SmtpClient của MailKit
        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try {
            smtp.Connect (mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate (mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(message);
        }
        
        catch (Exception ex) {
            // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
            System.IO.Directory.CreateDirectory("mailssave");
            var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
            await message.WriteToAsync(emailsavefile);

            logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
            logger.LogError(ex.Message);
        }

        smtp.Disconnect (true);

        logger.LogInformation("send mail to " + email);


    }

        public Task SendSmsAsync(string number, string message)
        {
            // Cài đặt dịch vụ gửi SMS 
            System.IO.Directory.CreateDirectory("smssave");
            var emailsavefile = string.Format(@"smssave/{0}-{1}.txt",number, Guid.NewGuid());
            System.IO.File.WriteAllTextAsync(emailsavefile, message);
            return Task.FromResult(0);
        }
}