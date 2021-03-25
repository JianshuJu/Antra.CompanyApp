using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.Data.Repositories
{
    interface IRepositoryAsync<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> InsertAsync(T item);
        Task<int> DeleteAsync(int id);
        Task<int> UpdataAsync(T item);
        Task<T> GetByIdAsync(int id);
        //IEnumerable<T> GetByConditionAsync();
    }
}
