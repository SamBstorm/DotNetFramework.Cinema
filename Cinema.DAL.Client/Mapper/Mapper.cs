using C = Cinema.DAL.Client.Models;
using G = Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Client.Mapper
{
    public static class Mapper
    {
        public static G.Movie ToGlobal(this C.Movie entity) {
            if (entity == null) return null;
            return new G.Movie
            {
                id = entity.Id,
                title = entity.Title,
                synopsis = entity.Synopsis,
                release_year = entity.ReleaseYear,
                poster_uri = entity.PosterURI,
                category_id = entity.Category.Id
            };
        }
        public static C.Movie ToClient(this G.Movie entity) {
            if (entity == null) return null;
            return new C.Movie(entity);
        }
    }
}
