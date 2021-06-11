using CMS.API.Resources;
using System.ComponentModel.DataAnnotations;

namespace CMS.API.Models
{
    public class CustomerModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.CannotBeEmpty))]
        [MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MustBeProperLength))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.CannotBeEmpty))]
        [MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MustBeProperLength))]
        public string LastName { get; set; }
        public byte Age { get; set; }

        [MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MustBeProperLength))]
        public string Address { get; set; }
    }
}