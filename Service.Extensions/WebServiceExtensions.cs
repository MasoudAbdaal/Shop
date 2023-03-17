public static class WebServiceExtensions
{
  public static void ConfigureIISIntegration(this IServiceCollection services) =>
  services.Configure<IISOptions>(options => { });
}