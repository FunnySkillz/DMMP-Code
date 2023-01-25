
using DMMP.Core.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Entity
{
    public class EntityObject : IEntityObject
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
