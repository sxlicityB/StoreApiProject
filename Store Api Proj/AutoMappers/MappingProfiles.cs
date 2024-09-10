using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Data;
using Store_Api_Proj.DTOs;
using Store_Api_Proj.Models;
using Store_Api_Proj.Repository;

namespace Store_Api_Proj.AutoMappers
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {

            CreateMap<Order, GetOrderDTO>()
             .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts.Select(op => new OrderProductDTO
             {
                 ProductId = op.Product.ProductId,
                 Brand = op.Product.Brand,
                 Type = op.Product.Type,
                 Price = op.Product.Price,
                 Quantity = op.Quantity
             })));
            CreateMap<GetOrderDTO, Order>();

            CreateMap<Order, CreateOrderDTO>();
            CreateMap<CreateOrderDTO, Order>()
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<CreateOrderProductDTO, OrderProduct>()
            .ForMember(dest => dest.Product, opt => opt.Ignore());


            CreateMap<OrderProduct, OrderProductDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Product.Brand))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Product.Type))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<Buyer, CreateBuyerDTO>();
            CreateMap<CreateBuyerDTO, Buyer>();

            CreateMap<Product, CreateProductDTO>();
            CreateMap<CreateProductDTO, Product>();

            CreateMap<Order, UpdateOrderDTO>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts.Select(op => new OrderProductDTO
             {
                 Price = op.Product.Price,
                 Quantity = op.Quantity
             })));
            CreateMap<UpdateOrderDTO, Order>()
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());

            CreateMap<OrderProduct, UpdateOrderProductDTO>();
        }
    }
}