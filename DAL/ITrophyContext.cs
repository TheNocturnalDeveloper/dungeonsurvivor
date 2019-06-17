using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    public interface ITrophyContext
    {
        IEnumerable<ITrophy> GetAllTrophies();
        void UnlockTrophy(string username, string trophyName);
        IEnumerable<ITrophy> GetUserTrophies(string username);
    }
}
