using C = Cinema.DAL.Client.Models;
using Cinema.DAL.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G = Cinema.DAL.Global.Models;
using Cinema.DAL.Client.Mapper;

namespace Cinema.DAL.Client.Services
{
    public class CategoryService : ICategoryRepository<int, C.Category>
    {
        private ICategoryRepository<int, G.Category> _repo;

        public CategoryService()
        {
            _repo = new CategoryRepository();
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<C.Category> Get()
        {
            return _repo.Get().Select(c => c.ToClient());
        }

        public C.Category Get(int id)
        {
            return _repo.Get(id).ToClient();
        }

        public int Insert(C.Category entity)
        {
            return _repo.Insert(entity.ToGlobal());
        }

        public bool Update(int id, C.Category entity)
        {
            return _repo.Update(id, entity.ToGlobal());
        }
    }
}
