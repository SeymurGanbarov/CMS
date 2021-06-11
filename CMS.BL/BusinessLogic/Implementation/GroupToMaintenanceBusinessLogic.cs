using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;
using CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.BL.BusinessLogic
{
    public class GroupToMaintenanceBusinessLogic : IGroupToMaintenanceBusinessLogic
    {
        private readonly IGroupToMaintenanceRepository _groupToMaintenanceRepository;
        public GroupToMaintenanceBusinessLogic(IGroupToMaintenanceRepository groupToMaintenanceRepository)
        {
            _groupToMaintenanceRepository = groupToMaintenanceRepository;
        }
        public IEnumerable<GroupToMaintenanceDTO> GetAll()
        {
             return _groupToMaintenanceRepository.GetAll().Select(m=>Mapper.Map<GroupToMaintenanceDTO>(m));
        }

        public GroupToMaintenanceDTO GetById(Guid id)
        {
            var dao= _groupToMaintenanceRepository.FindById(id);
            return Mapper.Map<GroupToMaintenanceDTO>(dao);
        }

        public void Remove(Guid id)
        {
            _groupToMaintenanceRepository.Remove(id);
        }

        public GroupToMaintenanceDTO Save(GroupToMaintenanceDTO entity)
        {
            var dao = Mapper.Map<GroupToMaintenanceDAO>(entity);
            var result = _groupToMaintenanceRepository.Save(dao);
            return Mapper.Map<GroupToMaintenanceDTO>(result);
        }
    }
}
