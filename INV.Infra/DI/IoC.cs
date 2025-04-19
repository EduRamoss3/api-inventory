using FluentValidation;
using INV.Data.Entity;
using INV.Data.Repository;
using INV.Data.Seed;
using INV.Data.Validation;
using Microsoft.Extensions.DependencyInjection;


namespace INV.Infra.DI
{
    public static class IoC
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddSingleton<ICreate, Create>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IValidator<Product>, ProductValidator>();

            return services;
        }
    }
}
