using System.Security.Cryptography;
using System.Text;
using Shop.Data;
using Shop.Data.Interface;
using Shop.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContextFactory<MainContext>();

builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


HMACSHA512 HashAlgorithm = new HMACSHA512(Convert.FromBase64String(builder.Configuration.GetValue<string>("JWT:Key")));
byte[] Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes("asdjaklsdjalksdjklasdjkasdlajsdaklsdkaskldjksdlkjasldlakskl"));



{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
