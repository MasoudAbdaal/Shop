using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public static class ServiceExtensions
{
  public static void ConfigureIISIntegration(this IServiceCollection services) =>
  services.Configure<IISOptions>(options => { });

  public static void ConfigureAutomapper(this IServiceCollection services) =>
  services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


  public static void ConfigureAuthentications(this IServiceCollection services, IConfiguration configuration) =>
  services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;

  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidIssuer = configuration.GetValue<string>("JWT:Issuer"),
    ValidAudience = configuration.GetValue<string>("JWT:Audience"),
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Key"))),
    RequireExpirationTime = true,
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
  };
});

public static void ConfigureJsonOptions(this IServiceCollection services)=>
services.AddControllers().AddJsonOptions(options =>
 {
   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
   options.JsonSerializerOptions.WriteIndented = true;
 });
}