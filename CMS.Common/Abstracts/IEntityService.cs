using CMS.Common;
using System;
using System.Collections.Generic;

namespace CMS.Commons.Abstracts
{
    public interface IEntityService<T> where T : BaseEntityDTO
    {
        OperationResult<IEnumerable<T>> GetAll();
        OperationResult<T> GetById(Guid id);
        OperationResult<T> Save(T entity);
        OperationResult Remove(Guid id);
    }
}
