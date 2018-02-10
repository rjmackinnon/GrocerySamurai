namespace MagicHamster.GrocerySamurai.PresentationLayer.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    using JetBrains.Annotations;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        [UsedImplicitly]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [UsedImplicitly]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [UsedImplicitly]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
