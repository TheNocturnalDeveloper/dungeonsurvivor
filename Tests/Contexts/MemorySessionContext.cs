using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;
using Tests.Dto;
using System.Linq;

namespace Tests.Contexts
{
    class MemorySessionContext : ISessionContext
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
                stepRatio = session.stepRatio,
                username = session.username
            };

            sessions.Add(entry);
        }

        public IEnumerable<ISession> getLeaderboard(DateTime minDate)
        {
            return sessions.Where(s => s.date > minDate);
        }
    }
}
