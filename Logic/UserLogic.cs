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
            throw new NotImplementedException("add user has not been implemented yet");
        }

        public void removeUser(IUser user)
        {
            context.RemoveUser(user);
        }


        public IEnumerable<IUser> getAllUsers()
        {
            return context.GetAllUsers();
        }


        public IUser getUserByCredentials(string username, string password)
        {
            return context.GetUserByCredentials(username, password);
        }


    }
}
