using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Infraestructure.Context;
using Sample.Infraestructure.Repositories;
using Sample.Infraestructure.Services;
using System;
using System.Text;
using System.Threading.Tasks;


namespace Sample.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //var appSettingSection = configuration.GetSection("JWTSettings");
            ////acoplar clase a la configuraccion
            //services.Configure<JWTSettings>(appSettingSection);
            //services.AddControllers(opt =>
            //{
            //    var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
            //    opt.Filters.Add(new AuthorizeFilter(policy));
            //});

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        //c.NoResult();
                        //c.Response.StatusCode = 500;
                        //c.Response.ContentType = "text/plain";
                        //return c.Response.WriteAsync(c.Exception.ToString());

                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        c.Response.WriteAsync(c.Exception.ToString()).Wait();
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response<string>("Usted no esta autorizado"));
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 400;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response<string>("Usted no tiene permisos sobre este recurso"));
                        return context.Response.WriteAsync(result);

                    }
                };

            });

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            //services.AddTransient<IMailHelper, MailHelpers>();

            //Insertas los usuarios del Identity
            //services.AddTransient<SeedDb>();

            #endregion

            #region Caching

            #endregion
        }
    }
}
