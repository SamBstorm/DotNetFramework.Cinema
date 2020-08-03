using Cinema.DAL.Global.Mapper;
using Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace Cinema.DAL.Global.Repositories
{
    public class UserRepository : BasicRepository, IUserRepository<int, User>
    {
        public User Check(User entity)
        {
            string sqlQueryLogin = "SELECT id, login, email, last_name, first_name, salt, role FROM User WHERE login = @identifier AND encoded_password = HASHBYTES('SHA2_512', @password + salt)";
            string sqlQueryEmail = "SELECT id, login, email, last_name, first_name, salt, role FROM User WHERE email = @identifier AND encoded_password = HASHBYTES('SHA2_512', @password + salt)";
            Command command = new Command((entity.login !=null) ? sqlQueryLogin : sqlQueryEmail);
            command.AddParameter("identifier", entity.login ?? entity.email);
            command.AddParameter("password", entity.password);
            return _connection.ExecuteReader(command, (reader)=> reader.ToUser()).Single();
        }

        public bool Delete(int id)
        {
            Command command = new Command("DELETE FROM User WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<User> Get()
        {
            Command command = new Command("SELECT id, login, email, last_name, first_name, salt, role FROM User");
            return _connection.ExecuteReader(command, (reader) => reader.ToUser());
        }

        public User Get(int id)
        {
            Command command = new Command("SELECT id, login, email, last_name, first_name, salt, role FROM User WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToUser()).Single();
        }

        public int Insert(User entity)
        {
            Command command = new Command("INSERT INTO User(login, email, last_name, first_name, encoded_password, salt, role) OUT INSTERTED.id VALUES(@login, @email, @last_name, @first_name, HASHBYTES('SHA2_512',@password + @salt), @salt, @role)");
            command.AddParameter("login", entity.login);
            command.AddParameter("email", entity.email);
            command.AddParameter("last_name", entity.last_name);
            command.AddParameter("first_name", entity.first_name);
            command.AddParameter("password", entity.password);
            command.AddParameter("salt", entity.salt);
            command.AddParameter("role", entity.role);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(int id, User entity)
        {
            Command command = new Command("UPDATE User SET last_name = @last_name, first_name = @first_name, role = @role WHERE id = @id");
            command.AddParameter("id", id);
            command.AddParameter("last_name", entity.last_name);
            command.AddParameter("first_name", entity.first_name);
            command.AddParameter("role", entity.role);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
