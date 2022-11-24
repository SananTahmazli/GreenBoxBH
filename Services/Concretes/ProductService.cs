using DataAccess.Entities;
using DTOs;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concretes
{
    public class ProductService : BaseService<ProductDTO, Product, ProductDTO>, IProductService
    {
    }
}