using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Behaviours;
using System.Reflection;

namespace Sample.Application
{
    public static class ServiceExtensions
    {
        public static void AddAplicationLayer(this IServiceCollection services)
        {
            // permite decirle que registre los mapeos que se hagan en esta biblioteca
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
