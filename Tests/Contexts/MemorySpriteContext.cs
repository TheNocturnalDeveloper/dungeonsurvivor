using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;
using Tests.Dto;
using System.Linq;

namespace Tests.Contexts
{
    public class MemorySpriteContext : ISpriteContext
    {
        private List<SpriteDTO> sprites;
        private Dictionary<string, List<SpriteDTO>> userSprites;
        private List<(UserDTO user, int points)> users;

        public MemorySpriteContext()
        {
            sprites = new List<SpriteDTO>();
            sprites.Add(new SpriteDTO { name = "idk", path = "idk", price = 2000 });

            userSprites = new Dictionary<string, List<SpriteDTO>>();
            userSprites.Add("jake", new List<SpriteDTO>());
            

            

            users = new List<(UserDTO user, int points)>
            {
                (new UserDTO {username = "jake" }, 1000)
            };
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

        public bool canBuySprite(string username, string spriteName)
        {
            return users.Single(u => u.user.username == username).points >= sprites.Single(s => s.name == spriteName).price;
        }

        public IEnumerable<ISprite> getAllSprites()
        {
            return sprites;
        }

        public ISprite getSpriteByName(string spriteName)
        {
            return sprites.Single(s => s.name == spriteName);
        }

        public IEnumerable<ISprite> getSpritesByUsername(string username)
        {
           return userSprites.GetValueOrDefault(username);
        }

        public bool hasSprite(string username, string spriteName)
        {
           var sprites = userSprites.GetValueOrDefault(username);

            return sprites.Exists(s => s.name == spriteName);
        }

        public void unlockSprite(string username, string spriteName)
        {
            userSprites.GetValueOrDefault(username).Add(sprites.Single(s => s.name == spriteName));
        }
    }
}
