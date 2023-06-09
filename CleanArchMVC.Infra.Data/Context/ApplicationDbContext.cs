﻿using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMVC.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Maps product and category classes to tables
        // Mapeia classes de produto e categoria para tabelas

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        // Configures the Fluent API template
        // Configura o modelo Fluent API

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }
}
