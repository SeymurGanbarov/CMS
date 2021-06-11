using System;
using System.Collections.Generic;

namespace CMS.Commons.Abstracts
{
    public interface IEntityRepository<T> where T: BaseEntityDAO
    {
        IEnumerable<T> GetAll();
        T FindById(Guid id);
        void Remove(Guid id);
        T Save(T entity);
    }
}
