using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.DTOs;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.Mapster
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {
            //GET maps
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

            //POST maps
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

            //PUT maps
            CreateMap<Order, UpdateOrderDTO>();
            CreateMap<UpdateOrderDTO, Order>();

            CreateMap<Buyer, UpdateBuyerDTO>();
            CreateMap<UpdateBuyerDTO, Buyer>();

            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();

        }
    }
}