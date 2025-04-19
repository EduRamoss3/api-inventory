

using INV.Domain.Entity;

namespace INV.Application.DTO
{
    public record class ProductDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get;  set; } = 0;
        public bool Available { get; set; }
        public decimal Price { get;  set; }

        public static implicit operator Product(ProductDTO request)
        {
            return new Product
            {
                Name = request.Name,
                Available = request.Available,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
            };
        }
    }
}
