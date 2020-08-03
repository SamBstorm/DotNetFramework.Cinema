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
    public class CastRepository : BasicRepository, ICastRepository<(int movie_id, int actor_id), Cast>
    {
        public bool Delete((int movie_id, int actor_id) ids)
        {
            Command command = new Command("DELETE FROM Cast WHERE movie_id = @mid AND actor_id = @aid");
            command.AddParameter("mid", ids.movie_id);
            command.AddParameter("aid", ids.actor_id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Cast> Get()
        {
            Command command = new Command("SELECT movie_id, actor_id, character_name FROM Cast");
            return _connection.ExecuteReader(command, (reader) => reader.ToCast());
        }

        public Cast Get((int movie_id, int actor_id) ids)
        {
            Command command = new Command("SELECT movie_id, actor_id, character_name FROM Cast WHERE movie_id = @mid AND actor_id = @aid");
            command.AddParameter("mid", ids.movie_id);
            command.AddParameter("aid", ids.actor_id);
            return _connection.ExecuteReader(command, (reader) => reader.ToCast()).Single();
        }

        public (int movie_id, int actor_id) Insert(Cast entity)
        {
            Command command = new Command("INSERT INTO Cast VALUES (@mid,@aid,@cn)");
            command.AddParameter("mid", entity.movie_id);
            command.AddParameter("aid", entity.actor_id);
            command.AddParameter("cn", entity.character_name);
            return (entity.movie_id, entity.actor_id);
        }

        public bool Update((int movie_id, int actor_id) ids, Cast entity)
        {
            Command command = new Command("UPDATE Cast SET character_name = @cn WHERE movie_id = @mid AND actor_id = @aid");
            command.AddParameter("mid", entity.movie_id);
            command.AddParameter("aid", entity.actor_id);
            command.AddParameter("cn", entity.character_name);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
