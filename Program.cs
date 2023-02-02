using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
// Guid g = new Guid("asdasas");
// Guid c = new Guid(BitConverter.ToString(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }).Replace("-", ""));

// Console.WriteLine("KEY LENGTH: {2} \n Manual GUID Length: {0} \n Key generated GUID: {1} ", g, c, new HMACSHA256().Key.Length);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
