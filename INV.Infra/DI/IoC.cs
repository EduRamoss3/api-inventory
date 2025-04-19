using FluentValidation;
using INV.Application.DTO;
using INV.Application.Services;
using INV.Application.Services.Interfaces;
using INV.Application.Validation;
using INV.Data.Repository;
using INV.Data.Seed;
using Microsoft.Extensions.DependencyInjection;


namespace INV.Infra.DI
{
    public static class IoC
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddSingleton<ICreate, Create>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IValidator<ProductDTO>, ProductDTOValidator>();

            return services;
        }
    }
}
