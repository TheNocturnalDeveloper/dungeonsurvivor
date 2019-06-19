using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL.Dtos
{
    class SpriteDTO : ISprite
    {
        [TableField]
        public string name { get; set; } 

        [TableField]
        public string path { get; set; }

        [TableField]
        public int price { get; set; }
    }
}
