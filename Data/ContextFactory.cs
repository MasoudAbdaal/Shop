// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Shop.Data;

// public class ContextFactory : IDesignTimeDbContextFactory<MainContext>
// {
//   public MainContext CreateDbContext(string[] args)
//   {
//     IConfigurationRoot Configuration = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetParent(".")!.FullName)
//    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
//    .Build();

//     DbContextOptionsBuilder Builder = new DbContextOptionsBuilder<MainContext>()
//     .UseSqlServer(Configuration.GetValue<string>("Database:ConnectionString")
//     , x => x.UseNetTopologySuite());


//   }
// }