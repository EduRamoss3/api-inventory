

using INV.Application.DTO;
using INV.Domain.Entity;

namespace INV.Application.Extensions
{
    public static class MapperProduct
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Price = product.Price,
                Available = product.Available,  
                Description = product.Description,  
                Name = product.Name,    
                Quantity = product.Quantity,
            };
        }
        public static IEnumerable<ProductDTO> EnumerableToDto(this IEnumerable<Product> products)
        {
            List<ProductDTO?> dtos = new List<ProductDTO?>();  
            foreach(var item in products)
            {
                dtos.Add(ToDTO(item));  
            }
            return dtos;
        }
    }
}
