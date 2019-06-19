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
            var query = $"CALL add_session('{session.username}', '{session.rooms}', '{session.stepratio}', '{session.date.ToString("yyyy-mm-dd")}');";
            wrapper.query(query);
        }

        public IEnumerable<ISession> getLeaderboard(DateTime minDate, int count)
        {
            var query = $"CALL get_leaderboard('{minDate.ToString("yyyy-MM-dd")}', {count})";
            return wrapper.query(query).ConvertTable<SessionDTO>();
        }
    }
}
