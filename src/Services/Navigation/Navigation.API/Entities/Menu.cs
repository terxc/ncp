using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navigation.API.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public Menu Parent { get; set; }
    }
}
