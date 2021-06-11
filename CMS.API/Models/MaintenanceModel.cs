using CMS.API.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.API.Models
{
    public class MaintenanceModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.CannotBeEmpty))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MustBeProperLength))]
        public string Name { get; set; }
    }
}