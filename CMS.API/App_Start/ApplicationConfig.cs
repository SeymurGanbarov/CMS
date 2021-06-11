using AutoMapper;
using CMS.API.Services;
using CMS.BL.BusinessLogic;
using CMS.DAL.Repository;
using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;

namespace CMS.API.App_Start
{
    public class ApplicationConfig
    {
        private static ILifetime Lifetime => new PerContainerLifetime();

        public static void Bootstrap(ServiceContainer container)
        {
            RegisterBusinessLogic(container);
            RegisterRepositories(container);
            RegisterServiceFacades(container);
            RegisterMappers();

            IServiceLocator serviceLocator = new LightInjectServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }


        private static void RegisterBusinessLogic(ServiceContainer container)
        {
            container.Register<ICustomerBusinessLogic, CustomerBusinessLogic>(Lifetime);
            container.Register<IGroupBusinessLogic, GroupBusinessLogic>(Lifetime);
            container.Register<IMaintenanceBusinessLogic, MaintenanceBusinessLogic>(Lifetime);
            container.Register<IGroupToMaintenanceBusinessLogic, GroupToMaintenanceBusinessLogic>(Lifetime);
            container.Register<IGroupToCustomerBusinessLogic, GroupToCustomerBusinessLogic>(Lifetime);
            container.Register<IMaintenanceFeatureBusinessLogic, MaintenanceFeatureBusinessLogic>(Lifetime);
        }

        private static void RegisterRepositories(ServiceContainer container)
        {
            container.Register<ICustomerRepository, CustomerRepository>(Lifetime);
            container.Register<IGroupRepository, GroupRepository>(Lifetime);
            container.Register<IMaintenanceRepository, MaintenanceRepository>(Lifetime);
            container.Register<IGroupToCustomerRepository, GroupToCustomerRepository>(Lifetime);
            container.Register<IGroupToMaintenanceRepository, GroupToMaintenanceRepository>(Lifetime);
            container.Register<IMaintenanceFeatureRepository, MaintenanceFeatureRepository>(Lifetime);
        }

        private static void RegisterServiceFacades(ServiceContainer container)
        {
            container.Register<CustomerServiceFacade>(Lifetime);
            container.Register<GroupServiceFacade>(Lifetime);
            container.Register<MaintenanceServiceFacade>(Lifetime);
            container.Register<GroupToCustomerServiceFacade>(Lifetime);
            container.Register<GroupToMaintenanceServiceFacade>(Lifetime);
            container.Register<MaintenanceFeatureServiceFacade>(Lifetime);
        }

        private static void RegisterMappers()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<CMS.BL.MapperProfile>();
                config.AddProfile<CMS.API.MapperProfile>();
            });
        }

    }
}