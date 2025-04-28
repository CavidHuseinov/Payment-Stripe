
using AutoMapper;
using Ecommerce.Business.Helpers.DTOs.Cart;
using Ecommerce.Business.Helpers.DTOs.CartItem;
using Ecommerce.Business.Helpers.DTOs.Product;
using Ecommerce.Business.Helpers.DTOs.UserDto;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.Identity;

namespace Ecommerce.Business.Helpers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<RegisterDto,User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();
            CreateMap<TokenDto,Token>().ReverseMap();
            CreateMap<UserDto,User>().ReverseMap();
            #endregion

            #region Product
            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            #endregion

            #region CartItem
            CreateMap<CreateCartItemDto,CartItem>().ReverseMap();
            CreateMap<CartItemDto,CartItem>().ReverseMap();
            #endregion

            #region Cart
            CreateMap<CartDto,Cart>().ReverseMap();
            CreateMap<CreateCartDto,Cart>().ReverseMap();
            #endregion
        }
    }
}
