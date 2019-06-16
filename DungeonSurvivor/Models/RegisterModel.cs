﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DungeonSurvivor.Models
{
    public class RegisterModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public RegisterModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public RegisterModel()
        {

        }
    }
}
