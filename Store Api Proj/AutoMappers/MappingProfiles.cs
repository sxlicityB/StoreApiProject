using AutoMapper;
using Store_Api_Proj.DTOs;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.AutoMappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreateOrderRequest>();
        }
    }
}
