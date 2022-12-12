using DTOs;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDTO(ProductDTO dto)
        {
            if (string.IsNullOrEmpty(dto.ImagePath))
            {
                dto.ImagePath = "~/images/product/book-1.png";
            }

            _productService.Create(dto);
            ViewBag.Success = "Book was added successfully to our website!";
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Update(int id)
        {
            var res = _productService.Get(id);
            return View(res);
        }

        [HttpPost]
        public IActionResult UpdateDTO(ProductDTO dto)
        {
            if (string.IsNullOrEmpty(dto.ImagePath))
            {
                dto.ImagePath = "~/images/product/book-1.png";
            }

            var res = _productService.Update(dto);
            ViewBag.Success = "Book was updated successfully!";
            return View("Update", res);
        }

        [HttpPost]
        public IActionResult DeleteDTO(ProductDTO dto)
        {
            _productService.Delete(dto);
            return RedirectToAction("GetAll", "Admin");
        }

        [HttpGet("Admin/Get/{id}")]
        public IActionResult Get(int id, string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                {
                    ViewBag.Success = message;
                }
                else
                {
                    ViewBag.Error = message;
                }
            }

            var res = _productService.Get(id);

            if (res == null)
            {
                ViewBag.Error = "Book is not found!";
                return View();
            }
            return View(res);
        }

        [HttpGet("Admin/GetAll")]
        public IActionResult GetAll(int page = 1, int pageSize = 4, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null, bool changeSort = false)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
            }

            int allProductsCount;
            var res = _productService.GetFilter(out allProductsCount, page, pageSize, order, search);

            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }
            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }

            if (changeSort)
            {
                ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
                ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;
            }
            else
            {
                ViewBag.NameSort = order;
                ViewBag.PriceSort = order;
            }

            var pagedRs = new PagedResponseDTO<ProductDTO>(page, pageSize, res);
            return View(pagedRs);
        }
    }
}