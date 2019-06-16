using Interfaces;

namespace Logic
{
    internal class UserModel : IUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
