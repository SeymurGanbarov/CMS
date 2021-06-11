using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;
using CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.BL.BusinessLogic
{
    public class GroupBusinessLogic : IGroupBusinessLogic
    {
        private readonly IGroupRepository _groupRepository;
        public GroupBusinessLogic(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public IEnumerable<GroupDTO> GetAll()
        {
             return _groupRepository.GetAll().Select(m=>Mapper.Map<GroupDTO>(m));
        }

        public GroupDTO GetById(Guid id)
        {
            var dao= _groupRepository.FindById(id);
            return Mapper.Map<GroupDTO>(dao);
        }

        public void Remove(Guid id)
        {
            _groupRepository.Remove(id);
        }

        public GroupDTO Save(GroupDTO entity)
        {
            var dao = Mapper.Map<GroupDAO>(entity);
            var result = _groupRepository.Save(dao);
            return Mapper.Map<GroupDTO>(result);
        }
    }
}
