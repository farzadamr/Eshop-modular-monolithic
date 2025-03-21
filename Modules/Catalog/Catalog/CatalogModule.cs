﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Interceptors;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to container.

        // Api Endpoint services.

        // Application Use Case services.

        // Data - Infrastructure services.
        var connectionString = configuration.GetConnectionString("postgresql");

        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseNpgsql(connectionString);

        });


        services.AddScoped<IDataSeeder, CatalogDataSeeder>();
        return services;
    }
    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        // Add HTTP pipeline configuration.

        // 1. Use Api Endpoint services.

        // 2. Use Application Use Case services.

        // 3. Use Data-Infrastructure services. 
        app.UseMigration<CatalogDbContext>();

        return app;
    }

}
