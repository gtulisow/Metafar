using atm.api.application.HandlerMarker;
using atm.api.application.Models.Config;
using atm.api.data.DBContext;
using atm.api.data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace atm.api.web.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddATMAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                });
             
            services
                .AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    var signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    { 
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:7027",
                        ValidAudience = "ATM Client",
                        IssuerSigningKey = signingCredentials.Key,
                    };
                });

            return services;
        }

        public static IServiceCollection AddATMDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AppDbConnectionString");

            services.AddDbContext<AppDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), c => c.MigrationsAssembly("atm.api.web")));

            return services;
        }

        public static IServiceCollection MediatRServiceConfigurator(this IServiceCollection services)
        {
            var mediatRServiceConfiguration = new MediatRServiceConfiguration();

            Assembly[] assemblies = { typeof(Program).Assembly, typeof(HandlerAssemblyMarker).Assembly };

            mediatRServiceConfiguration.RegisterServicesFromAssemblies(assemblies);

            services.AddMediatR(mediatRServiceConfiguration);

            return services;
        }

        public static IServiceCollection AddATMServices(this IServiceCollection services)
        { 
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();

            return services;
        }
    }
}
