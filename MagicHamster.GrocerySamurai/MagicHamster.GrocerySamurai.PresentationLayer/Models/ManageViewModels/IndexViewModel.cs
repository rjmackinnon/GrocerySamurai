namespace MagicHamster.GrocerySamurai.PresentationLayer.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    using JetBrains.Annotations;

    public class IndexViewModel
    {
        [UsedImplicitly]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
