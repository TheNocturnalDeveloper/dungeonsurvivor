using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace DAL
{
    public interface ISpriteContext
    {
        IEnumerable<ISprite> getSpritesByUsername(string username);
        void unlockSprite(string username, string spriteName);
        void addSprite(ISprite sprite);
        IEnumerable<ISprite> getAllSprites();
        ISprite getSpriteByName(string spriteName);
        bool canBuySprite(string username, string spriteName);
    }
}
