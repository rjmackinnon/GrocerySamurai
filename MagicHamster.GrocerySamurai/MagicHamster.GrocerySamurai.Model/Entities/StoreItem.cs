using System.ComponentModel.DataAnnotations.Schema;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.Model.Entities
{
    [Table("store_item")]
    public class StoreItem : Entity
    {
        [Column("store_id")]
        public int StoreId { get; set; }

        [Column("aisle_id")]
        public int AisleId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        
        [ForeignKey("AisleId")]
        public Aisle Aisle { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
