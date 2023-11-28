using API.Request;
using API.Response;
using AutoMapper;
using Data.Model;

namespace API.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<Product, ProductResponse>();
        CreateMap<MaintenanceActivity, MaintenanceRequest>();
    }
}