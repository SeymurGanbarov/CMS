using CMS.API.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.API.Models
{
    [Serializable]
    public class GroupModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.CannotBeEmpty))]
        [MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MustBeProperLength))]
        public string Name { get; set; }
    }
}