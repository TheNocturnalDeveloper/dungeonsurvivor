using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace DAL
{
    interface ISpriteContext
    {
        IEnumerable<ISprite> getSpritesByUsername(string username);
        void unlockSprite(string username, string spriteName);
        void addSprite(ISprite sprite);
        void removeSprite(string spriteName);
        IEnumerable<ISprite> getAllSprites();
    }
}
