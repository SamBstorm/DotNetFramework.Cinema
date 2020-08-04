using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using D = Cinema.DAL.Client.Models;

namespace Cinema.ASP.Models
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
        public D.UserRole Role { get; set; }

        public User()
        {

        }
        public User(D.User entity)
        {
            Id = entity.Id;
            Login = entity.Login;
            Email = entity.Email;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Password = entity.Password;
            Salt = entity.Salt;
            Role = entity.Role;
        }

        public void Deconstruct(out int id, out string login, out string email, out string first_name, out string last_name, out string password, out string salt, out D.UserRole role)
        {
            id = Id;
            login = Login;
            email = Email;
            first_name = FirstName;
            last_name = LastName;
            password = Password;
            salt = Salt;
            role = Role;
        }
    }
}