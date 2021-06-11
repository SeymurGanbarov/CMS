using CMS.Commons.Extensions;
using CMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.DAL.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        public MaintenanceDAO FindById(Guid id)
        {
            var entity = DataContext.Maintenances.FirstOrDefault(m => m.Id == id);
            return entity;
        }

        public IEnumerable<MaintenanceDAO> GetAll()
        {
            return DataContext.Maintenances;
        }

        public void Remove(Guid id)
        {
            var dao = DataContext.Maintenances.FirstOrDefault(m => m.Id == id);
            if (dao != null) DataContext.Maintenances.Remove(dao);
        }

        public MaintenanceDAO Save(MaintenanceDAO dao)
        {
            if (dao.Id == Guid.Empty)
            {
                dao.InitializeEntity();
                DataContext.Maintenances.Add(dao);
                return dao;
            }
            else
            {
                var olDao = DataContext.Maintenances.FirstOrDefault(m => m.Id == dao.Id);
                olDao.ChangeTo(dao);
                return olDao;
            }
        }
    }
}
