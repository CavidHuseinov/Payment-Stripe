
using AutoMapper;
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
            #endregion

            #region Product
            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            #endregion
        }
    }
}
