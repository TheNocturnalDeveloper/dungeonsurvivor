using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using DAL.Dtos;

namespace DAL
{
    public class SqlSessionContext : ISessionContext
    {
        private MysqlWrapper wrapper;

        public SqlSessionContext(string connectionString)
        {
            wrapper = new MysqlWrapper(connectionString);
        }

        public void addSession(ISession session)
        {
            var query = $"CALL add_user(, );";
            wrapper.query(query);
        }

        public IEnumerable<ISession> getLeaderboard(DateTime minDate)
        {
            var query = $"CALL get_leaderboard('{minDate.ToString("yyyy-mm-dd")}')";
            return wrapper.query(query).ConvertTable<SessionDTO>();
        }
    }
}
