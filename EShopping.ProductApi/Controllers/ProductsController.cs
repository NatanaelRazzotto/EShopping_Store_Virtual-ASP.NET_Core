using EShopping.ProductApi.DTOs;
using EShopping.ProductApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopping.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var categoriesDto = await _productService.GetProducts();
            if (categoriesDto is null)
            {
                return NotFound("products not found");
            }
            return Ok(categoriesDto);

        }
  
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
        {
            var categoriesDto = await _productService.GetProductById(id);
            if (categoriesDto is null)
            {
                return NotFound("products not found");
            }
            return Ok(categoriesDto);

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                {
                    return BadRequest();
                }

                await _productService.AddProduct(productDTO);
                return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId)
            {
                return BadRequest();
            }
            if (categoryDTO == null)
            {
                return BadRequest();
            }

            await _productService.UpdateProduct(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDTO = await _productService.GetProductById(id);
            if (categoryDTO == null)
            {
                return NotFound("products not found");
            }
            await _productService.DeleteProduct(id);
            return Ok(categoryDTO);

        }
    }
}
