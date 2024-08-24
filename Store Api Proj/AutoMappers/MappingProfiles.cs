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
            CreateMap<Order, CreateOrderRequest>();
        }
    }
}
