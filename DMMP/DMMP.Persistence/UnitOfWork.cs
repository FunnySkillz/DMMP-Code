using DMMP.Core.Contract;
using DMMP.Core.Entity;
using DMMP.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        #region Repos
        public IJobRepository JobRepository { get; set; }
        public IJobTypeRepository JobTypeRepository { get; set; }
        public IPropertyRepository PropertyRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        #endregion

        public UnitOfWork() : this(new ApplicationDbContext())
        { }
        public UnitOfWork(IConfiguration configuration) : this(new ApplicationDbContext(configuration))
        { }
        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = new ApplicationDbContext();
            JobTypeRepository = new JobTypeRepositry(_dbContext);
            JobRepository = new JobRepository(_dbContext);
            PropertyRepository = new PropertyRepository(_dbContext);
            UserRepository = new UserRepository(_dbContext);
        }

        public async Task DeleteDatabaseAsync() => await _dbContext!.Database.EnsureDeletedAsync();
        public async Task MigrateDatabaseAsync() => await _dbContext!.Database.MigrateAsync();
        public async Task CreateDatabaseAsync() => await _dbContext!.Database.EnsureCreatedAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _dbContext.DisposeAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext!.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                || entity.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToArray();  // Geänderte Entities ermitteln

            // Allfällige Validierungen der geänderten Entities durchführen
            foreach (var entity in entities)
            {

                ValidateEntityRecipe(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }
        private async void ValidateEntityRecipe(object entity)
        {
            // todo: use switch to validate every entity that passes through

            if (entity is JobType jobType)
            {
                // Alternativer explizizer cast: JobType jobType = entity as JobType;
                if (await _dbContext.JobTypes.AnyAsync(jt => jt.JobName.ToUpper() == jobType.JobName.ToUpper()
                    && jt.Id != jobType.Id))
                {
                    throw new ValidationException(new ValidationResult("JobType with that name already exists!",
                        new List<string>() { nameof(jobType.JobName) }), null, null);
                }
            }
        }
    }
}
