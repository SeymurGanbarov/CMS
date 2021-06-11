using CMS.Commons.Extensions;
using CMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerDAO FindById(Guid id)
        {
            var entity = DataContext.Customers.FirstOrDefault(m => m.Id == id);
            return entity;
        }

        public IEnumerable<CustomerDAO> GetAll()
        {
            return DataContext.Customers;
        }

        public void Remove(Guid id)
        {
            var dao = DataContext.Customers.FirstOrDefault(m => m.Id == id);
            if (dao != null) DataContext.Customers.Remove(dao);
        }

        public CustomerDAO Save(CustomerDAO dao)
        {
            if (dao.Id == Guid.Empty)
            {
                dao.InitializeEntity();
                DataContext.Customers.Add(dao);
                return dao;
            }
            else
            {
                var olDao = DataContext.Customers.FirstOrDefault(m => m.Id == dao.Id);
                olDao.ChangeTo(dao);
                return olDao;
            }
        }
    }
}
