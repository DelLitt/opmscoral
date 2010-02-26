﻿using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Type;

namespace POSServer.DataLayer.Implement
{
    public class SQLQueryCriteria
    {
        public string SQLString { get; set; }
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public IType Type { get; set; }
    }
}