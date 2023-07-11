using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductDTOsAsync();
            return View(products);
        }

        [HttpGet()]
        public async Task<IActionResult> Create() 
        {

            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetAllCategoryDTOsAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid) 
            {
                await _productService.CreateProductDTOAync(productDTO);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewBag.CategoryId =
                new SelectList(await _categoryService.GetAllCategoryDTOsAsync(), "Id", "Name");
                return View();
            }
            
        }


        [HttpGet()]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productService.GetByIdProductDTOAsync(id);

            if (productDTO == null) return NotFound();

            var categories = await _categoryService.GetAllCategoryDTOsAsync();

            ViewBag.CategoryId = new SelectList(categories, "Id","Name", productDTO.CategoryId);

            return View(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid) 
            {
                await _productService.UpdateProductDTOAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        [HttpGet()]
        public async Task<ActionResult> Delete (int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdProductDTOAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            await _productService.DeleteProductDTOAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdProductDTOAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
