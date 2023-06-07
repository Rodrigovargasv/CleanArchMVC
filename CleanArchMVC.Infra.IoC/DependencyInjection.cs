

using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMVC.Infra.IoC
{
    public static class DependencyInjection
    {

        // Set the dependency injection service to correctly communicate with the entire project and database.
        // Performing the inversion of control.

        // Define o serviço de injeção de dependência para comunicação correta como todo o projeto e banco de dados.
        // Realizando a inversão de controle.

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRespository>();

            services.AddAutoMapper(typeof(ApplicationDbContext));

            return services;


        }
    }
}
