using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G = Cinema.DAL.Global.Models;

namespace Cinema.DAL.Client.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(G.Category entity)
        {
            Id = entity.id;
            Name = entity.name;
            Description = entity.description;
        }
    }
}
