using AutoMapper;
using Store_Api_Proj.DTOs;
using Store_Api_Proj.Models;
using Store_Api_Proj.Repository;

namespace Store_Api_Proj.AutoMappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, GetOrderDTO>();
            CreateMap<GetOrderDTO, Order>();

            CreateMap<Order, CreateOrderDTO>();
            CreateMap<CreateOrderDTO, Order>()
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<CreateOrderProductDTO, OrderProduct>();
            CreateMap<OrderProduct, CreateOrderProductDTO>();
        }
    }
}
