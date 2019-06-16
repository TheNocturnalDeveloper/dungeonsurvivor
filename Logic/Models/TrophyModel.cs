﻿using Interfaces;

namespace Logic
{
    internal class TrophyModel : ITrophy
    {
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
}
