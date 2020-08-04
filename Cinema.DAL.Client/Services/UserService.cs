using C = Cinema.DAL.Client.Models;
using G = Cinema.DAL.Global.Models;
using Cinema.DAL.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DAL.Client.Mapper;

namespace Cinema.DAL.Client.Services
{
    public class UserService : IUserRepository<int, C.User>
    {
        private IUserRepository<int, G.User> _repo;
        public UserService()
        {
            _repo = new UserRepository();
        }
        public C.User Check(C.User entity)
        {
            return _repo.Check(entity.ToGlobal()).ToClient();
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<C.User> Get()
        {
            return _repo.Get().Select(u => u.ToClient());
        }

        public C.User Get(int id)
        {
            return _repo.Get(id).ToClient();
        }

        public int Insert(C.User entity)
        {
            return _repo.Insert(entity.ToGlobal());
        }

        public bool Update(int id, C.User entity)
        {
            return _repo.Update(id, entity.ToGlobal());
        }
    }
}
