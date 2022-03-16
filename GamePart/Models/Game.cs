using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePart.Models
{
    public class Game
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string Pic { get; set; }
    }
}
