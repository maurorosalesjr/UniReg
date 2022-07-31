using System;

namespace UniReg.Models
{
    public class UniRegContext : DbContext
    {
        // public DbSet<Category> Categories { get; set; }
        // public DbSet<Item> Items { get; set; }
        // public DbSet<CategoryItem> CategoryItem { get; set; }

        public UniRegContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
