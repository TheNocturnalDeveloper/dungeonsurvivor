﻿using System;
using Interfaces;

namespace DAL.DTO
{
    internal class UserDTO : IUser
    {
        [TableField]
        public int id { get; set; }

        [TableField]
        public string username { get; set; }

        [TableField]
        public string password { get; set; }

    }
}
