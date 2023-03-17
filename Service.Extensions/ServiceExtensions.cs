using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;

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