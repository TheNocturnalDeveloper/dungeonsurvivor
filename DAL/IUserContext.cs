using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    public interface IUserContext
    {
        IUser GetUserById(int id);

        IEnumerable<IUser> GetAllUsers();

        void AddUser(IUser user);

        void RemoveUser(IUser user);

        IUser GetUserByCredentials(string username, string password);
    }
}


//var users = wrapper.query("").convertToTable<User>();