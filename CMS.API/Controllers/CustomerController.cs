using CMS.API.Helpers.Filters;
using CMS.API.Models;
using CMS.API.Services;
using CMS.Common;
using CMS.DAL.DTO;
using RCE.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CMS.API.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerServiceFacade _customerServiceFacade;
        public CustomerController(CustomerServiceFacade customerServiceFacade)
        {
            _customerServiceFacade = customerServiceFacade;
        }

        [HttpGet]
        public OperationResult<IEnumerable<CustomerDTO>> GetAll()
        {
            return _customerServiceFacade.GetAll();
        }

        [HttpGet]
        public OperationResult<CustomerDTO> Get(Guid id)
        {
            return _customerServiceFacade.Get(id);
        }

        [HttpPost]
        [ValidateModel]
        public OperationResult Post([FromBody] CustomerModel customerModel)
        {
            return _customerServiceFacade.Create(customerModel);
        }

        [HttpPut]
        [ValidateModel]
        public OperationResult Put([FromBody] CustomerModel customerModel)
        {
            return _customerServiceFacade.Edit(customerModel);
        }

        [HttpDelete]
        public OperationResult Delete(Guid id)
        {
            return _customerServiceFacade.Remove(id);
        }
    }
}
