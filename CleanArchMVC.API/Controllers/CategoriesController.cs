using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.API.Controllers
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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoryDTOsAsync();

            if (categories == null)
            {
                return NotFound("Categories not found");

            }
            return Ok(categories);

        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var categoryId = await _categoryService.GetByIdCategoryDTOAsync(id);

            if (categoryId == null)
            {
                return NotFound("Category not found");
            }

            return Ok(categoryId);

        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.CreateCategoryDTOAsync(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id, categoryDTO });

        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
                return BadRequest(ModelState);

            if (categoryDTO == null)
                return BadRequest(ModelState);


            await _categoryService.UpdateCategoryDTOAsync(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            var getCategory = await _categoryService.GetByIdCategoryDTOAsync(id);

            if (getCategory == null)
                return NotFound("Category not found");


            await _categoryService.DeleteCategoryDTOAsync(id);

            return Ok(getCategory);

        }
    }
}
