namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dto.ImportDto;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
        }
    }
}
