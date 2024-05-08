
using Juntos.SomosMais.Challenge.API.Configuration;
using Juntos.SomosMais.Challenge.Service.Services.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddHostedService<InitialLoadService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddCustomMvc();
builder.Services.AddDefaultApiVersioning();
builder.Services.AddDependencyInjection(config);


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
