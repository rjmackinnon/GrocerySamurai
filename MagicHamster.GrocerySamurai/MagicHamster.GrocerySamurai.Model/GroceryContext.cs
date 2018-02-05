namespace MagicHamster.GrocerySamurai.Model
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class GroceryContext : DbContext
    {
        public GroceryContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Aisle> Aisles { get; set; }

        public virtual DbSet<GroceryList> GroceryLists { get; set; }

        public virtual DbSet<GroceryListItem> GroceryListItems { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<StoreItem> StoreItems { get; set; }
    }
}
