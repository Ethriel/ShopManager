using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopManager.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.Database
{
    public class ShopDbContext : DbContext
    {
        public virtual IConfiguration Configuration { get; set; }
        public DbSet<ShopClient> ShopClients { get; set; }
        public DbSet<ShopProductCategory> ProductCategories { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<ShopPurchase> ShopPurchases { get; set; }
        public ShopDbContext() { }
        public ShopDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
            }
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopClient>()
                        .HasMany(c => c.Purchases)
                        .WithOne(sp => sp.Client)
                        .HasForeignKey(sp => sp.ClientId)
                        .IsRequired();

            modelBuilder.Entity<ShopProductCategory>()
                        .HasMany(c => c.Products)
                        .WithOne(p => p.Category)
                        .HasForeignKey(p => p.CategoryId)
                        .IsRequired();

            modelBuilder.Entity<ShopPurchase>()
                        .HasMany(sp => sp.Products)
                        .WithMany(p => p.Purchases);

            base.OnModelCreating(modelBuilder);
        }
    }
}
