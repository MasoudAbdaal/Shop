using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Shop.Constants;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;
using static Shop.Models.VerificationMethod;

namespace Shop.Data
{
  public class MainContext : DbContext
  {
    private readonly IConfiguration _configuration;
    private readonly DbContextOptions<MainContext> _options;

    public MainContext(DbContextOptions<MainContext> options, IConfiguration configuration) : base(options)
    {
      _configuration = configuration;
      _options = options;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserReview> User_Reviews => Set<UserReview>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserInfo> User_Info => Set<UserInfo>();
    public DbSet<UserAddress> User_Addressess => Set<UserAddress>();
    public DbSet<UserAuthMethod> User_AuthMethods => Set<UserAuthMethod>();
    public DbSet<UserVerificationMethod> User_VerificationMethods => Set<UserVerificationMethod>();

    public DbSet<Address> Address => Set<Address>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<AuthProvider> AuthProviders => Set<AuthProvider>();
    public DbSet<VerificationMethod> VerificationMethods => Set<VerificationMethod>();


    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentType> Payment_Types => Set<PaymentType>();


    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> Order_Lines => Set<OrderLine>();
    public DbSet<OrderStatus> Order_Status => Set<OrderStatus>();
    public DbSet<OrderShippingMethod> Order_Shipping_Methods => Set<OrderShippingMethod>();


    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> Cart_Items => Set<CartItem>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Product_Categories => Set<Category>();
    public DbSet<Promotion> Promotions => Set<Promotion>();
    public DbSet<ProductConf> Product_Conf => Set<ProductConf>();
    public DbSet<ProductItem> Product_Items => Set<ProductItem>();
    public DbSet<Variation> Product_Variations => Set<Variation>();
    public DbSet<VariationOption> Product_VariationOptions => Set<VariationOption>();
    public DbSet<Description> Product_Descriptions => Set<Description>();
    public DbSet<PromotionCategories> Product_Categories_Promotions => Set<PromotionCategories>();
    public DbSet<PromotionProducts> Product_Items_Promotions => Set<PromotionProducts>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString")
      , x => x.UseNetTopologySuite()
      );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserAuthMethod>().HasKey(x => new { x.UserID, x.AuthProviderID });
      modelBuilder.Entity<UserVerificationMethod>().HasKey(x => new { x.UserID, x.VerificationMethodID });
      modelBuilder.Entity<UserAddress>().HasKey(x => new { x.UserID, x.AddressID });
      modelBuilder.Entity<PromotionCategories>().HasKey(x => new { x.CategoryID, x.PromotionID });
      modelBuilder.Entity<ProductConf>().HasKey(x => new { x.ProductItemID, x.VariationOptionID });
      modelBuilder.Entity<PromotionProducts>().HasKey(x => new { x.ProductItemID, x.PromotionID });


      modelBuilder.Entity<Role>().HasData(
        Enum.GetValues(typeof(UserRoles))
          .Cast<UserRoles>().Select(u => new Role()
          {
            ID = u,
            Name = u.ToString(),
          }));


      modelBuilder.Entity<AuthProvider>().HasData(
        Enum.GetValues(typeof(Providers))
        .Cast<Providers>().Select(u => new AuthProvider()
        {
          ID = u,
          Name = u.ToString()
        }));

      modelBuilder.Entity<VerificationMethod>().HasData(
        Enum.GetValues(typeof(VerifyMethods))
        .Cast<VerifyMethods>().Select(u => new VerificationMethod()
        {
          ID = u,
          Name = u.ToString()
        }));
    }
  }
}