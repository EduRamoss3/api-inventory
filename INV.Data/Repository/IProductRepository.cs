

using INV.Data.Entity;

namespace INV.Data.Repository
{
    public interface IProductRepository
    {
        Task<bool> Add(Product product);
    }
}
