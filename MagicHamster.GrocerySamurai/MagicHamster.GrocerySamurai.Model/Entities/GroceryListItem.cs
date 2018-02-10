namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using JetBrains.Annotations;

    [Table("grocery_list_item")]
    public class GroceryListItem : Entity
    {
        [Column("grocery_list_id")]
        [UsedImplicitly]
        public int GroceryListId { get; set; }

        [Column("item_id")]
        [UsedImplicitly]
        public int ItemId { get; set; }

        [Column("quantity")]
        [UsedImplicitly]
        public int Quantity { get; set; }

        [Column("package_type")]
        [MaxLength(30)]
        [Display(Name = "Package Type")]
        [UsedImplicitly]
        public string PackageType { get; set; }

        [Column("weight")]
        [UsedImplicitly]
        public int Weight { get; set; }

        [ForeignKey("GroceryListId")]
        [UsedImplicitly]
        public GroceryList GroceryList { get; set; }

        [ForeignKey("ItemId")]
        [UsedImplicitly]
        public Item Item { get; set; }
    }
}
