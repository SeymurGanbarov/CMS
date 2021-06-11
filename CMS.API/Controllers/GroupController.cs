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
    public class GroupController : BaseController
    {
        private readonly GroupServiceFacade _groupServiceFacade;
        public GroupController(GroupServiceFacade groupServiceFacade)
        {
            _groupServiceFacade = groupServiceFacade;
        }

        [HttpGet]
        public OperationResult<IEnumerable<GroupDTO>> GetAll()
        {
            return _groupServiceFacade.GetAll();
        }

        [HttpGet]
        public OperationResult<GroupDTO> Get(Guid id)
        {
            return _groupServiceFacade.Get(id);
        }

        [HttpPost]
        [ValidateModel]
        public OperationResult Post([FromBody] GroupModel groupModel)
        {
            return _groupServiceFacade.Create(groupModel);
        }

        [HttpPut]
        [ValidateModel]
        public OperationResult Put([FromBody] GroupModel groupModel)
        {
            return _groupServiceFacade.Edit(groupModel);
        }

        [HttpDelete]
        public OperationResult Delete(Guid id)
        {
            return _groupServiceFacade.Remove(id);
        }
    }
}
