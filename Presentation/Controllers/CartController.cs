using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace Presentation.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddToCart(CartDTO dto)
        {
            bool isSuccess;
            string mes;
            try
            {
                dto.UserId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);
                _cartService.AddToCart(dto);
                mes = "The book has been successfully added to your cart!";
                isSuccess = true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                isSuccess = false;
            }

            return RedirectToAction("Get", "Product",
                new
                {
                    id = dto.ProductId,
                    message = mes,
                    isSuccess = isSuccess
                });
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int cartId)
        {
            _cartService.DeleteFromCart(cartId);

            return RedirectToAction("GetCart", "Cart",
                new
                {
                    message = "The book has been successfully deleted from your cart!",
                    isSuccess = true
                });
        }

        [HttpGet]
        public IActionResult GetCart(string message = null, bool isSuccess = true)
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

            var userId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);
            var res = _cartService.GetCart(userId);
            return View(res);
        }

        [HttpPost]
        public IActionResult Buy(PayDTO dto)
        {
            _cartService.Buy(dto.CartId);

            return RedirectToAction("GetCart",
                new
                {
                    message = "Success! You paid " + "$" + dto.Sum + "!",
                    isSuccess = true
                });
        }
    }
}