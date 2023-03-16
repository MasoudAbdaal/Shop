using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;
using Shop.Data.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureAuthentications(builder.Configuration);
builder.Services.ConfigureJsonOptions();

builder.Services.AddDbContext<MainContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAddressRepo, AddressRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
