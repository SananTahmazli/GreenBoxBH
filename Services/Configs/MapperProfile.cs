using AutoMapper;
using DataAccess.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Configs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>()
                .ForMember(dst => dst.RoleName, x => x.MapFrom(src => src.Role.Name));

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<CartDTO, Cart>();
            CreateMap<Cart, CartDTO>()
                .ForMember(dst => dst.ProductName, x => x.MapFrom(src => src.Product.Name))
                .ForMember(dst => dst.ProductImagePath, x => x.MapFrom(src => src.Product.ImagePath))
                .ForMember(dst => dst.ProductPrice, x => x.MapFrom(src => src.Product.Price));
        }
    }
}