using G = Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;

namespace Cinema.DAL.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }

        public User(G.User entity)
        {
            Id = entity.id;
            Login = entity.login;
            Email = entity.email;
            FirstName = entity.first_name;
            LastName = entity.last_name;
            Password = entity.password;
            Salt = entity.salt;
            Role = (entity.role == "SIMPLE_USER")? UserRole.SIMPLE_USER : (entity.role == "ADMIN")? UserRole.ADMIN : UserRole.NOT_ASSIGNED;
        }

        public User(int id, string login, string email, string first_name, string last_name, string password, string salt, UserRole role)
        {
            Id = id;
            Login = login;
            Email = email;
            FirstName = first_name;
            LastName = last_name;
            Password = password;
            Salt = salt;
            Role = role;
        }

    }
}
