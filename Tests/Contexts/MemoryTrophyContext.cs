using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Linq;
using Interfaces;
using Tests.Dto;

namespace Tests.Contexts
{
    class MemoryTrophyContext : ITrophyContext
    {
        private List<TrophyDTO> trophies;


        public MemoryTrophyContext()
        {
            trophies = new List<TrophyDTO>();
        }

        public IEnumerable<ITrophy> GetAllTrophies()
        {
            return trophies;
        }

        public IEnumerable<ITrophy> GetUserTrophies(string username)
        {
            throw new NotImplementedException();
        }

        public void UnlockTrophy(string username, string trophyName)
        {
            throw new NotImplementedException();
        }
    }
}
