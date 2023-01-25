
using DMMP.Core.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Entity
{
    public class Job : EntityObject
    {
        [ForeignKey("JobTypeId")]
        public JobType? JobType { get; set; }
        public int JobTypeId { get; set; }

        [ForeignKey("PropertyId")]
        public Property? Property { get; set; }
        public int PropertyId { get; set; } 

        public int FloorNumber { get; set; }
    }
}
