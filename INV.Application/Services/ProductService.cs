
using INV.Application.DTO;
using INV.Application.Extensions;
using INV.Application.Services.Interfaces;
using INV.Data.Repository.Interfaces;

namespace INV.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int?> Add(ProductDTO productDTO)
        {
            var result = await _repository.Add(productDTO);
            return result;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _repository.All();
            return MapperProduct.EnumerableToDto(products);
        }
    }
}
