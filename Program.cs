using System.Security.Cryptography;
using System.Text;
using Shop.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<UserContext>();
builder.Services.AddScoped<IUserRepo, SQLUserRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Guid UserGUID = new Guid(Convert.FromBase64String(builder.Configuration.GetValue<string>("Security:GUIDKeyBytes")));

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
