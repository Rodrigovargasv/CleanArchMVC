using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
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
    }
}
