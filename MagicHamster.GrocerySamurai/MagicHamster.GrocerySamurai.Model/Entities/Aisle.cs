using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagicHamster.GrocerySamurai.Model.Common;
// ReSharper disable VirtualMemberCallInConstructor

namespace MagicHamster.GrocerySamurai.Model.Entities
{
    [Table("aisle")]
    public class Aisle : UserFilter
    {
        public Aisle()
        {
            StoreItems = new HashSet<StoreItem>();
        }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
