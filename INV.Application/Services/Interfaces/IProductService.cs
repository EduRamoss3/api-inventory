

using INV.Application.DTO;

namespace INV.Application.Services.Interfaces
{
    public interface  IProductService
    {
        Task<int?> Add(ProductDTO productDTO);  
        Task<IEnumerable<ProductDTO>> GetAll();
    }
}
