using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Tests.Contexts;
using System.Linq;

namespace Tests
{
    public class SpriteTest
    {
        SpriteLogic logic;

        public SpriteTest()
        {
            logic = new SpriteLogic(new MemorySpriteContext());
        }

        [Fact]
        void TestAddSprites()
        {
            logic.AddSprite("test", "test", 500);
            Assert.True(logic.getAllSprites().Count() == 2);
        }

        [Fact]
        void testGetAllSprites()
        {
            Assert.True(logic.getAllSprites().Count() == 1);
        }

        [Fact]
        void testGetUserSprites()
        {
            logic.AddSprite("test", "test", 500);
            logic.unlockSprite("jake", "test");
            Assert.True(logic.getSpritesByUsername("jake").Count() == 1);
        }

        [Fact]
        void testCanBuySprite()
        {
            logic.AddSprite("test", "test", 500);
            Assert.True(logic.canBuySprite("jake", "test"));
        }

        [Fact]
        void testHasSprite()
        {
            logic.AddSprite("test", "test", 500);
            logic.unlockSprite("jake", "test");
            Assert.True(logic.hasSprite("jake", "test"));
        }

        [Fact]
        void testUnlockSprite()
        {
            logic.AddSprite("test", "test", 500);
            logic.unlockSprite("jake", "test");
            Assert.True(logic.hasSprite("jake", "test"));
        }

    }
}
