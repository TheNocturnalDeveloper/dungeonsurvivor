using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonSurvivor.Models
{
    public class BuySpriteModel
    {
   
        
        public string name { get; set; }

      
     
        public int price { get; set; }

        public bool unlocked { get; set; }
    }
}
