using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Sum => Count * ProductPrice;
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductImagePath { get; set; }
        public int UserId { get; set; }
    }
}