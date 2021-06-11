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
    public class MaintenanceFeatureController : BaseController
    {
        private readonly MaintenanceFeatureServiceFacade _maintenanceFeatureServiceFacade;
        public MaintenanceFeatureController(MaintenanceFeatureServiceFacade maintenanceFeatureServiceFacade)
        {
            _maintenanceFeatureServiceFacade = maintenanceFeatureServiceFacade;
        }

        [HttpGet]
        public OperationResult<IEnumerable<MaintenanceFeatureDTO>> GetAll()
        {
            return _maintenanceFeatureServiceFacade.GetAll();
        }

        [HttpGet]
        public OperationResult<MaintenanceFeatureDTO> Get(Guid id)
        {
            return _maintenanceFeatureServiceFacade.Get(id);
        }

        [HttpPost]
        [ValidateModel]
        public OperationResult Post([FromBody] MaintenanceFeatureModel maintenanceFeatureModel)
        {
            return _maintenanceFeatureServiceFacade.Create(maintenanceFeatureModel);
        }

        [HttpPut]
        [ValidateModel]
        public OperationResult Put([FromBody] MaintenanceFeatureModel maintenanceFeatureModel)
        {
            return _maintenanceFeatureServiceFacade.Edit(maintenanceFeatureModel);
        }

        [HttpDelete]
        public OperationResult Delete(Guid id)
        {
            return _maintenanceFeatureServiceFacade.Remove(id);
        }
    }
}
