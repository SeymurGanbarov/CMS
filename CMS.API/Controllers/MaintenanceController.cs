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
    public class MaintenanceController : BaseController
    {
        private readonly MaintenanceServiceFacade _MaintenanceServiceFacade;
        public MaintenanceController(MaintenanceServiceFacade MaintenanceServiceFacade)
        {
            _MaintenanceServiceFacade = MaintenanceServiceFacade;
        }

        [HttpGet]
        public OperationResult<IEnumerable<MaintenanceDTO>> GetAll()
        {
            return _MaintenanceServiceFacade.GetAll();
        }

        [HttpGet]
        public OperationResult<MaintenanceDTO> Get(Guid id)
        {
            return _MaintenanceServiceFacade.Get(id);
        }

        [HttpPost]
        [ValidateModel]
        public OperationResult Post([FromBody] MaintenanceModel maintenanceModel)
        {
            return _MaintenanceServiceFacade.Create(maintenanceModel);
        }

        [HttpPut]
        [ValidateModel]
        public OperationResult Put([FromBody] MaintenanceModel maintenanceModel)
        {
            return _MaintenanceServiceFacade.Edit(maintenanceModel);
        }

        [HttpDelete]
        public OperationResult Delete(Guid id)
        {
            return _MaintenanceServiceFacade.Remove(id);
        }
    }
}
