using SignatureApp.Web.Middlewares;
using SignatureApp.Web.Models;
using SignatureApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);
var appSettings = new AppSettings();
var azureSettings = new AzureSettings();
// Add services to the container.
builder.Services.AddControllers();

builder.Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);
builder.Configuration.GetSection(nameof(AzureSettings)).Bind(azureSettings);

builder.Services.AddCors();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(appSettings);
builder.Services.AddSingleton(azureSettings);
builder.Services.AddScoped<ISignatureService,SignatureService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    //builder.WithOrigins(appSettings.AllowedOrigins)
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<AuthMiddleware>();

app.Run();
