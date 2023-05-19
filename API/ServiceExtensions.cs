using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{

  public static void ConfigureAutomapper(this IServiceCollection services) =>
  services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

  public static void ConfigureJsonOptions(this IServiceCollection services) =>
  services.AddControllers().AddJsonOptions(options =>
   {
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
     options.JsonSerializerOptions.WriteIndented = true;
   });


}