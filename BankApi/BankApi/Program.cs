using BankApi.BackgroundServices;
using BankApi.Extensions;
using BankApi.Infrastructure.Extensions;
using BankApi.Middlewares;
using BankApi.Service.Extensions;
using BankApi.Service.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersion();

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
