using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using NHibernate;

namespace AppFrame.DataLayer
{
    public class PosContext : NHibernateContext
    {
        public PosContext()
        {
            
        }
        public PosContext(NHibernate.ISession session)
            : base(session)
        {
            
        }
    }
}