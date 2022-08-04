using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.Base
{
    public interface IRepoEntityBase<T> where T : class,IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[] IncludePropreties);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T Entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T Entity);
    }
}
