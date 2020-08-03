using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Repositories
{
    public interface IMovieRepository<TId,TEntity> : IRepository<TId,TEntity>
    {
        IEnumerable<TEntity> GetByActorId(TId actorId);
        IEnumerable<TEntity> GetByCategoryId(TId categoryId);
        IEnumerable<TEntity> GetByTitle(string title);
        IEnumerable<TEntity> GetByKeyword(params string[] keywords);
        IEnumerable<TEntity> GetByReleaseYear(int releaseYear);
    }
}
