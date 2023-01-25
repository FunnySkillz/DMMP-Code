
using DMMP.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.Contract
{
    public interface IJobRepository
    {
        Task<int> GetCountAsync();

        Task Insert(Job newJob);
        Task<List<Job>> GetAllJobs();
        Task<Job?> GetJobById(int id);
        void Update(Job newJob);
        void Delete(Job jobDelete);
        Task DeleteById(int id);

    }
}
