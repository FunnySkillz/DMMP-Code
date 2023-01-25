
using DMMP.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Contract
{
    public interface IJobRepository
    {
        Task<int> GetCountAsync();
        void Insert(Job newJob);
        Task<List<Job>> GetAllJobs();
        Task<Job> GetById(int id);
        void Update(Job newJob);
        void Delete(Job jobDelete);
        Task DeleteById(int id);
    }
}
