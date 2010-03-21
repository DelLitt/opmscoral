using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace AppFrame.DataLayer
{
    public class LinqCriteria<T> 
    {
        private IList<Expression<Func<T, bool>>> _where;
        private IList<Expression<Func<T, bool>>> _order;
        public LinqCriteria()
        {
            _where = new List<Expression<Func<T, bool>>>();
            _order = new List<Expression<Func<T, bool>>>();
        }
        public void AddCriteria(Expression<Func<T, bool>> lambdaFunc)
        {
            _where.Add(lambdaFunc);
        }

        public void AddOrder(Expression<Func<T, bool>> lambdaFunc)
        {
            
            _order.Add(lambdaFunc);
        }
        public IList<Expression<Func<T, bool>>> Where
        {
            get
            {
                return _where;
            }
            set
            {
                _where = value;
            }
        }
        public IList<Expression<Func<T, bool>>> Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }
    }
}
