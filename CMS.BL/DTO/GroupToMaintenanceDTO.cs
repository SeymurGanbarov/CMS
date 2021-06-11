using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DTO
{
    public class GroupToMaintenanceDTO : BaseEntityDTO
    {
        public Guid GroupId { get; set; }
        public Guid MaintenanceId { get; set; }
    }
}
