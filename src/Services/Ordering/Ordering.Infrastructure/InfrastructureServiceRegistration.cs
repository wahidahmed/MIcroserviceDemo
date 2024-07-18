using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistance;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistance;
using Ordering.Infrastructure.Repository;

namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("OrderDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
