using System;
using System.Collections;
using NHibernate.Criterion;

namespace POSServer.DataLayer.Implement
{
    [Serializable]
    public class QueryResult
    {
        private IList result = null;
        private int totalPage = 0;
        private int page = 0;

        public IList Result
        {
            get { return result; }
            set { result = value; }
        }

        public int TotalPage
        {
            get { return totalPage; }
            set { totalPage = value; }
        }

        public int Page
        {
            get { return page; }
            set { page = value; }
        }
    }
}