using AutoMapper;
using CMS.API.Models;
using CMS.DAL.DTO;

namespace CMS.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GroupModel, GroupDTO>().ReverseMap();
            CreateMap<CustomerModel, CustomerDTO>().ReverseMap();
            CreateMap<GroupToCustomerModel, GroupToCustomerDTO>().ReverseMap();
            CreateMap<MaintenanceModel, MaintenanceDTO>().ReverseMap();
            CreateMap<GroupToMaintenanceModel, GroupToMaintenanceDTO>().ReverseMap();
            CreateMap<MaintenanceFeatureModel, MaintenanceFeatureDTO>().ReverseMap();
        }
    }
}