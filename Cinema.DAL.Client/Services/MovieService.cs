using C = Cinema.DAL.Client.Models;
using G = Cinema.DAL.Global.Models;
using Cinema.DAL.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DAL.Client.Models;
using Cinema.DAL.Client.Mapper;

namespace Cinema.DAL.Client.Services
{
    public class MovieService : IMovieRepository<int, C.Movie>
    {
        private IMovieRepository<int, G.Movie> _repo;

        public MovieService()
        {
            _repo = new MovieRepository();
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<C.Movie> Get()
        {
            return _repo.Get().Select(e=>e.ToClient());
        }

        public C.Movie Get(int id)
        {
            return _repo.Get(id).ToClient();
        }

        public IEnumerable<C.Movie> GetByActorId(int actorId)
        {
            return _repo.GetByActorId(actorId).Select(e=>e.ToClient());
        }

        public IEnumerable<C.Movie> GetByCategoryId(int categoryId)
        {
            return _repo.GetByCategoryId(categoryId).Select(e => e.ToClient());
        }

        public IEnumerable<C.Movie> GetByKeyword(params string[] keywords)
        {
            return _repo.GetByKeyword(keywords).Select(e => e.ToClient());
        }

        public IEnumerable<C.Movie> GetByReleaseYear(int releaseYear)
        {
            return _repo.GetByReleaseYear(releaseYear).Select(e => e.ToClient());
        }

        public IEnumerable<C.Movie> GetByTitle(string title)
        {
            return _repo.GetByTitle(title).Select(e => e.ToClient());
        }

        public int Insert(C.Movie entity)
        {
            return _repo.Insert(entity.ToGlobal());
        }

        public bool Update(int id, C.Movie entity)
        {
            return _repo.Update(id,entity.ToGlobal());
        }
    }
}
