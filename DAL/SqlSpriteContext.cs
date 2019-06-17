using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using DAL.Dtos;

namespace DAL
{
    class SqlSpriteContext : ISpriteContext
    {
        private MysqlWrapper wrapper;
        public SqlSpriteContext(string connectionString)
        {
            wrapper = new MysqlWrapper(connectionString);
        }

        public void addSprite(ISprite sprite)
        {
            string query = $"INSERT INTO sprite (price, path) VALUES ('{sprite.price}', '{sprite.path}');";
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
            throw new NotImplementedException();
        }
    }
}
