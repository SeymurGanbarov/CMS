using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DAO
{
    public class GroupToCustomerDAO : BaseEntityDAO
    {
        public DateTime CreatedDate { get; set; }
        public Guid GroupId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
