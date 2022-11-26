using DataAccess.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstracts
{
    public interface ICartService : IBaseService<CartDTO, Cart, CartDTO>
    {
        void AddToCart(CartDTO dto);
        void DeleteFromCart(int cartId);
        IEnumerable<CartDTO> GetCart(int userId);
        void Buy(int cartId);
    }
}