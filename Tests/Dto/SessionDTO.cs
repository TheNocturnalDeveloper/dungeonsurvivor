﻿using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace Tests.Dto
{
    internal class SessionDTO : ISession
    {
        public int rooms { get; set; }
        public int stepratio { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }
    }
}
