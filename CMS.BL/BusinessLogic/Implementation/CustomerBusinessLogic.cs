using AutoMapper;
using CMS.DAL.DAO;
using CMS.DAL.DTO;
using CMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.BL.BusinessLogic
{
    public class CustomerBusinessLogic : ICustomerBusinessLogic
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerBusinessLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<CustomerDTO> GetAll()
        {
             return _customerRepository.GetAll().Select(m=>Mapper.Map<CustomerDTO>(m));
        }

        public CustomerDTO GetById(Guid id)
        {
            var dao= _customerRepository.FindById(id);
            return Mapper.Map<CustomerDTO>(dao);
        }

        public void Remove(Guid id)
        {
            _customerRepository.Remove(id);
        }

        public CustomerDTO Save(CustomerDTO entity)
        {
            var dao = Mapper.Map<CustomerDAO>(entity);
            var result = _customerRepository.Save(dao);
            return Mapper.Map<CustomerDTO>(result);
        }
    }
}
