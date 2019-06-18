using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonSurvivor.Models
{
    public class ShowSpriteModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string path { get; set; }
    }
}
