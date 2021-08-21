namespace CryptoStore.Services.EmailService
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks; 

    public class SendGridEmailService : IEmailSender
    {
        private SendGridOptions options;
        public SendGridEmailService(IOptions<SendGridOptions> options)
            => this.options = options.Value;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(this.options.SendGridApiKey);
            var from = new EmailAddress("cryptoFuture@gmail.com", "CryptoFuture");  
            var to = new EmailAddress(email, email); 
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false); 
        }
    }
}
