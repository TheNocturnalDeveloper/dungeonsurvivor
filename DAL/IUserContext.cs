using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    public interface IUserContext
    {
        IUser GetUserById(int id);

        int? GetUserId(string username);

        IEnumerable<IUser> GetAllUsers();

        void AddUser(IUser user);

        void RemoveUser(string username);

        IUser CheckCredentials(string username, string password);

        string GetRole(string username);
    }
}