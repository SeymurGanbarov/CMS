using CMS.Commons.Extensions;
using CMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.DAL.Repository
{
    public class MaintenanceFeatureRepository : IMaintenanceFeatureRepository
    {
        public MaintenanceFeatureDAO FindById(Guid id)
        {
            var entity = DataContext.MaintenanceFeatures.FirstOrDefault(m => m.Id == id);
            return entity;
        }

        public IEnumerable<MaintenanceFeatureDAO> GetAll()
        {
            return DataContext.MaintenanceFeatures;
        }

        public void Remove(Guid id)
        {
            var dao = DataContext.MaintenanceFeatures.FirstOrDefault(m => m.Id == id);
            if (dao != null) DataContext.MaintenanceFeatures.Remove(dao);
        }

        public MaintenanceFeatureDAO Save(MaintenanceFeatureDAO dao)
        {
            if (dao.Id == Guid.Empty)
            {
                dao.InitializeEntity();
                DataContext.MaintenanceFeatures.Add(dao);
                return dao;
            }
            else
            {
                var olDao = DataContext.MaintenanceFeatures.FirstOrDefault(m => m.Id == dao.Id);
                olDao.ChangeTo(dao);
                return olDao;
            }
        }
    }
}
