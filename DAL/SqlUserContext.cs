using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Linq;
using DAL.Dtos;

namespace DAL
{
    public class SqlUserContext : IUserContext
    {
        private MysqlWrapper wrapper;

        public SqlUserContext(string connectionString)
        {
            wrapper = new MysqlWrapper(connectionString);
        }

        public void AddUser(IUser user)
        {
            try
            {
                var query = $"CALL create_user('{user.username}', '{user.password}');";
                wrapper.query(query);
            }
            catch
            {
                throw new Exception("database error");
            }
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            var query = $"SELECT * FROM user";
            return wrapper.query(query).ConvertTable<UserDTO>();
        }

        public IUser CheckCredentials(string username, string password)
        {
            var query = $"SELECT * FROM user WHERE username = '{username}' AND password = '{password}';";
            var result = wrapper.query(query).ConvertTable<UserDTO>();

            if(result.Count == 1)
            {
                return result.First();
            }

            return null;
        }

        public IUser GetUserById(int id)
        {
            var query = $"SELECT * FROM user WHERE id = {id};";

            var result = wrapper.query(query).ConvertTable<UserDTO>();

            if (result.Count == 1)
            {
                return result.First();
            }

            return null;
        }

        public void RemoveUser(string username)
        {
            var query = $"DELETE FROM user WHERE username = {username};";

            wrapper.query(query);
 
        }


        public int? GetUserId(string username)
        {
            var query = $"SELECT * FROM user WHERE username = '{username}';";

            var result = wrapper.query(query).ConvertTable<UserDTO>();

            if (result.Count == 1)
            {
                return result.First().id;
            }

            return null;
        }

       public string GetRole(string username)
        {
            var query = $"SELECT name FROM role INNER JOIN user ON user.role_id = role.id WHERE username = '{username}';";

            var result = wrapper.query(query);

            if (result.Count == 1)
            {
                return result.First().getFieldByName("name").value;
            }

            return null;
        }

    }
}
