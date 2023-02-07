using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP_Frontend.Model
{
    class Property
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int AddressNumber { get; set; }
        public string City { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public int FloorAmount { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
