using System;

namespace Cinema.DAL.Global.Models
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string role { get; set; }
    }
}
