namespace MagicHamster.GrocerySamurai.PresentationLayer.Services
{
    using System.Threading.Tasks;
    using JetBrains.Annotations;

    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    [UsedImplicitly]
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
