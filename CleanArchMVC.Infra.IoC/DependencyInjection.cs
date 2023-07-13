using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Identity;
using CleanArchMVC.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;


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

            // serviços de autenticação de usuários
            // user authentication services
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            // serviços de cookie
            // cookie services
            services.ConfigureApplicationCookie(options => 
            options.AccessDeniedPath = "/Account/Login");

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRespository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            // serviços de autenticação de usuários
            // user authentication services
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


  


            return services;


        }

       
    }
}
