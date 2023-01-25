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
    public class JobRepository : IJobRepository
    {
        ApplicationDbContext _dbContext;

        public JobRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Job? jobDelete)
        {
            _dbContext.Jobs.Remove(jobDelete!);
        }

        public async Task DeleteById(int id)
        {
            var toDelete = await _dbContext.Jobs.SingleOrDefaultAsync(j => j.Id == id);
            Delete(toDelete);
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _dbContext.Jobs.OrderBy(j => j.Id).ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _dbContext.Jobs.SingleOrDefaultAsync(j => j.Id == id);
        }


        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Jobs.CountAsync();
        }

        public async Task Insert(Job newJob)
        {
            await _dbContext.Jobs.AddAsync(newJob);
        }

        public void Update(Job newJob)
        {
            _dbContext.Jobs.Update(newJob);
        }
    }
}
