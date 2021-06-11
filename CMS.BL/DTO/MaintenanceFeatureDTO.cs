using CMS.Commons.Abstracts;
using System;

namespace CMS.DAL.DTO
{
    public class MaintenanceFeatureDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public Guid MaintenanceId { get; set; }
    }
}
