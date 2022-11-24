using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? About { get; set; }
        public string? ImagePath { get; set; }
        public int CountOfPages { get; set; }
        public double Price { get; set; }
    }
}