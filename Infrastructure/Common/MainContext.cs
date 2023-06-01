using System.Collections.ObjectModel;
using Domain.Entities.Address;
using Domain.Entities.Auth;
using Domain.Entities.Cart;
using Domain.Entities.Order;
using Domain.Entities.Payment;
using Domain.Entities.Product;
using Domain.Entities.User;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shop.RepoConfigurations;

namespace Infrastructure.Context
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfigurationRoot Configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetParent("./")!.FullName)
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
       .Build();


            optionsBuilder
            .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
            .UseSqlServer(Configuration.GetValue<string>("Database:ConnectionString"),
             x => x.UseNetTopologySuite()
            );

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfiguration(new AuthProviderConfigurations());
        //     modelBuilder.ApplyConfiguration(new ProductConfConfigurations());
        //     modelBuilder.ApplyConfiguration(new PromotionCategoriesConfigurations());
        //     modelBuilder.ApplyConfiguration(new PromotionProductsConfigurations());
        //     modelBuilder.ApplyConfiguration(new RoleConfigurations());
        //     modelBuilder.ApplyConfiguration(new UserAddressConfigurations());
        //     modelBuilder.ApplyConfiguration(new UserAuthMethodConfigurations());
        //     modelBuilder.ApplyConfiguration(new UserVerificationMethodConfigurations());
        //     modelBuilder.ApplyConfiguration(new VerificationMethodConfigurations());
        // }

        public DbSet<User>? Users { get; set; }
        public DbSet<UserReview>? User_Reviews { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<UserInfo>? User_Info { get; set; }
        public DbSet<UserAddress>? User_Addressess { get; set; }
        public DbSet<UserAuthMethod>? User_AuthMethods { get; set; }
        public DbSet<UserVerificationMethod>? User_VerificationMethods { get; set; }

        public DbSet<Address>? Address { get; set; }
        public DbSet<Region>? Regions { get; set; }
        public DbSet<AuthProvider>? AuthProviders { get; set; }
        public DbSet<VerificationMethod>? VerificationMethods { get; set; }


        public DbSet<Payment>? Payments { get; set; }
        public DbSet<PaymentType>? Payment_Types { get; set; }


        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderLine>? Order_Lines { get; set; }
        public DbSet<OrderStatus>? Order_Status { get; set; }
        public DbSet<OrderShippingMethod>? Order_Shipping_Methods { get; set; }


        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? Cart_Items { get; set; }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Product_Categories { get; set; }
        public DbSet<Promotion>? Promotions { get; set; }
        public DbSet<ProductConf>? Product_Conf { get; set; }
        public DbSet<ProductItem>? Product_Items { get; set; }
        public DbSet<Variation>? Product_Variations { get; set; }
        public DbSet<VariationOption>? Product_VariationOptions { get; set; }
        public DbSet<Description>? Product_Descriptions { get; set; }
        public DbSet<PromotionCategories>? Product_Categories_Promotions { get; set; }
        public DbSet<PromotionProducts>? Product_Items_Promotions { get; set; }
    }
}
