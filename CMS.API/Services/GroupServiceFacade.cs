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
    public class GroupServiceFacade : BaseServiceFacade
    {
        private readonly IGroupBusinessLogic _groupBusinessLogic;
        public GroupServiceFacade(IGroupBusinessLogic groupBusinessLogic)
        {
            _groupBusinessLogic = groupBusinessLogic;
        }
        public OperationResult<IEnumerable<GroupDTO>> GetAll()
        {
            try
            {
                var data = _groupBusinessLogic.GetAll();
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<IEnumerable<GroupDTO>>(ex);
            }
        }

        public OperationResult<GroupDTO> Get(Guid id)
        {
            try
            {
                var data = _groupBusinessLogic.GetById(id);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<GroupDTO>(ex);
            }
        }

        public OperationResult Create(GroupModel groupModel)
        {
            try
            {
                var dto = Mapper.Map<GroupDTO>(groupModel);
                var data = _groupBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<GroupDTO>(ex);
            }
        }

        public OperationResult Edit(GroupModel groupModel)
        {
            try
            {
                if (groupModel.Id == Guid.Empty)
                    return Failure(new ApplicationException(Messages.IdRequired));

                var dto = Mapper.Map<GroupDTO>(groupModel);
                var data = _groupBusinessLogic.Save(dto);
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

                _groupBusinessLogic.Remove(id);
                return Succeed();
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }
    }
}