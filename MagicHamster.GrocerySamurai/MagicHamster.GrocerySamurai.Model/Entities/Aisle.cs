// ReSharper disable VirtualMemberCallInConstructor
namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using JetBrains.Annotations;

    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    [Table("aisle")]
    [UsedImplicitly]
    public class Aisle : UserFilter
    {
        public Aisle()
        {
            StoreItems = new HashSet<StoreItem>();
        }

        [Column("name")]
        [MaxLength(255)]
        [UsedImplicitly]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(1000)]
        [UsedImplicitly]
        public string Description { get; set; }

        [UsedImplicitly]
        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
