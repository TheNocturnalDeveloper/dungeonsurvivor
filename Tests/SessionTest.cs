using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Tests.Contexts;

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
        void testAddSprite()
        {

        }
    }
}
