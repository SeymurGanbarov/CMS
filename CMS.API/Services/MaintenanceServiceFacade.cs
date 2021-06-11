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
    public class MaintenanceServiceFacade : BaseServiceFacade
    {
        private readonly IMaintenanceBusinessLogic _maintenanceBusinessLogic;
        public MaintenanceServiceFacade(IMaintenanceBusinessLogic maintenanceBusinessLogic)
        {
            _maintenanceBusinessLogic = maintenanceBusinessLogic;
        }
        public OperationResult<IEnumerable<MaintenanceDTO>> GetAll()
        {
            try
            {
                var data = _maintenanceBusinessLogic.GetAll();
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<IEnumerable<MaintenanceDTO>>(ex);
            }
        }

        public OperationResult<MaintenanceDTO> Get(Guid id)
        {
            try
            {
                var data = _maintenanceBusinessLogic.GetById(id);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<MaintenanceDTO>(ex);
            }
        }

        public OperationResult Create(MaintenanceModel maintenanceModel)
        {
            try
            {
                var dto = Mapper.Map<MaintenanceDTO>(maintenanceModel);
                var data = _maintenanceBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<MaintenanceDTO>(ex);
            }
        }

        public OperationResult Edit(MaintenanceModel maintenanceModel)
        {
            try
            {
                if (maintenanceModel.Id == Guid.Empty)
                    return Failure(new ApplicationException(Messages.IdRequired));

                var dto = Mapper.Map<MaintenanceDTO>(maintenanceModel);
                var data = _maintenanceBusinessLogic.Save(dto);
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

                _maintenanceBusinessLogic.Remove(id);
                return Succeed();
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }
    }
}