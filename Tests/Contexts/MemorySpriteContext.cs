using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;
using Tests.Dto;
using System.Linq;

namespace Tests.Contexts
{
    class MemorySpriteContext : ISpriteContext
    {
        private List<SpriteDTO> sprites;
        private Dictionary<string, List<SpriteDTO>> userSprites;

        public MemorySpriteContext()
        {
            sprites = new List<SpriteDTO>();
            userSprites = new Dictionary<string, List<SpriteDTO>>();
        }

        public void addSprite(ISprite sprite)
        {
            var entry = new SpriteDTO
            {
                name = sprite.name,
                path = sprite.path,
                price = sprite.price,          
            };

            sprites.Add(entry);
        }

        public IEnumerable<ISprite> getAllSprites()
        {
            return sprites;
        }

        public IEnumerable<ISprite> getSpritesByUsername(string username)
        {
          if()
        }


        public void unlockSprite(string username, string spriteName)
        {
            
        }
    }
}
