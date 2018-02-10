// ReSharper disable VirtualMemberCallInConstructor
namespace MagicHamster.GrocerySamurai.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using JetBrains.Annotations;

    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    [Table("store")]
    [UsedImplicitly]
    public class Store : UserFilter
    {
        public Store()
        {
            StoreItems = new HashSet<StoreItem>();
        }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [UsedImplicitly]
        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
