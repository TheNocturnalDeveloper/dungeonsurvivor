using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DungeonSurvivor.Models
{
    public class AddSpriteViewModel
    {
        public string name { get; set; }
        public int price { get; set; }
        public IFormFile image { get; set; }
    }
}
