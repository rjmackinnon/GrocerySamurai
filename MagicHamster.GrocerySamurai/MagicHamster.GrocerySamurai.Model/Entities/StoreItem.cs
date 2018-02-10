namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using JetBrains.Annotations;

    [Table("store_item")]
    public class StoreItem : Entity
    {
        [Column("store_id")]
        [UsedImplicitly]
        public int StoreId { get; set; }

        [Column("aisle_id")]
        [UsedImplicitly]
        public int AisleId { get; set; }

        [Column("item_id")]
        [UsedImplicitly]
        public int ItemId { get; set; }

        [ForeignKey("StoreId")]
        [UsedImplicitly]
        public Store Store { get; set; }

        [ForeignKey("AisleId")]
        [UsedImplicitly]
        public Aisle Aisle { get; set; }

        [ForeignKey("ItemId")]
        [UsedImplicitly]
        public Item Item { get; set; }
    }
}
