using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            var product = _productService.Get(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _productService.GetAll();
            return View(productList);
        }
    }
}