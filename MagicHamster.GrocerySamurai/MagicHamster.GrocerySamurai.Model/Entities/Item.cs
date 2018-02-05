// ReSharper disable VirtualMemberCallInConstructor
namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MagicHamster.GrocerySamurai.Model.Common;

    [Table("item")]
    public class Item : UserFilter
    {
        public Item()
        {
            GroceryListItems = new HashSet<GroceryListItem>();
            StoreItems = new HashSet<StoreItem>();
        }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Column("upc")]
        [Display(Name = "UPC")]
        public long Upc { get; set; }

        public virtual ICollection<GroceryListItem> GroceryListItems { get; set; }

        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
