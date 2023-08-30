
var builder = WebApplication.CreateBuilder(args);
{
    var conf = builder.Configuration;
    // builder.Services.ConfigureIISIntegration();
    builder.Services.ConfigureAutomapper();
    builder.Services.ConfigureJsonOptions();
    builder.Services.AddInfrastructure(conf);
    builder.Services.AddApplication();
    builder.Services.AddAuthorization();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
