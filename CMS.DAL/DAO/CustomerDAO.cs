using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DAO
{
    public class CustomerDAO : BaseEntityDAO
    {
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Address { get; set; }
    }
}
