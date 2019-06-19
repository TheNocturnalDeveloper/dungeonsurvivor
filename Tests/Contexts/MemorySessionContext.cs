using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;
using Tests.Dto;
using System.Linq;

namespace Tests.Contexts
{
    public class MemorySessionContext : ISessionContext
    {
        private List<SessionDTO> sessions;

        public MemorySessionContext()
        {
            sessions = new List<SessionDTO>();
        }

        public void addSession(ISession session)
        {

            var entry = new SessionDTO {
                date = session.date,
                rooms = session.rooms,
                stepratio = session.stepratio,
                username = session.username
            };

            sessions.Add(entry);
        }

        public IEnumerable<ISession> getLeaderboard(DateTime minDate, int count)
        {
            return sessions.Where(s => s.date > minDate).OrderByDescending(s => s.rooms).Take(count);
        }
    }
}
