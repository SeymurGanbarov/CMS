using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;
using CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.BL.BusinessLogic
{
    public class MaintenanceFeatureBusinessLogic : IMaintenanceFeatureBusinessLogic
    {
        private readonly IMaintenanceFeatureRepository _maintenanceFeatureRepository;
        public MaintenanceFeatureBusinessLogic(IMaintenanceFeatureRepository maintenanceFeatureRepository)
        {
            _maintenanceFeatureRepository = maintenanceFeatureRepository;
        }
        public IEnumerable<MaintenanceFeatureDTO> GetAll()
        {
             return _maintenanceFeatureRepository.GetAll().Select(m=>Mapper.Map<MaintenanceFeatureDTO>(m));
        }

        public MaintenanceFeatureDTO GetById(Guid id)
        {
            var dao= _maintenanceFeatureRepository.FindById(id);
            return Mapper.Map<MaintenanceFeatureDTO>(dao);
        }

        public void Remove(Guid id)
        {
            _maintenanceFeatureRepository.Remove(id);
        }

        public MaintenanceFeatureDTO Save(MaintenanceFeatureDTO entity)
        {
            var dao = Mapper.Map<MaintenanceFeatureDAO>(entity);
            var result = _maintenanceFeatureRepository.Save(dao);
            return Mapper.Map<MaintenanceFeatureDTO>(result);
        }
    }
}
