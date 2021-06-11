using CMS.Commons.Extensions;
using CMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository
{
    public class GroupToCustomerRepository : IGroupToCustomerRepository
    {
        public GroupToCustomerDAO FindById(Guid id)
        {
            var entity = DataContext.GroupToCustomers.FirstOrDefault(m => m.Id == id);
            return entity;
        }

        public IEnumerable<GroupToCustomerDAO> GetAll()
        {
            return DataContext.GroupToCustomers;
        }

        public void Remove(Guid id)
        {
            var dao = DataContext.GroupToCustomers.FirstOrDefault(m => m.Id == id);
            if (dao != null) DataContext.GroupToCustomers.Remove(dao);
        }

        public GroupToCustomerDAO Save(GroupToCustomerDAO dao)
        {
            if (dao.Id == Guid.Empty)
            {
                dao.InitializeEntity();
                DataContext.GroupToCustomers.Add(dao);
                return dao;
            }
            else
            {
                var olDao = DataContext.GroupToCustomers.FirstOrDefault(m => m.Id == dao.Id);
                olDao.ChangeTo(dao);
                return olDao;
            }
        }
    }
}
