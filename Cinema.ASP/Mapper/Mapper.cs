using Cinema.ASP.Areas.Admin.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using A = Cinema.ASP.Models;
using D = Cinema.DAL.Client.Models;

namespace Cinema.ASP.Mapper
{
    public static class Mapper
    {
        public static A.User ToASP(this D.User entity)
        {
            if (entity is null) return null;
            return new A.User(entity);
        }
        public static D.User ToDAL(this A.User entity)
        {
            if (entity is null) return null;
            return new D.User(entity.Id,
                entity.Login,
                entity.Email,
                entity.FirstName,
                entity.LastName,
                entity.Password,
                entity.Salt,
                entity.Role);
        }

        public static UserListItem ToListItem(this A.User entity)
        {
            if (entity is null) return null;
            return new UserListItem(entity);
        }
    }
}