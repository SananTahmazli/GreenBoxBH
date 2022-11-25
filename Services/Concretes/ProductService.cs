using AutoMapper;
using DataAccess;
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
        public ProductService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public IEnumerable<ProductDTO> GetFilter(out int prodCount, int page = 1, int pageSize = 4, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null)
        {
            var res = GetAll();

            if (!string.IsNullOrEmpty(search?.Trim()))
            {
                res = res.Where(pr => pr.Name.ToLower().Contains(search.ToLower()));
            }

            prodCount = res.Count();

            res = order switch
            {
                ProductSortOrder.NameDesc => res.OrderByDescending(s => s.Name),
                ProductSortOrder.PriceAsc => res.OrderBy(s => s.Price),
                ProductSortOrder.PriceDesc => res.OrderByDescending(s => s.Price),
                _ => res.OrderBy(s => s.Name),
            };

            var products = res.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return products;
        }
    }
}