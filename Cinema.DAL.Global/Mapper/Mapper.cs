using Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Mapper
{
    public static class Mapper
    {
        public static Movie ToMovie(this IDataRecord reader)
        {
            if (reader == null) return null;
            return new Movie
            {
                id = (int)reader[nameof(Movie.id)],
                title = (string)reader[nameof(Movie.title)],
                synopsis = (reader[nameof(Movie.synopsis)] == DBNull.Value) ? null : (string)reader[nameof(Movie.synopsis)],
                release_year = (reader[nameof(Movie.release_year)] == DBNull.Value) ? null : (int?)reader[nameof(Movie.release_year)],
                poster_uri = (reader[nameof(Movie.poster_uri)] == DBNull.Value) ? null : (string)reader[nameof(Movie.poster_uri)],
                category_id = (reader[nameof(Movie.category_id)] == DBNull.Value) ? null : (int?)reader[nameof(Movie.category_id)]
            };
        }

        public static User ToUser(this IDataRecord reader)
        {
            if (reader == null) return null;
            return new User
            {
                id = (int)reader[nameof(User.id)],
                login = (string)reader[nameof(User.login)],
                email = (string)reader[nameof(User.email)],
                last_name = (string)reader[nameof(User.last_name)],
                first_name = (string)reader[nameof(User.first_name)],
                password = "*********",                         //Ici, c'est une faille de sécurité de récupérer le mot de passe de l'utilisateur, remplacer la méthode (string)reader[nameof(User.password)] par des "*********" permet de ne jamais récupérer le mot de passe
                salt = (string)reader[nameof(User.salt)],
                role = (string)reader[nameof(User.role)]
            };
        }

        public static Actor ToActor(this IDataRecord reader)
        {
            if (reader == null) return null;
            return new Actor
            {
                id = (int)reader[nameof(Actor.id)],
                first_name = (string)reader[nameof(Actor.first_name)],
                last_name = (string)reader[nameof(Actor.last_name)],
                birth_date = (reader[nameof(Actor.birth_date)] == DBNull.Value) ? null : (DateTime?)reader[nameof(Actor.birth_date)],
                image_uri = (reader[nameof(Actor.image_uri)] == DBNull.Value) ? null : (string)reader[nameof(Actor.image_uri)]
            };
        }
        public static Category ToCategory(this IDataRecord reader)
        {
            if (reader == null) return null;
            return new Category
            {
                id = (int)reader[nameof(Category.id)],
                name = (string)reader[nameof(Category.name)],
                description = (reader[nameof(Category.description)] == DBNull.Value) ? null : (string)reader[nameof(Category.description)]
            };
        }
        public static Cast ToCast(this IDataRecord reader)
        {
            if (reader == null) return null;
            return new Cast
            {
                movie_id = (int)reader[nameof(Cast.movie_id)],
                actor_id = (int)reader[nameof(Cast.actor_id)],
                character_name = (reader[nameof(Cast.character_name)] == DBNull.Value) ? null : (string)reader[nameof(Cast.character_name)]
            };
        }
    }
}
