namespace MagicHamster.GrocerySamurai.PresentationLayer.Services
{
    using System.Threading.Tasks;
    using JetBrains.Annotations;

    public interface IEmailSender
    {
        Task SendEmailAsync([UsedImplicitly] string email, string subject, string message);
    }
}
