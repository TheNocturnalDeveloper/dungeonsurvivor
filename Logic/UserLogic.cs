using System;
using DAL;
using Interfaces;
using System.Collections.Generic;


namespace Logic
{
    public class UserLogic
    {
        private IUserContext context { get; }

        public UserLogic(IUserContext context)
        {
            this.context = context;
            
        }

        public void addUser(string username, string password)
        {
            var user = new UserModel { username = username, password = password };
            context.AddUser(user);
        }

        public void removeUser(string username)
        {
            context.RemoveUser(username);
        }


        public IEnumerable<IUser> getAllUsers()
        {
            return context.GetAllUsers();
        }


        public IUser CheckCredentials(string username, string password)
        {
            return context.CheckCredentials(username, password);
        }

        public int? GetUserId(string username)
        {
            return context.GetUserId(username);
        }

        public IUser GetUserById(int id)
        {
           var result = context.GetUserById(id);

           return result == null ? null : new UserModel { username = result.username, password = result.username };
        }
    }
}
