using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;

namespace CMS.BL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GroupDTO, GroupDAO>().ReverseMap();
            CreateMap<CustomerDTO, CustomerDAO>().ReverseMap();
            CreateMap<GroupToCustomerDTO, GroupToCustomerDAO>().ReverseMap();
            CreateMap<MaintenanceDTO, MaintenanceDAO>().ReverseMap();
            CreateMap<GroupToMaintenanceDTO, GroupToMaintenanceDAO>().ReverseMap();
            CreateMap<MaintenanceFeatureDTO, MaintenanceFeatureDAO>().ReverseMap();
        }
    }
}
