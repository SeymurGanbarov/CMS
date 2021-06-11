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
    public class GroupToCustomerController : BaseController
    {
        private readonly GroupToCustomerServiceFacade _groupToCustomerServiceFacade;
        public GroupToCustomerController(GroupToCustomerServiceFacade groupToCustomerServiceFacade)
        {
            _groupToCustomerServiceFacade = groupToCustomerServiceFacade;
        }

        [HttpGet]
        public OperationResult<IEnumerable<GroupToCustomerDTO>> GetAll()
        {
            return _groupToCustomerServiceFacade.GetAll();
        }

        [HttpGet]
        public OperationResult<GroupToCustomerDTO> Get(Guid id)
        {
            return _groupToCustomerServiceFacade.Get(id);
        }

        [HttpPost]
        public OperationResult Post([FromBody] GroupToCustomerModel groupToCustomerModel)
        {
            return _groupToCustomerServiceFacade.Create(groupToCustomerModel);
        }

        [HttpPut]
        public OperationResult Put([FromBody] GroupToCustomerModel groupToCustomerModel)
        {
            return _groupToCustomerServiceFacade.Edit(groupToCustomerModel);
        }

        [HttpDelete]
        public OperationResult Delete(Guid id)
        {
            return _groupToCustomerServiceFacade.Remove(id);
        }
    }
}
