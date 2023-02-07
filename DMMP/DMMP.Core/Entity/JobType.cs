
using DMMP.Core.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Entity
{
    public class JobType : EntityObject
    {
        [MaxLength(100)]
        public string? JobName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
