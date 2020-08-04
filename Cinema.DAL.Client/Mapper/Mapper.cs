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
        public static G.Category ToGlobal(this C.Category entity)
        {
            if (entity == null) return null;
            return new G.Category { 
                id = entity.Id,
                name = entity.Name,
                description = entity.Description
            };
        }
        public static C.Category ToClient(this G.Category entity)
        {
            if (entity == null) return null;
            return new C.Category(entity);
        }
        public static G.User ToGlobal(this C.User entity)
        {
            if (entity == null) return null;
            return new G.User {
                id = entity.Id,
                login = entity.Login,
                email = entity.Email,
                first_name = entity.FirstName,
                last_name = entity.LastName,
                password = entity.Password,
                salt = entity.Salt,
                role = entity.Role.ToString()   //(entity.Role == C.UserRole.ADMIN) ? "ADMIN" : (entity.Role == C.UserRole.SIMPLE_USER) ? "SIMPLE_USER" : "NOT_ASSIGNED"
            };
        }
        public static C.User ToClient(this G.User entity)
        {
            if (entity == null) return null;
            return new C.User(entity);
        }
    }
}
