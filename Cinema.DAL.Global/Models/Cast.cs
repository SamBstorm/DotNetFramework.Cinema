using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Models
{
    public class Cast
    {
        public int movie_id { get; set; }
        public int actor_id { get; set; }
        public string character_name { get; set; }
    }
}
