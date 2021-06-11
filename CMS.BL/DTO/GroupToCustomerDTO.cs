using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DTO
{
    public class GroupToCustomerDTO : BaseEntityDTO
    {
        public DateTime CreatedDate { get; set; }
        public Guid GroupId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
