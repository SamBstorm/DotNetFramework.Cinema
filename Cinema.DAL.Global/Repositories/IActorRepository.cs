using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Repositories
{
    public interface IActorRepository<TId,TEntity> : IRepository<TId,TEntity>
    {
        IEnumerable<TEntity> GetByMovieId(TId movieId);
    }
}
