using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.Base
{
    public class RepoEntityBase<T> : IRepoEntityBase<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _Context;

        public RepoEntityBase(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task AddAsync(T Entity)
        {
            await _Context.Set<T>().AddAsync(Entity);
            await _Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _Context.Set<T>().FirstOrDefaultAsync(d => d.Id == id);
            EntityEntry entityEntry = _Context.Entry(result);
            entityEntry.State = EntityState.Deleted;
            await _Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T Entity)
        {
            EntityEntry entityEntry = _Context.Entry(Entity);
            entityEntry.State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] IncludePropreties)
        {
            IQueryable<T> Query = _Context.Set<T>();
            Query = IncludePropreties.Aggregate(Query, (Current, IncludeProprety) => Current.Include(IncludeProprety));
            return await Query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _Context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _Context.Set<T>().FirstOrDefaultAsync(D => D.Id == id);
    }
}
