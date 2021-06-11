using CMS.Commons.Extensions;
using CMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.DAL.Repository
{
    public class GroupToMaintenanceRepository : IGroupToMaintenanceRepository
    {
        public GroupToMaintenanceDAO FindById(Guid id)
        {
            var entity = DataContext.GroupToMaintenances.FirstOrDefault(m => m.Id == id);
            return entity;
        }

        public IEnumerable<GroupToMaintenanceDAO> GetAll()
        {
            return DataContext.GroupToMaintenances;
        }

        public void Remove(Guid id)
        {
            var dao = DataContext.GroupToMaintenances.FirstOrDefault(m => m.Id == id);
            if (dao != null) DataContext.GroupToMaintenances.Remove(dao);
        }

        public GroupToMaintenanceDAO Save(GroupToMaintenanceDAO dao)
        {
            if (dao.Id == Guid.Empty)
            {
                dao.InitializeEntity();
                DataContext.GroupToMaintenances.Add(dao);
                return dao;
            }
            else
            {
                var olDao = DataContext.GroupToMaintenances.FirstOrDefault(m => m.Id == dao.Id);
                olDao.ChangeTo(dao);
                return olDao;
            }
        }
    }
}
