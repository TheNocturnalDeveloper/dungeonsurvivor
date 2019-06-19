using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Tests.Contexts;
using System.Linq;

namespace Tests
{
    public class SessionTest
    {
        SessionLogic logic;

        public SessionTest()
        {
            logic = new SessionLogic(new MemorySessionContext());
        }

        [Fact]
        void testAddSession()
        {
            logic.addSession("jake", 5, 1, DateTime.Now.AddDays(-10));
            Assert.True(logic.getLeaderBoard(DateTime.Now.AddDays(-20), 10).Count() == 2);
        }


        [Fact]
        void testGetLeaderboard()
        {
            Assert.True(logic.getLeaderBoard(DateTime.Now.AddDays(-20), 10).Count() == 1);
        }

        [Fact]
        void testGetLeaderboardWithDate()
        {
            Assert.True(logic.getLeaderBoard(DateTime.Now, 10).Count() == 0);
        }




    }
}
