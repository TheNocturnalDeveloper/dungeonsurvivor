using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Logic
{
    class SpriteModel : ISprite
    {
        public string name { get; set; }
        public string path { get; set; }
        public int price { get; set; }
    }
}
