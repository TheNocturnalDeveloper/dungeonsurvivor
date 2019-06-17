using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Tests.Dto
{
    class TrophyDTO : ITrophy
    {
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
}
