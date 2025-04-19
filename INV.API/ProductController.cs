using API_Inventario.Extensions;
using FluentValidation;
using INV.Data.Entity;
using INV.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace INV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private IValidator<Product> _validator;
        public ProductController(IProductRepository productRepository, IValidator<Product> validator)
        {
            _productRepository = productRepository;
            _validator = validator;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody]Product product)
        {
            var validate = await _validator.ValidateAsync(product);

            if (validate.IsValid)
            {
                var result = await _productRepository.Add(product);
                if (result)
                {
                    Uri uri = new(uriString: $"api/product/{product.Id}");
                    return Created(uri, product);
                }
                return Problem("problem");
            }
            validate.AddToModelState(this.ModelState);

            return Problem(
                detail: string.Join(" | ", ModelState.Values
               .SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage)),
                instance: HttpContext.Request.Path,
                statusCode: 400,
                title: "Erro de validação",
                type: "https://httpstatuses.com/400"
            );
        }
    }
}
