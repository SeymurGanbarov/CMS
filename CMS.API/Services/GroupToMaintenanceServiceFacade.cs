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
    public class GroupToMaintenanceServiceFacade : BaseServiceFacade
    {
        private readonly IGroupToMaintenanceBusinessLogic _groupToMaintenanceBusinessLogic;
        public GroupToMaintenanceServiceFacade(IGroupToMaintenanceBusinessLogic groupToMaintenanceBusinessLogic)
        {
            _groupToMaintenanceBusinessLogic = groupToMaintenanceBusinessLogic;
        }
        public OperationResult<IEnumerable<GroupToMaintenanceDTO>> GetAll()
        {
            try
            {
                var data = _groupToMaintenanceBusinessLogic.GetAll();
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<IEnumerable<GroupToMaintenanceDTO>>(ex);
            }
        }

        public OperationResult<GroupToMaintenanceDTO> Get(Guid id)
        {
            try
            {
                var data = _groupToMaintenanceBusinessLogic.GetById(id);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<GroupToMaintenanceDTO>(ex);
            }
        }

        public OperationResult Create(GroupToMaintenanceModel groupToMaintenanceModel)
        {
            try
            {
                if (groupToMaintenanceModel.MaintenanceId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.MaintenanceIdRequired));

                if (groupToMaintenanceModel.GroupId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.GroupId));

                var dto = Mapper.Map<GroupToMaintenanceDTO>(groupToMaintenanceModel);
                var data = _groupToMaintenanceBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<GroupToMaintenanceDTO>(ex);
            }
        }

        public OperationResult Edit(GroupToMaintenanceModel groupToMaintenanceModel)
        {
            try
            {
                if (groupToMaintenanceModel.Id == Guid.Empty)
                    return Failure(new ApplicationException(Messages.IdRequired));

                if (groupToMaintenanceModel.MaintenanceId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.MaintenanceIdRequired));

                if (groupToMaintenanceModel.GroupId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.GroupId));

                var dto = Mapper.Map<GroupToMaintenanceDTO>(groupToMaintenanceModel);
                var data = _groupToMaintenanceBusinessLogic.Save(dto);
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

                _groupToMaintenanceBusinessLogic.Remove(id);
                return Succeed();
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }
    }
}