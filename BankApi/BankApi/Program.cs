using BankApi.BackgroundServices;
using BankApi.Extensions;
using BankApi.Infrastructure.Extensions;
using BankApi.Middlewares;
using BankApi.Service.Extensions;
using BankApi.Service.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersion();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddRepository();

builder.Services.AddServices();

builder.Services.AddValidation();

builder.Services.AddOptions<JwtSettings>().BindConfiguration("Jwt");

builder.Services.AddJwtService(builder.Configuration);

//builder.Services.AddHostedService<DepositBackgroundService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
