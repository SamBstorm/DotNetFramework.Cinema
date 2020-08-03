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
            IMovieRepository<int,Movie> repo = new MovieRepository();

            Movie nemo = repo.Get(1);
            nemo.title = "Le monde de Némo";
            repo.Update(1, nemo);

            foreach(Movie movie in repo.Get())
            {
                Console.WriteLine($"{movie.id} : {movie.title}");
            }

            Console.ReadLine();
        }
    }
}
