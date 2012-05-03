using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Fasterflect;
using System.Text;

namespace AppFrame.DataLayer
{
    public class AdoWrapper<T> where T:DataSet
    {
        private T dataSet;

        public T DataSet
        {
            get { return dataSet; }
            set { dataSet = value; }
        }

        public AdoWrapper(T outsideDs)
        {
            dataSet = outsideDs;
        }

        public void Fill(Expression<Func<T,DataTable>> expression)
        {
            Assembly dataSetAseembly = dataSet.GetType().Assembly;
            MemberExpression member = expression as MemberExpression;
            
        }
    }
}
