using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Com.Core.Reposetory
{
    public interface IReposetory<T> where T : class
    {
        public Task<T> Get(int id);
        public Task<bool> Add(T obj);
        public Task<bool> Remove(int id);
        public Task<bool> Update(T obj);
        public Task<IEnumerable<T>> List();
        public Task<IEnumerable<T>> ListWithDetails();
    }
}
