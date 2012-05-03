using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate.Linq;
using System.Linq.Expressions;
using System.Collections;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using Remotion.Linq;


namespace AppFrame.Extensions
{
    public static class TypedExpandExtension
    {
        //private NHibernate.Linq.NhQueryable<T> query = NHibernate.Linq;
        /*public static IQueryable<T> Expand<T, K, L>(
            this IQueryable<T> nhQueryable,
            Expression<Func<T, K>> selector, SubpathBuilder<L> subpaths)
        {
            var mainPath = ProcessSelector(selector);

            foreach (var subPathSelector in subpaths.Expressions)
            {
                var subpath = ProcessSelector(subPathSelector);
                nhQueryable.Expand(mainPath + "." + subpath);                
            }

            return nhQueryable;
        }*/

        public static IQueryable<T> Expand<T, K>(
            this IQueryable<T> nhQueryable,
            Expression<Func<T, K>> selector)
        {
            
            /*if (selector.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException("Selector has to be of MemberAccess type", "selector");

            nhQueryable.Expand(ProcessSelector(selector));*/
            nhQueryable = nhQueryable.Fetch(selector);
            return nhQueryable;
        }


        
        /*public static string ProcessSelector(LambdaExpression expression)
        {
            var memberStack = new Stack<string>();
            TraverseMemberAccess(expression.Body as MemberExpression, memberStack);

            return JoinMembers(memberStack);
        }

        private static void TraverseMemberAccess(MemberExpression expression,
                                                 Stack<string> memberStack)
        {
            if (expression != null)
            {
                memberStack.Push(expression.Member.Name);

                var methodCall = expression.Expression as MethodCallExpression;
                if (expression.Expression is MethodCallExpression)
                {
                    TraverseIndexerCall(expression.Expression as MethodCallExpression,
                                        memberStack);
                }
                else if (expression.Expression is MemberExpression)
                {
                    TraverseMemberAccess(expression.Expression as MemberExpression,
                                         memberStack);
                }
                else if (!(expression.Expression is ParameterExpression))
                {
                    throw new ArgumentException("Selector contains invalid expression of type"
                                                + expression.Expression.NodeType, "selector");
                }
            }
        }

        private static void TraverseIndexerCall(MethodCallExpression methodCall,
                                                Stack<string> memberStack)
        {
            if (methodCall != null)
            {
                var type = methodCall.Object.Type;

                var interfaces = type.GetInterfaces().Select(i => i.Name).ToList();
                if (type.IsInterface)
                    interfaces.Add(type.Name);

                if ((interfaces.Contains("IList") || interfaces.Contains("IList`1"))
                    && (methodCall.Method.Name == "get_Item"))
                {
                    TraverseMemberAccess(methodCall.Object as MemberExpression,
                                         memberStack);
                }
                else
                {
                    throw new ArgumentException("Selector contains invalid method call",
                                                "selector");
                }
            }
        }

        private static string JoinMembers(Stack<string> memberStack)
        {
            return string.Join(".", memberStack.ToArray());
        }


    }

    public static class Subpath
    {
        public static SubpathBuilder<T> For<T>()
        {
            return new SubpathBuilder<T>();
        }
    }

    public class SubpathBuilder<T>
    {
        public IList<LambdaExpression> Expressions { get; private set; }

        public SubpathBuilder()
        {
            Expressions = new List<LambdaExpression>();
        }

        public SubpathBuilder<T> Add<K>(Expression<Func<T, K>> selector)
        {
            if (selector.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException("Selector has to be of MemberAccess type", "selector");

            Expressions.Add(selector);
            return this;
        } */
    }
}