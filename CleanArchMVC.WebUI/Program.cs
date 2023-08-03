using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.IoC;

namespace CleanArchMVC.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

 
            // Add dependency injection service
            // Adiciona serviço de injeção de dependência
            builder.Services.AddServices(builder.Configuration);

            //builder.Services.AddAutoMapper(builder);

            // Add Automapper service
            // Adicionar serviço Automapper
            //builder.Services.AddAutoMapper(typeof());

            builder.Services.AddEndpointsApiExplorer();

            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Added user creation and update service
            // Adicionado serviço de criação e atualização de usuários

            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();

                seedUserRoleInitial.SeedRoles();
                seedUserRoleInitial.SeedUsers();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


        }
    }
}