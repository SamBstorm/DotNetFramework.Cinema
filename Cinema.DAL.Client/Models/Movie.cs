using C = Cinema.DAL.Client.Models;
using G = Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Client.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int? ReleaseYear { get; set; }
        public string PosterURI { get; set; }
        private int? CategoryId { get; set; }

        public C.Category Category { get; set; } //Service de Category

        public Movie(G.Movie entity)
        {
            Id = entity.id;
            Title = entity.title;
            Synopsis = entity.synopsis;
            ReleaseYear = entity.release_year;
            PosterURI = entity.poster_uri;
            CategoryId = entity.category_id;
        }
    }
}
