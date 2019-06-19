using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Tests.Dto
{
    internal class UserDTO : IUser
    {
        public int id {get; set;}
        public string username { get; set; }
        public string password { get; set; }

        public string role { get; set; }

    }
}
