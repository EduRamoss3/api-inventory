using API_Inventario.Extensions;
using FluentValidation;
using INV.Application.DTO;
using INV.Application.Services.Interfaces;
using INV.Data.Repository;
using INV.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace INV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> All()
        {
            var products = await _productService.GetAll();  
            return Ok(products);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ProductDTO>> Create([FromServices] IValidator<ProductDTO> _validator, [FromBody]ProductDTO product)
        {
            var validate = await _validator.ValidateAsync(product);

            if (validate.IsValid)
            {
                var result = await _productService.Add(product);
                if (result != null)
                {
                    return Created($"api/product/{result.Value}", product);
                }
                return Problem("Problem with the server, refresh and try again later");
            }
            validate.AddToModelState(this.ModelState);

            return Problem(
                detail: string.Join(" | ", ModelState.Values
               .SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage)),
                instance: HttpContext.Request.Path,
                statusCode: 400,
                title: "Error of validation",
                type: "https://httpstatuses.com/400"
            );
        }
       
    }
}
