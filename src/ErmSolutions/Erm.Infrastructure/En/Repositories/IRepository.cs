using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erm.Infrastructure.En.Repositories
{
    public interface IRepository<T>
    {
        public List<T> findAll();
        public Task<List<T>> findAllAsync();
        public T findById(dynamic id);
        public T find(T model);
        public int SaveOrUpdate(T model);
        public Task<int> SaveOrUpdateAsync(T model);

        public int Delete(T model);
        public Task<int> DeleteAsync(T model);
    }
}
