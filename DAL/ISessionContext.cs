using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    interface ISessionContext
    {
        IEnumerable<ISession> getLeaderboard(DateTime minDate);
        void addSession(ISession session);
        
    }
}
     