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
    public class MaintenanceFeatureServiceFacade : BaseServiceFacade
    {
        private readonly IMaintenanceFeatureBusinessLogic _maintenanceFeatureBusinessLogic;
        public MaintenanceFeatureServiceFacade(IMaintenanceFeatureBusinessLogic maintenanceFeatureBusinessLogic)
        {
            _maintenanceFeatureBusinessLogic = maintenanceFeatureBusinessLogic;
        }
        public OperationResult<IEnumerable<MaintenanceFeatureDTO>> GetAll()
        {
            try
            {
                var data = _maintenanceFeatureBusinessLogic.GetAll();
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<IEnumerable<MaintenanceFeatureDTO>>(ex);
            }
        }

        public OperationResult<MaintenanceFeatureDTO> Get(Guid id)
        {
            try
            {
                var data = _maintenanceFeatureBusinessLogic.GetById(id);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<MaintenanceFeatureDTO>(ex);
            }
        }

        public OperationResult Create(MaintenanceFeatureModel maintenanceFeatureModel)
        {
            try
            {
                if(maintenanceFeatureModel.MaintenanceId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.MaintenanceIdRequired));

                var dto = Mapper.Map<MaintenanceFeatureDTO>(maintenanceFeatureModel);
                var data = _maintenanceFeatureBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<MaintenanceFeatureDTO>(ex);
            }
        }

        public OperationResult Edit(MaintenanceFeatureModel maintenanceFeatureModel)
        {
            try
            {
                if (maintenanceFeatureModel.Id == Guid.Empty)
                    return Failure(new ApplicationException(Messages.IdRequired));

                if (maintenanceFeatureModel.MaintenanceId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.MaintenanceIdRequired));

                var dto = Mapper.Map<MaintenanceFeatureDTO>(maintenanceFeatureModel);
                var data = _maintenanceFeatureBusinessLogic.Save(dto);
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

                _maintenanceFeatureBusinessLogic.Remove(id);
                return Succeed();
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }
    }
}