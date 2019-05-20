using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    public class UserRepository
    {
        private IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public void AddUser(IUser user)
        {
            _context.AddUser(user);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _context.GetAllUsers();
        }

        public IUser GetUserByCredentials(string username, string password)
        {
            return _context.GetUserByCredentials(username, password);

        }

        public IUser GetUserById(int id)
        {
            return _context.GetUserById(id);
        }

        public void RemoveUser(IUser user)
        {
            _context.RemoveUser(user);
        }
    }
}
