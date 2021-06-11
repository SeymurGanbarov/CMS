using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;
using CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.BL.BusinessLogic
{
    public class GroupToCustomerBusinessLogic : IGroupToCustomerBusinessLogic
    {
        private readonly IGroupToCustomerRepository _groupToCustomerRepository;
        public GroupToCustomerBusinessLogic(IGroupToCustomerRepository groupToCustomerRepository)
        {
            _groupToCustomerRepository = groupToCustomerRepository;
        }
        public IEnumerable<GroupToCustomerDTO> GetAll()
        {
             return _groupToCustomerRepository.GetAll().Select(m=>Mapper.Map<GroupToCustomerDTO>(m));
        }

        public GroupToCustomerDTO GetById(Guid id)
        {
            var dao= _groupToCustomerRepository.FindById(id);
            return Mapper.Map<GroupToCustomerDTO>(dao);
        }

        public void Remove(Guid id)
        {
            _groupToCustomerRepository.Remove(id);
        }

        public GroupToCustomerDTO Save(GroupToCustomerDTO entity)
        {
            var dao = Mapper.Map<GroupToCustomerDAO>(entity);
            var result = _groupToCustomerRepository.Save(dao);
            return Mapper.Map<GroupToCustomerDTO>(result);
        }
    }
}
