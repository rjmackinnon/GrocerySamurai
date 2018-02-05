// ReSharper disable VirtualMemberCallInConstructor
namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MagicHamster.GrocerySamurai.Model.Common;

    [Table("grocery_list")]
    public class GroceryList : Entity
    {
        public GroceryList()
        {
            GroceryListItems = new HashSet<GroceryListItem>();
        }

        [Column("store_id")]
        public int StoreId { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        public virtual ICollection<GroceryListItem> GroceryListItems { get; set; }
    }
}
