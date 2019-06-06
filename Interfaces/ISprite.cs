using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
   public interface ISprite
    {
        string name { get; set; }
        string path { get; set; }
        int price { get; set; }
    }
}
