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
using Remotion.Linq.Utilities;


namespace AppFrame.Extensions
{
    public static class TypedExpandExtension
    {
        private static IQueryable<T> Expand<T, K, L>(
            this IQueryable<T> nhQueryable,
            Expression<Func<T, K>> selector, SubpathBuilder<L> subpaths)
        {
            nhQueryable = Expand(nhQueryable,selector);

            foreach (var subPathSelector in subpaths.Expressions)
            {
                //nhQueryable = nhQueryable.Fetch(subPathSelector);
            }

            return nhQueryable;
        }

        private static IQueryable<T> Expand<T, K>(
            this IQueryable<T> nhQueryable,
            Expression<Func<T, K>> selector)
        {
            return FetchThrough(nhQueryable,selector);
            //if (selector.Body.NodeType != ExpressionType.MemberAccess)
            //    throw new ArgumentException("Selector has to be of MemberAccess type", "selector");

            ///*nhQueryable.Expand(ProcessSelector(selector));*/
            //Stack<FetchExpression> expressions = ProcessSelector(selector);
            //bool firstTime = true;
            //MemberExpression parentExpression = null;
            //foreach (var fetchExpression in expressions)
            //{
            //    if(firstTime)
            //    {
            //        if (fetchExpression.IsCollection)
            //        {
            //            nhQueryable = nhQueryable.FetchMany<T>(fetchExpression.MemberExpression);
            //        }
            //        else
            //        {
            //            nhQueryable = nhQueryable.Fetch<T>(fetchExpression.MemberExpression);
            //        }
            //        firstTime = false;
            //    }
            //    else
            //    {
            //        if (fetchExpression.IsCollection)
            //        {
            //            nhQueryable = nhQueryable.ThenFetchMany<T>(fetchExpression.MemberExpression,parentExpression);
            //        }
            //        else
            //        {
            //            nhQueryable = nhQueryable.ThenFetch<T>(fetchExpression.MemberExpression,parentExpression);
            //        }
            //    }
            //    parentExpression = fetchExpression.MemberExpression;
            //}
            //return nhQueryable;
        }

        private static IQueryable<T> FetchThrough<T>(
            this IQueryable<T> nhQueryable,
            LambdaExpression selector)
        {
            if (selector.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException("Selector has to be of MemberAccess type", "selector");

            /*nhQueryable.Expand(ProcessSelector(selector));*/
            Stack<FetchExpression> expressions = ProcessSelector(selector);
            bool firstTime = true;
            MemberExpression parentExpression = null;
            while (expressions.Count > 0)
            {
                var fetchExpression = expressions.Pop();
                if (firstTime)
                {
                    if (fetchExpression.IsCollection)
                    {
                        nhQueryable = nhQueryable.FetchMany<T>(fetchExpression.MemberExpression);
                    }
                    else
                    {
                        nhQueryable = nhQueryable.Fetch<T>(fetchExpression.MemberExpression);
                    }
                    firstTime = false;
                }
                else
                {
                    if (fetchExpression.IsCollection)
                    {
                        nhQueryable = nhQueryable.ThenFetchMany<T>(fetchExpression.MemberExpression, parentExpression);
                    }
                    else
                    {
                        nhQueryable = nhQueryable.ThenFetch<T>(fetchExpression.MemberExpression, parentExpression);
                    }
                }
                parentExpression = fetchExpression.MemberExpression;
            }
            return nhQueryable;
        }
        static IQueryable<TOriginating> Fetch<TOriginating>(
            this IQueryable<TOriginating> query, MemberExpression relatedObjectSelector)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("childMember", relatedObjectSelector);
            MethodInfo fetchMethodInfo = typeof (EagerFetchingExtensionMethods).GetMethod("Fetch");
            var methodInfo = fetchMethodInfo.MakeGenericMethod(typeof(TOriginating), relatedObjectSelector.Type);
            //var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TOriginating));
            return CreateFluentFetchRequest<TOriginating>(methodInfo, query, relatedObjectSelector);
        }

        static IQueryable<TOriginating> FetchMany<TOriginating>(
            this IQueryable<TOriginating> query, MemberExpression relatedObjectSelector)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("childMember", relatedObjectSelector);
            MethodInfo fetchMethodInfo = typeof(EagerFetchingExtensionMethods).GetMethod("FetchMany");
            var methodInfo = fetchMethodInfo.MakeGenericMethod(typeof(TOriginating), relatedObjectSelector.Type);
            //var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TOriginating));
            return CreateFluentFetchRequest<TOriginating>(methodInfo, query, relatedObjectSelector);
        }

        static IQueryable<TQueried> ThenFetch<TQueried>(
            this IQueryable<TQueried> query, MemberExpression childMember, MemberExpression parentMember)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("childMember", childMember);
            ArgumentUtility.CheckNotNull("parentMember", parentMember);
            MethodInfo fetchMethodInfo = typeof(EagerFetchingExtensionMethods).GetMethod("FetchMany");
            var methodInfo = fetchMethodInfo.MakeGenericMethod(typeof(TQueried), parentMember.Type, childMember.Type);
            //var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TQueried));
            return CreateFluentFetchRequest<TQueried>(methodInfo, query, childMember);
        }

        static IQueryable<TQueried> ThenFetchMany<TQueried>(
            this IQueryable<TQueried> query, MemberExpression childMember, MemberExpression parentMember)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("childMember", childMember);
            ArgumentUtility.CheckNotNull("parentMember", parentMember);
            MethodInfo fetchMethodInfo = typeof(EagerFetchingExtensionMethods).GetMethod("FetchMany");
            var methodInfo = fetchMethodInfo.MakeGenericMethod(typeof(TQueried), parentMember.Type, childMember.Type);
            //var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TQueried));
            return CreateFluentFetchRequest<TQueried>(methodInfo, query, childMember);
        }

        private static IQueryable<TOriginating> CreateFluentFetchRequest<TOriginating>(
            MethodInfo currentFetchMethod,
            IQueryable<TOriginating> query,
            MemberExpression relatedObjectSelector)
        {
            var queryProvider = query.Provider; // ArgumentUtility.CheckNotNullAndType<QueryProviderBase>("query.Provider", query.Provider);
            var callExpression = Expression.Call(currentFetchMethod, query.Expression, relatedObjectSelector);
            return new NhQueryable<TOriginating>(queryProvider, callExpression);
        }

        public static Stack<FetchExpression> ProcessSelector(LambdaExpression expression)
        {
            var memberStack = new Stack<FetchExpression>();
            TraverseMemberAccess(expression.Body as MemberExpression, memberStack);

            return memberStack;
        }

        private static void TraverseMemberAccess(MemberExpression expression,
                                                 Stack<FetchExpression> memberStack,bool isCollection =false)
        {
            if (expression != null)
            {
                memberStack.Push(new FetchExpression
                                     {
                                         MemberExpression = expression,
                                         IsCollection = isCollection
                                     });

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
                                                Stack<FetchExpression> memberStack)
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
                                         memberStack,true);
                }
                else
                {
                    throw new ArgumentException("Selector contains invalid method call",
                                                "selector");
                }
            }
        }

        /*private static string JoinMembers(Stack<string> memberStack)
        {
            return string.Join(".", memberStack.ToArray());
        }*/


    }

    public class FetchExpression
    {
        public MemberExpression MemberExpression { get; set; }
        public bool IsCollection { get; set; }
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
        } 
    }
}