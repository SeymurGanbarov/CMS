using CMS.Commons.Extensions;
using CMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository
{
    public class GroupRepository : IGroupRepository
    {
        public GroupDAO FindById(Guid id)
        {
            var entity = DataContext.Groups.FirstOrDefault(m => m.Id == id);
            return entity;
        }

        public IEnumerable<GroupDAO> GetAll()
        {
            return DataContext.Groups;
        }

        public void Remove(Guid id)
        {
            var dao = DataContext.Groups.FirstOrDefault(m => m.Id == id);
            if (dao != null) DataContext.Groups.Remove(dao);
        }

        public GroupDAO Save(GroupDAO dao)
        {
            if (dao.Id == Guid.Empty)
            {
                dao.InitializeEntity();
                DataContext.Groups.Add(dao);
                return dao;
            }
            else
            {
                var olDao = DataContext.Groups.FirstOrDefault(m => m.Id == dao.Id);
                olDao.ChangeTo(dao);
                return olDao;
            }
        }
    }
}
