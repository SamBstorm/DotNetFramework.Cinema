using System;

namespace Cinema.DAL.Global.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string synopsis { get; set; }
        public int? release_year { get; set; }
        public string poster_uri { get; set; }
        public int? category_id { get; set; }
    }
}
