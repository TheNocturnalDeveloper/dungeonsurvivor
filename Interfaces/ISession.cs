using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ISession
    {
        int rooms { get; set; }
        int stepratio { get; set; }
        DateTime date { get; set; }
        string username { get; set; }
    }
}
