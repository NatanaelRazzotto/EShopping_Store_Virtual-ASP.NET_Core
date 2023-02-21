using EShopping.ProductApi.DTOs;
using EShopping.ProductApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopping.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();
            if (categoriesDto is null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categoriesDto);

        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();
            if (categoriesDto is null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categoriesDto);

        }
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
        {
            var categoriesDto = await _categoryService.GetCategoryByID(id);
            if (categoriesDto is null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categoriesDto);

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest();
            }

            await _categoryService.AddCategory(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId) {
                return BadRequest();
            }
            if (categoryDTO == null)
            {
                return BadRequest();
            }

            await _categoryService.UpdateCategory(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id){
            var categoryDTO = await _categoryService.GetCategoryByID(id);
            if (categoryDTO == null) {
                return NotFound("Category not found");
            }
            await _categoryService.RemoveCategory(id);
            return Ok(categoryDTO);

        }

    }
}
