using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Linq;
using DAL;
using Tests.Dto;


namespace Tests
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
            var id = users.Count() > 0 ? users.Max(u => u.id) + 1 : 1;


            var newUser = new UserDTO()
            {
                username = user.username,
                password = user.password,
                id = id,
                role = "normal"
                
            };

            users.Add(newUser);
        }

        public IUser CheckCredentials(string username, string password)
        {
            if (users.Exists(u => u.username == username && u.password == password))
            {
                return users.Find(u => u.username == username && u.password == password);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return users;
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

        public int? GetUserId(string username)
        {
            if (users.Exists(u => u.username == username))
            {
                return users.Single(u => u.username == username).id;
            }
            else
            {
                return null;
            }
        }

        public void RemoveUser(string username)
        {
            if (users.Exists(u => u.username == username))
            {
                users.Remove(users.Single(u => u.username == username));
            }
        }


        public string GetRole(string username)
        {
            if (users.Exists(u => u.username == username))
            {
                return users.Single(u => u.username == username).role;
            }
            else
            {
                return null;
            }
        }

    }
}
