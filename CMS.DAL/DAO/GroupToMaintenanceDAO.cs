using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DAO
{
    public class GroupToMaintenanceDAO : BaseEntityDAO
    {
        public Guid GroupId { get; set; }
        public Guid MaintenanceId { get; set; }
    }
}
