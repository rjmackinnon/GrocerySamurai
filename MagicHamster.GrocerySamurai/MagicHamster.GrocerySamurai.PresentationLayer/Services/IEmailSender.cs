using System.Threading.Tasks;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
