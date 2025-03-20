using Rheem.Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;
using Rheem.Inventory.Api.Models;
using System.Collections.Generic;
using Rheem.Inventory.Api.Models;

namespace Rheem.Inventory.Api.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>()
                .HasKey(i => i.InventoryID); // Ensure EF recognizes the primary key

            base.OnModelCreating(modelBuilder);
        }
    }
}