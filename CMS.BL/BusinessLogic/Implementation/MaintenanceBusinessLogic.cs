using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;
using CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.BL.BusinessLogic
{
    public class MaintenanceBusinessLogic : IMaintenanceBusinessLogic
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        public MaintenanceBusinessLogic(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }
        public IEnumerable<MaintenanceDTO> GetAll()
        {
             return _maintenanceRepository.GetAll().Select(m=>Mapper.Map<MaintenanceDTO>(m));
        }

        public MaintenanceDTO GetById(Guid id)
        {
            var dao= _maintenanceRepository.FindById(id);
            return Mapper.Map<MaintenanceDTO>(dao);
        }

        public void Remove(Guid id)
        {
            _maintenanceRepository.Remove(id);
        }

        public MaintenanceDTO Save(MaintenanceDTO entity)
        {
            var dao = Mapper.Map<MaintenanceDAO>(entity);
            var result = _maintenanceRepository.Save(dao);
            return Mapper.Map<MaintenanceDTO>(result);
        }
    }
}
