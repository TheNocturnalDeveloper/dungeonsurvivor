using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using DAL.Dtos;
using System.Linq;

namespace DAL
{
    public class SqlSpriteContext : ISpriteContext
    {
        private MysqlWrapper wrapper;
        public SqlSpriteContext(string connectionString)
        {
            wrapper = new MysqlWrapper(connectionString);
        }

        public void addSprite(ISprite sprite)
        {
            string query = $"INSERT INTO sprite (price, path, name) VALUES ('{sprite.price}', '{sprite.path}', '{sprite.name}');";
            wrapper.query(query);

        }

        public IEnumerable<ISprite> getAllSprites()
        {
            string query = $"SELECT * FROM sprite;";
            return wrapper.query(query).ConvertTable<SpriteDTO>();
        }

        public IEnumerable<ISprite> getSpritesByUsername(string username)
        {
            string query = $"CALL get_user_sprites('{username}')";
            return wrapper.query(query).ConvertTable<SpriteDTO>();
        }

        public void unlockSprite(string username, string spriteName)
        {
            string query = $"CALL unlock_sprite('{username}', '{spriteName}')";
            wrapper.query(query);
        }
        
        public ISprite getSpriteByName(string spriteName)
        {
            string query = $"SELECT * FROM sprite WHERE name = '{spriteName}';";
            var result = wrapper.query(query);

            if(result.Count > 0)
            {
                return result.ConvertTable<SpriteDTO>().First();
            }

            return null;
        }

        public bool canBuySprite(string username, string spriteName)
        {
            string spriteQuery = $"SELECT * FROM sprite WHERE name = '{spriteName}';";
            var spriteResult = wrapper.query(spriteQuery);
            if (spriteResult.Count == 0) return false;


            string userQuery = $"SELECT * FROM user WHERE username = '{username}';";
            var userResult = wrapper.query(userQuery);
            if (userResult.Count == 0) return false;


            var sprite = spriteResult.ConvertTable<SpriteDTO>().First();
            var user = userResult.ConvertTable<UserDTO>().First();

            return user.points >= sprite.price;
        }

        public bool hasSprite(string username, string spriteName)
        {
            var query = $"SELECT * bought_sprite WHERE user_id = (SELECT id from user WHERE username = '{username}') (SELECT price FROM sprite WHERE name = '{spriteName}');";
            var result = wrapper.query(query);

            return result.Count > 0;
        }
    }
}
