using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicHamster.GrocerySamurai.Model
{
    public class GroceryDbContext : DbContext
    {
        public virtual DbSet<Aisle> Aisles { get; set; }

        public virtual DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<GroceryList> GroceryLists { get; set; }

        public virtual DbSet<GroceryListItem> GroceryListItems { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<StoreItem> StoreItems { get; set; }
    }
}
