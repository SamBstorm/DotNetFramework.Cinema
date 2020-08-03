using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Repositories
{
    public interface IRepository<TId,TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        TId Insert(TEntity entity);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
