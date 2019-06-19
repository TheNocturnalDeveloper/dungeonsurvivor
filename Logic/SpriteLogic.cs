using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;

namespace Logic
{
    public class SpriteLogic
    {
        private ISpriteContext context;

        public SpriteLogic(ISpriteContext context)
        {
            this.context = context;
        }

        public void AddSprite(string name, string path, int price)
        {
            var entry = new SpriteModel { name = name, path = path, price = price };

            context.addSprite(entry);
        }

        public IEnumerable<ISprite> getAllSprites()
        {
            return context.getAllSprites();
        }

        public IEnumerable<ISprite> getSpritesByUsername(string username)
        {
            return context.getSpritesByUsername(username);
        }

        public void unlockSprite(string username, string spriteName)
        {
            context.unlockSprite(username, spriteName);
        }

        public ISprite getSpriteByName(string spriteName)
        {
            return context.getSpriteByName(spriteName);
        }

        public bool canBuySprite(string username, string spritename)
        {
            return context.canBuySprite(username, spritename);
        }

        public bool hasSprite(string username, string spriteName)
        {
            return context.hasSprite(username, spriteName);
        }
    }
}
