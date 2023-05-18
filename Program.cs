var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureAuthentications(builder.Configuration);
builder.Services.ConfigureJsonOptions();
// builder.Services.ConfigureContextFactory();
// builder.Services.ConfigureRepositoryManager();


builder.Services.AddAuthorization();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
