using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace Logic
{
    class SpriteLogic
    {
        private ISpriteContext context;

        public SpriteLogic(ISpriteContext context)
        {
            this.context = context;
        }
    }
}
