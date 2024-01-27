namespace ShopDataAccess.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ShopDataAccess.Entity.Blog;
using ShopDataAccess.Entity.Order;
using ShopDataAccess.Entity.Pay;
using ShopDataAccess.Entity.Product;

public class ShopDbContext:IdentityDbContext<ShopUser> 
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        // Bỏ tiền tố AspNet của các bảng: mặc định
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        builder.Entity<ProductImage>()
            .HasOne(p => p.Product)
            .WithOne(p => p.ProductImage)
            .HasForeignKey<ProductImage>(p => p.ProductId)  // Xác định ProductImage là phía phụ thuộc
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductVideo>()
            .HasOne(p => p.Product)
            .WithOne(p => p.ProductVideo)
            .HasForeignKey<ProductVideo>(p => p.ProductId)  // Xác định ProductVideo là phía phụ thuộc
            .OnDelete(DeleteBehavior.Cascade);
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=Shopping;User Id=sa;Password=trong225;MultipleActiveResultSets=true;TrustServerCertificate=True;");

            return new ShopDbContext(optionsBuilder.Options);
        }
    }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ShopDataAccess.Entity.Brand.Brand> Brands { get; set; }
        public DbSet<ShopDataAccess.Entity.Order.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<TransactionPay> Transactions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ShopDataAccess.Entity.Product.Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVideo> ProductVideos { get; set; }
        public DbSet<ShopDataAccess.Entity.Shipping.Shipping> Shippings { get; set; }
}
