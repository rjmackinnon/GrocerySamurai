namespace MagicHamster.GrocerySamurai.PresentationLayer.Models
{
    using JetBrains.Annotations;

    public class DeleteConfirm
    {
        [UsedImplicitly]
        public string Name { get; set; }

        public string Type { get; set; }

        [UsedImplicitly]
        public string AdditionalText { get; set; }
    }
}