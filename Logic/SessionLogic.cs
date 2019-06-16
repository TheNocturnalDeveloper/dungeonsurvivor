using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace Logic
{
    public class SessionLogic
    {
        private ISessionContext context;

        public SessionLogic(ISessionContext context)
        {
            this.context = context;
        }
    }
}
