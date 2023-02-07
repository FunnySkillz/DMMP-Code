
using DMMP.Core.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Entity
{
    public class Property : EntityObject
    {
        [Required, MaxLength(250)]
        public string PropertyName { get; set; } = string.Empty;
        [Required, MaxLength(250)]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int AddressNumber { get; set; }
        [Required, MaxLength(250)]
        public string City { get; set; } = string.Empty;
        [Required]
        public int PostalCode { get; set; }
        public int FloorAmount { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
