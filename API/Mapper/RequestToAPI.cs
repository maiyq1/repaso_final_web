using API.Request;
using AutoMapper;
using Data.Model;

namespace API.Mapper;

public class RequestToAPI : Profile
{
    public RequestToAPI()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<MaintenanceRequest, MaintenanceActivity>();
    }
}