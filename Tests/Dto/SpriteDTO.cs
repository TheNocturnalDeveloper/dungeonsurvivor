﻿using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Tests.Dto
{
    internal class SpriteDTO : ISprite
    {
        public string name { get; set; }
        public string path { get; set; }
        public int price { get; set; }
    }
}
