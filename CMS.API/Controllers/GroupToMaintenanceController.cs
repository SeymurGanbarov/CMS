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
    public class GroupToMaintenanceController : BaseController
    {
        private readonly GroupToMaintenanceServiceFacade _groupToMaintenanceServiceFacade;
        public GroupToMaintenanceController(GroupToMaintenanceServiceFacade groupToMaintenanceServiceFacade)
        {
            _groupToMaintenanceServiceFacade = groupToMaintenanceServiceFacade;
        }

        [HttpGet]
        public OperationResult<IEnumerable<GroupToMaintenanceDTO>> GetAll()
        {
            return _groupToMaintenanceServiceFacade.GetAll();
        }

        [HttpGet]
        public OperationResult<GroupToMaintenanceDTO> Get(Guid id)
        {
            return _groupToMaintenanceServiceFacade.Get(id);
        }

        [HttpPost]
        public OperationResult Post([FromBody] GroupToMaintenanceModel GroupToMaintenanceModel)
        {
            return _groupToMaintenanceServiceFacade.Create(GroupToMaintenanceModel);
        }

        [HttpPut]
        public OperationResult Put([FromBody] GroupToMaintenanceModel GroupToMaintenanceModel)
        {
            return _groupToMaintenanceServiceFacade.Edit(GroupToMaintenanceModel);
        }

        [HttpDelete]
        public OperationResult Delete(Guid id)
        {
            return _groupToMaintenanceServiceFacade.Remove(id);
        }
    }
}
