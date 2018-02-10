namespace MagicHamster.GrocerySamurai.Model
{
    using Entities;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class GroceryContext : DbContext
    {
        public GroceryContext(DbContextOptions options)
            : base(options)
        {
        }

        [UsedImplicitly]
        public virtual DbSet<Aisle> Aisles { get; set; }

        [UsedImplicitly]
        public virtual DbSet<GroceryList> GroceryLists { get; set; }

        [UsedImplicitly]
        public virtual DbSet<GroceryListItem> GroceryListItems { get; set; }

        [UsedImplicitly]
        public virtual DbSet<Item> Items { get; set; }

        [UsedImplicitly]
        public virtual DbSet<Store> Stores { get; set; }

        [UsedImplicitly]
        public virtual DbSet<StoreItem> StoreItems { get; set; }
    }
}
