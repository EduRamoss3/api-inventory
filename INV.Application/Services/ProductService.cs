
using INV.Application.DTO;
using INV.Application.Services.Interfaces;
using INV.Data.Repository;

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
    }
}
