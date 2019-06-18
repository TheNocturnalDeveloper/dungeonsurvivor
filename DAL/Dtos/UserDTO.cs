using System;
using Interfaces;

namespace DAL.Dtos
{
    internal class UserDTO : IUser
    {
        [TableField]
        public int id { get; set; }

        [TableField]
        public string username { get; set; }

        [TableField]
        public string password { get; set; }


        [TableField]
        public int points { get; set; }
    }
}
