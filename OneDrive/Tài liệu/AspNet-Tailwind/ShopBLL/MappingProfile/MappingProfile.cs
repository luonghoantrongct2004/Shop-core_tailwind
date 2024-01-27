using AutoMapper;
using Shop.DTO.DTOs;
using ShopDataAccess.Entity.Blog;
using ShopDataAccess.Entity.Brand;
using ShopDataAccess.Entity.Order;
using ShopDataAccess.Entity.Pay;
using ShopDataAccess.Entity.Product;
using ShopDataAccess.Entity.Shipping;

namespace Shop.BLL.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<News, NewDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
            CreateMap<ProductVideo, ProductVideoDTO>().ReverseMap();
            CreateMap<Shipping, ShippingDTO>().ReverseMap();
            CreateMap<TransactionPay, TransactionPayDTO>().ReverseMap();
        }
    }
}
