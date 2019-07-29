using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property_API.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        List<TEntity> Get(Func<TEntity, bool> where);
        TEntity GetDetailed(Func<TEntity, bool> first);
        List<TEntity> GetDetailedAll();
        void Insert(TEntity item);
        void Insert(IEnumerable<TEntity> items);
        void Remove(TEntity item);
        void Remove(IEnumerable<TEntity> items);
        void RemoveAtId(int item);
        void Update(TEntity item);
        void Save();
    }
}
