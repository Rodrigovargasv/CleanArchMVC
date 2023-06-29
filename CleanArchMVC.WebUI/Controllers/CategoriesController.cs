using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Index()
        {
            var categories = await _categoryService.GetAllCategoryDTOsAsync();
            return View(categories);

        }

        [HttpGet()]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategoryDTOAsync(categoryDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryService.GetByIdCategoryDTOAsync(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);


        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.UpdateCategoryDTOAsync(categoryDTO);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryService.GetByIdCategoryDTOAsync(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);

        }

        [HttpPost(), ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirme(int? id)
        {
            await _categoryService.DeleteCategoryDTOAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
