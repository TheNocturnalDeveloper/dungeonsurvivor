using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Linq;

namespace DAL
{
    public class MemoryUserContext : IUserContext
    {
        List<UserDTO> users;
        public MemoryUserContext()
        {
            users = new List<UserDTO>();
        }
        

        public void AddUser(IUser user)
        {
            var newUser = new UserDTO()
            {
                username = user.username,
                password = user.password,
                id = users.Max(u => u.id) + 1
            };

            users.Add(newUser);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return users;
        }

        public IUser GetUserByCredentials(string username, string password)
        {
            if(users.Exists(u => u.username == username && u.password == password))
            {
                return users.Find(u => u.username == username && u.password == password);
            }
            else
            {
                return null;
            }
           
        }

        public IUser GetUserById(int id)
        {
            if (users.Exists(u => u.id == id))
            {

                return users.Find(u => u.id == id);
            }
            else
            {
                return null;
            }
        }

        public void RemoveUser(IUser user)
        {
            if (users.Exists(u => u.username == user.username && u.password == user.password))
            {
                users.Remove(users.Find(u => u.username == user.username && u.password == user.password));
            }
            else
            {
                throw new Exception("user doesn't exist");
            }
        }
    }
}
