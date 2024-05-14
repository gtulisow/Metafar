using atm.api.application.HandlerMarker;
using atm.api.application.Models.Config;
using atm.api.data.DBContext;
using atm.api.data.Repositories;
using atm.api.web.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddATMAuthentication(configuration.GetSection("SecuritySettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.Configure<SecurityServiceConfiguration>(configuration.GetSection("SecuritySettings"));

builder.Services.MediatRServiceConfigurator();

builder.Services.AddATMDatabase(configuration);

builder.Services.AddATMServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
