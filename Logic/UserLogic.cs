using System;
using DAL;
using Interfaces;
using System.Collections.Generic;


namespace Logic
{
    public class UserLogic
    {
        private UserRepository repository { get; }

        public UserLogic(IUserContext context)
        {
            repository = new UserRepository(context);
            
        }

        public void addUser(string username, string password)
        {
            throw new NotImplementedException("add user has not been implemented yet");
        }

        public void removeUser(IUser user)
        {
            repository.RemoveUser(user);
        }


        public IEnumerable<IUser> getAllUsers()
        {
            return repository.GetAllUsers();
        }


        public IUser getUserByCredentials(string username, string password)
        {
            return repository.GetUserByCredentials(username, password);
        }


    }
}
