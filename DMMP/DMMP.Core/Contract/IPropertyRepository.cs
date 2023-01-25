
using DMMP.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Contract
{
    public interface IPropertyRepository
    {
        Task<int> GetCountAsync();

        Task Insert(Property newProperty);
        Task<List<Property>> GetAllProperties();
        void Update(Property newProperty);
        void Delete(Property deleteProp);
        Task<Property?> GetPropertyById(int id);
        Task DeleteById(int id);

    }
}
