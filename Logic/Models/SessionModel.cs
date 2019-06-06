using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Logic
{
    class SessionModel : ISession
    {
        public int rooms { get; set; }
        public int stepRatio { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }
    }
}
