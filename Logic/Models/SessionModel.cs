﻿using Interfaces;
using System;

namespace Logic
{
    internal class SessionModel : ISession
    {
        public int rooms { get; set; }
        public int stepRatio { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }
    }
}
