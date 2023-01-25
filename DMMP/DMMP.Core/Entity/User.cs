
using DMMP.Core.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMMP.Core.Entity
{
    public class User : EntityObject
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Address { get; set; } = string.Empty;
        public int AddressNumber { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        [ForeignKey("JobId")] 
        public IList<Job>? Job { get; set; }
        public int JobId { get; set; }
    }
}
