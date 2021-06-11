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
    public class GroupToCustomerServiceFacade : BaseServiceFacade
    {
        private readonly IGroupToCustomerBusinessLogic _groupToCustomerBusinessLogic;
        public GroupToCustomerServiceFacade(IGroupToCustomerBusinessLogic groupToCustomerBusinessLogic)
        {
            _groupToCustomerBusinessLogic = groupToCustomerBusinessLogic;
        }
        public OperationResult<IEnumerable<GroupToCustomerDTO>> GetAll()
        {
            try
            {
                var data = _groupToCustomerBusinessLogic.GetAll();
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<IEnumerable<GroupToCustomerDTO>>(ex);
            }
        }

        public OperationResult<GroupToCustomerDTO> Get(Guid id)
        {
            try
            {
                var data = _groupToCustomerBusinessLogic.GetById(id);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<GroupToCustomerDTO>(ex);
            }
        }

        public OperationResult Create(GroupToCustomerModel groupToCustomerModel)
        {
            try
            {
                if (groupToCustomerModel.CustomerId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.CustomerId));

                if (groupToCustomerModel.GroupId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.GroupId));

                var dto = Mapper.Map<GroupToCustomerDTO>(groupToCustomerModel);
                var data = _groupToCustomerBusinessLogic.Save(dto);
                return Succeed(data);
            }
            catch (Exception ex)
            {
                return Failure<GroupToCustomerDTO>(ex);
            }
        }

        public OperationResult Edit(GroupToCustomerModel groupToCustomerModel)
        {
            try
            {
                if (groupToCustomerModel.Id == Guid.Empty)
                    return Failure(new ApplicationException(Messages.IdRequired));

                if (groupToCustomerModel.CustomerId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.CustomerId));

                if (groupToCustomerModel.GroupId == Guid.Empty)
                    return Failure(new ApplicationException(Messages.GroupId));

                var dto = Mapper.Map<GroupToCustomerDTO>(groupToCustomerModel);
                var data = _groupToCustomerBusinessLogic.Save(dto);
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

                _groupToCustomerBusinessLogic.Remove(id);
                return Succeed();
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }
    }
}