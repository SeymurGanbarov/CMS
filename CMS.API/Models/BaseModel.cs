using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.API.Models
{
    public abstract class BaseModel
    {
        protected BaseModel() { }

        protected BaseModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}