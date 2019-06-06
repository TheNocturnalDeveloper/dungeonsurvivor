using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Logic
{
    class UserModel : IUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
