using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Tests.Contexts;

namespace Tests
{
    class SpriteTest
    {
        SpriteLogic logic;

        public SpriteTest()
        {
            logic = new SpriteLogic(new MemorySpriteContext());
        }


    }
}
