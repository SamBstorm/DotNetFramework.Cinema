using C = Cinema.DAL.Client.Models;
using G = Cinema.DAL.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DAL.Client.Services;
using Cinema.DAL.Global.Repositories;

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
        private C.Category _category;
        public C.Category Category { get
            {
                if (_category is null) {
                    if (!(this.CategoryId is null))
                    {
                        ICategoryRepository<int, C.Category> service = new CategoryService();
                        _category = service.Get((int)this.CategoryId);
                    }
                    else _category = null;
                }
                return _category;  }
            set { CategoryId = value.Id; } } //Service de Category

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
