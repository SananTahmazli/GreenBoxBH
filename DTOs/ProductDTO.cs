using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public enum ProductSortOrder
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }

    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "about")]
        public string? About { get; set; }
        [Required]
        [Display(Name = "image path")]
        public string? ImagePath { get; set; }
        [Required]
        [Display(Name = "image")]
        public IFormFile? Image { get; set; }
        [Required]
        [Display(Name = "count of pages")]
        public int CountOfPages { get; set; }
        [Required]
        [Display(Name = "price")]
        [Range(1, 100, ErrorMessage = "The price of book must be between $1 and $100!")]
        public double Price { get; set; }
    }
}