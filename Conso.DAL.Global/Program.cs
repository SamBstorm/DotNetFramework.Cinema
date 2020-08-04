using Cinema.DAL.Global.Models;
using Cinema.DAL.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conso.DAL.Global
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovieRepository<int, Movie> movieRepo = new MovieRepository();

            Movie m = movieRepo.Get(1);
            Console.WriteLine($"{m.title}");

            IUserRepository<int, User> repo = new UserRepository();

            repo.Delete(6);             //Utilisé pour garantir une unicité dans la table User - Attention, s'auto-incrémente...

            int id = repo.Insert(new User { login = "Sam", email = "sam@fait.rire", first_name = "Samuel", last_name = "Legrain", password = "test1234=", salt = "toto", role = "ADMIN" });
            Console.WriteLine($"{id}");

            User u = repo.Get(id);      //Attention, le password est remplacé par des "********"

            Console.WriteLine(u.first_name);

            u.password = "test1234=";   //Ne pas oublier de tester avec le bon password...
            u = repo.Check(u);

            Console.WriteLine(u.id);

            Console.ReadLine();
        }
    }
}
