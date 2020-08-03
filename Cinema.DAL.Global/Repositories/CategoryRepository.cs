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
    public class CategoryRepository : BasicRepository, ICategoryRepository<int, Category>
    {
        public bool Delete(int id)
        {
            Command command = new Command("DELETE FROM Category WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT id, name, description FROM Category");
            return _connection.ExecuteReader(command, (reader) => reader.ToCategory());
        }

        public Category Get(int id)
        {
            Command command = new Command("SELECT id, name, description FROM Category WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToCategory()).Single();
        }

        public int Insert(Category entity)
        {
            Command command = new Command("INSERT INTO Category(name, description) OUTPUT INSERTED.id VALUES ( @name, @description)");
            command.AddParameter("name", entity.name);
            command.AddParameter("description", (object)entity.description ?? DBNull.Value);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(int id, Category entity)
        {
            Command command = new Command("UPDATE Category SET name = @name, description = @description WHERE id = @id");
            command.AddParameter("id", id);
            command.AddParameter("name", entity.name);
            command.AddParameter("description", (object)entity.description ?? DBNull.Value);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
