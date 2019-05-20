using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Linq;

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
            var query = $"CALL add_user({user.username}, {user.password});";
            wrapper.query(query);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            var query = $"SELECT * FROM user";
            return wrapper.query(query).ConvertTable<UserModel>();
        }

        public IUser GetUserByCredentials(string username, string password)
        {
            var query = $"SELECT * FROM user WHERE username = '{username}' AND password = '{password}';";
            var result = wrapper.query(query).ConvertTable<UserModel>();

            if(result.Count == 1)
            {
                return result.First();
            }

            return null;
        }

        public IUser GetUserById(int id)
        {
            var query = $"SELECT * FROM user WHERE id = {id};";

            var result = wrapper.query(query).ConvertTable<UserModel>();

            if (result.Count == 1)
            {
                return result.First();
            }

            return null;
        }

        public void RemoveUser(IUser user)
        {
            var query = $"DELETE FROM user WHERE username = {user.username};";

            wrapper.query(query);
 
        }
    }
}
