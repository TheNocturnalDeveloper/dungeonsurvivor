using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL.Dtos
{
    class SessionDTO : ISession
    {
        [TableField]
        public int rooms { get; set; }

        [TableField]
        public int stepratio { get; set; }

 
        public DateTime date { get; set; }

        [TableField]
        public string username { get; set; }
    }
}
