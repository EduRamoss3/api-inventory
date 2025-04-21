
using INV.Domain.Entity;

namespace INV.Data.Repository
{
    public interface IProductRepository
    {
        Task<int?> Add(Product product);
        Task<IEnumerable<Product>> All();
    }
}
