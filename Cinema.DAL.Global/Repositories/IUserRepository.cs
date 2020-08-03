using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Repositories
{
    public interface IUserRepository<TId,TEntity> : IRepository<TId,TEntity>
    {
        TEntity Check(TEntity entity);
    }
}
