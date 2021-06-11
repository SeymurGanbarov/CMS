using AutoMapper;
using CMS.API.Models;
using CMS.API.Resources;
using CMS.BL.BusinessLogic;
using CMS.Common;
using CMS.DAL.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.Services
{
    public class CustomerServiceFacade : BaseServiceFacade
    {
        private readonly ICustomerBusinessLogic _customerBusinessLogic;
        public CustomerServiceFacade(ICustomerBusinessLogic customerBusinessLogic)
        {
            _customerBusinessLogic = customerBusinessLogic;
        }
        public OperationResult<IEnumerable<CustomerDTO>> GetAll()
        {
            try
            {
                var data = _customerBusinessLogic.GetAll();
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<IEnumerable<CustomerDTO>>(ex);
            }
        }

        public OperationResult<CustomerDTO> Get(Guid id)
        {
            try
            {
                var data = _customerBusinessLogic.GetById(id);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<CustomerDTO>(ex);
            }
        }

        public OperationResult Create(CustomerModel customerModel)
        {
            try
            {
                var dto = Mapper.Map<CustomerDTO>(customerModel);
                var data = _customerBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<CustomerDTO>(ex);
            }
        }

        public OperationResult Edit(CustomerModel customerModel)
        {
            try
            {
                if (customerModel.Id == Guid.Empty)
                    return Failure(new ApplicationException(Messages.IdRequired));

                var dto = Mapper.Map<CustomerDTO>(customerModel);
                var data = _customerBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }

        public OperationResult Remove(Guid id)
        {
            try
            {
                if(id == Guid.Empty) return Failure(new ApplicationException(Messages.IdRequired));

                _customerBusinessLogic.Remove(id);
                return Succeed();
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }
    }
}