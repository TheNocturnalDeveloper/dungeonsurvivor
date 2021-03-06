﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DungeonSurvivor.Models
{
    public class AddSpriteViewModel
    {

        [Required]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int price { get; set; }


        [Required]
        public IFormFile image { get; set; }
    }
}
