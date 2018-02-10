namespace MagicHamster.GrocerySamurai.PresentationLayer.Models.ManageViewModels
{
    using JetBrains.Annotations;

    public class RemoveLoginViewModel
    {
        [UsedImplicitly]
        public string LoginProvider { get; set; }

        [UsedImplicitly]
        public string ProviderKey { get; set; }
    }
}
