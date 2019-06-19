using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;

namespace Logic
{
    public class SessionLogic
    {
        private ISessionContext context;

        public SessionLogic(ISessionContext context)
        {
            this.context = context;
        }

        public void addSession(string username, int rooms, int stepratio)
        {
            var entry = new SessionModel { username = username, rooms = rooms, stepratio = stepratio };
            context.addSession(entry);
        }

        public IEnumerable<ISession> getLeaderBoard(DateTime date, int count)
        {
            return context.getLeaderboard(date, count);
        }
    }
}
