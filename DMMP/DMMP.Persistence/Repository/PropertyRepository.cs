using DMMP.Core.Contract;
using DMMP.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Persistence.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        ApplicationDbContext _dbContext;

        public PropertyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Property deleteProp)
        {
            _dbContext.Properties.Remove(deleteProp);
        }

        public async Task DeleteById(int id)
        {
            var property = await _dbContext.Properties.Where(p => p.Id == id).SingleOrDefaultAsync();
            Delete(property);
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _dbContext.Properties.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Property?> GetPropertyById(int id)
        {
            return await _dbContext.Properties.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Properties.CountAsync();
        }

        public void Insert(Property newProperty)
        {
            _dbContext.Properties.AddAsync(newProperty);
        }

        public void Update(Property newProperty)
        {
            _dbContext.Properties.Update(newProperty);
        }
    }
}
