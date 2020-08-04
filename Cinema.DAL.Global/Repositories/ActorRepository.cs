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
    public class ActorRepository : BasicRepository, IActorRepository<int, Actor>
    {
        public bool Delete(int id)
        {
            Command command = new Command("DELETE FROM Actor WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Actor> Get()
        {
            Command command = new Command("SELECT id,first_name,last_name,birth_date,image_uri FROM Actor");
            return _connection.ExecuteReader(command, (reader) => reader.ToActor());
        }

        public Actor Get(int id)
        {
            Command command = new Command("SELECT id,first_name,last_name,birth_date,image_uri FROM Actor WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToActor()).Single();
        }

        public IEnumerable<Actor> GetByMovieId(int movieId)
        {
            Command command = new Command("SELECT id,first_name,last_name,birth_date,image_uri FROM Actor WHERE id IN (SELECT actor_id FROM Cast WHERE movie_id = @id)");
            command.AddParameter("id", movieId);
            return _connection.ExecuteReader(command, (reader) => reader.ToActor());
        }

        public int Insert(Actor entity)
        {
            Command command = new Command("INSERT INTO Actor(first_name,last_name, birth_date, image_uri) OUTPUT INSERTED.id VALUES(@fn,@ln,@bd,@iu)");
            command.AddParameter("fn", entity.first_name);
            command.AddParameter("ln", entity.last_name);
            command.AddParameter("bd", (object)entity.birth_date ?? DBNull.Value);
            command.AddParameter("iu", (object)entity.image_uri ?? DBNull.Value);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(int id, Actor entity)
        {
            Command command = new Command("UPDATE Actor SET first_name = @fn,last_name=@ln, birth_date=@bd, image_uri=@iu WHERE id = @id");
            command.AddParameter("id", id);
            command.AddParameter("fn", entity.first_name);
            command.AddParameter("ln", entity.last_name);
            command.AddParameter("bd", (object)entity.birth_date ?? DBNull.Value);
            command.AddParameter("iu", (object)entity.image_uri ?? DBNull.Value);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
