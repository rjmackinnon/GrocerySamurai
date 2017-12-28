using System.ComponentModel.DataAnnotations;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
