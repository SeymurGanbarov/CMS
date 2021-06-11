using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DAO
{
    public class MaintenanceFeatureDAO : BaseEntityDAO
    {
        public string Name { get; set; }
        public Guid MaintenanceId { get; set; }
    }
}
