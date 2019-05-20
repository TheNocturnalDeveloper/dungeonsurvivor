using System;
using Interfaces;

namespace DAL
{
    public class UserModel : IUser
    {
        public int id { get; set; }

        [TableField]
        public string username { get; set; }

        [TableField]
        public string password { get; set; }

    }
}
