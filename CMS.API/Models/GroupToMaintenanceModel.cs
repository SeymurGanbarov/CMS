using System;

namespace CMS.API.Models
{
    public class GroupToMaintenanceModel : BaseModel
    {
        public Guid GroupId { get; set; }
        public Guid MaintenanceId { get; set; }
    }
}