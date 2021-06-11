using System;
using System.Collections.Generic;

namespace CMS.Commons.Abstracts
{
    public interface IEntityBusinessLogic<T> where T:BaseEntityDTO 
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Save(T entity);
        void Remove(Guid id);
    }
}
