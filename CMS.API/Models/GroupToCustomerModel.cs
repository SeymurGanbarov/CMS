using System;

namespace CMS.API.Models
{
    public class GroupToCustomerModel : BaseModel
    {
        public Guid GroupId { get; set; }
        public Guid CustomerId { get; set; }
    }
}