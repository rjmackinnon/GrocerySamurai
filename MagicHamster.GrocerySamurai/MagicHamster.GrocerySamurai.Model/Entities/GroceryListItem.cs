namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MagicHamster.GrocerySamurai.Model.Common;

    [Table("grocery_list_item")]
    public class GroceryListItem : Entity
    {
        [Column("grocery_list_id")]
        public int GroceryListId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("package_type")]
        [MaxLength(30)]
        [Display(Name = "Package Type")]
        public string PackageType { get; set; }

        [Column("weight")]
        public int Weight { get; set; }

        [ForeignKey("GroceryListId")]
        public GroceryList GroceryList { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
