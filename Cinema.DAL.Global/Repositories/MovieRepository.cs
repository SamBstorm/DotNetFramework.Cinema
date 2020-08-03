using Cinema.DAL.Global.Mapper;
using Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ToolBox.ADO;

namespace Cinema.DAL.Global.Repositories
{
    public class MovieRepository : BasicRepository, IMovieRepository<int, Movie>
    {
        public bool Delete(int id)
        {
            Command command = new Command("DELETE FROM Movie WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Movie> Get()
        {
            Command command = new Command("SELECT id, title, synopsis, release_year, poster_uri, category_id FROM Movie");
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie());
        }

        public Movie Get(int id)
        {
            Command command = new Command("SELECT id, title, synopsis, release_year, poster_uri, category_id FROM Movie WHERE id = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie()).Single();
        }

        public IEnumerable<Movie> GetByActorId(int actorId)
        {
            Command command = new Command("SELECT id, title, synopsis, release_year, poster_uri, category_id FROM Movie WHERE id IN (SELECT movie_id FROM Cast WHERE actor_id = @id)");
            command.AddParameter("id", actorId);
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie());
        }

        public IEnumerable<Movie> GetByCategoryId(int categoryId)
        {
            Command command = new Command("SELECT id, title, synopsis, release_year, poster_uri, category_id  FROM Movie WHERE category_id = @id");
            command.AddParameter("id", categoryId);
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie());
        }

        public IEnumerable<Movie> GetByKeyword(params string[] keywords)
        {
            string sqlQuery = "SELECT id, title, synopsis, release_year, poster_uri, category_id FROM Movie WHERE title LIKE (CONCAT('%',@kw0,'%')) OR synopsis LIKE (CONCAT('%',@kw0,'%'))";
            for (int i = 1; i < keywords.Length; i++)
            {
                sqlQuery += $" OR title LIKE (CONCAT('%',@kw{i},'%')) OR synopsis LIKE (CONCAT('%',@kw{i},'%'))";
            }
            Command command = new Command(sqlQuery);
            for (int i = 0; i < keywords.Length; i++)
            {
                command.AddParameter("kw" + i, keywords[i]);
            }
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie());
        }

        public IEnumerable<Movie> GetByReleaseYear(int releaseYear)
        {
            Command command = new Command("SELECT id, title, synopsis, release_year, poster_uri, category_id FROM Movie WHERE release_year = @year");
            command.AddParameter("year", releaseYear);
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie());
        }

        public IEnumerable<Movie> GetByTitle(string title)
        {
            Command command = new Command("SELECT id, title, synopsis, release_year, poster_uri, category_id FROM Movie WHERE title LIKE @title");
            command.AddParameter("title", title);
            return _connection.ExecuteReader(command, (reader)=>reader.ToMovie());
        }

        public int Insert(Movie entity)
        {
            Command command = new Command("INSERT INTO Movie(title,synopsis,release_year,poster_uri,category_id) OUTPUT INSERTED.id VALUES (@title,@synopsis,@release_year,@poster_uri,@category_id)");
            command.AddParameter("title", entity.title);
            command.AddParameter("synopsis", (object)entity.synopsis ?? DBNull.Value);
            command.AddParameter("release_year", (object)entity.release_year ?? DBNull.Value);
            command.AddParameter("poster_uri", (object)entity.poster_uri ?? DBNull.Value);
            command.AddParameter("category_id", (object)entity.category_id ?? DBNull.Value);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(int id, Movie entity)
        {
            Command command = new Command("UPDATE Movie SET title = @title, synopsis = @synopsis, release_year = @release_year, poster_uri = @poster_uri, category_id = @category_id WHERE id = @id");
            command.AddParameter("id", id);
            command.AddParameter("title", entity.title);
            command.AddParameter("synopsis", (object)entity.synopsis ?? DBNull.Value);
            command.AddParameter("release_year", (object)entity.release_year ?? DBNull.Value);
            command.AddParameter("poster_uri", (object)entity.poster_uri ?? DBNull.Value);
            command.AddParameter("category_id", (object)entity.category_id ?? DBNull.Value);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
