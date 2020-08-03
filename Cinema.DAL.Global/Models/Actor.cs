using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Global.Models
{
    public class Actor
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public DateTime? birth_date { get; set; }
        public string image_uri { get; set; }
    }
}
