using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Collection;
using NHibernate.Proxy;
using LockMode = NHibernate.LockMode;

namespace AppFrame.DataLayer
{
    public static class LazyInitializer
    {
        #region fields
        /*/// <summary>
        /// A container of all types containing lazy properties
        /// with a list of their respective lazy properties.
        /// </summary>
        private static IDictionary<Type, List<PropertyInfo>>
            propertiesToInitialise =
                new Dictionary<Type, List<PropertyInfo>>();
        private static IList<Type> proxyTypes = new List<Type>();*/
        #endregion

        /// <summary>
        private delegate bool CheckTraverseProp(object child,object parent,bool isRegister);
        /// Fully initialize the instance of T type with a primary key equal to id.
        /// </summary>
        /// <typeparam name="T">The type to resolve and load</typeparam>
        /// <param name="id">The primary key of the type to load</param>

        /// <param name="session">The session factory
        /// <param name="modelNamespace"></param>
        /// used to extract the current session</param>
        /// <returns>The fully initialized entity</returns>
        public static T ImmediateLoad<T>(object id, ISession session,string modelNamespace)
        {
            T entity = session.Load<T>(id);
            return InitializeCompletely(entity, modelNamespace, session);
        }

        /// <summary>

        /// Convenience method for loading the complete
        /// object graph for an already initialized entity,
        /// where parts of the entity's object graph may be proxy instances.
        /// </summary>
        /// <remarks>
        /// This is done by recursively looping through all NHibernate
        /// mapped properties in the object graph and 
        /// examining if they are lazy loaded (represented by a proxy).
        /// It is at this moment unknown
        /// whether this approach is inefficient. This must be tested.
        /// </remarks>
        /// <param name="entity">

        /// The entity to initialize. This must be an initialized
        /// entity object that holds lazy properties. From
        /// the LazyInitializer's scope, the entity is the top node in the object graph.
        /// </param>
        /// <param name="modelNamespace"></param>
        /// <param name="session">The current session</param>
        /// <returns>The fully initialized entity</returns>

        public static T InitializeCompletely<T>(T entity, string modelNamespace,ISession session)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            // Okay, first we must identify all the proxies we want to initialize:
            ExtractMappedProperties(entity, 0, 6, false, modelNamespace,session,linkedList);
            return entity;
        }

        /// <summary>
        /// Convenience method for loading proxies in entity
        /// object graph. Providing fetch depth to speed up
        /// processing if only a shallow fetch is needed.
        /// </summary>
        /// <remarks>
        /// This is done by recursively looping through
        /// all properties in the object graph and 
        /// examining if they are lazy loaded (represented
        /// by a proxy). It is at this moment unknown
        /// wether this approach is inefficient. This must be tested.
        /// </remarks>

        /// <param name="entity">
        /// This is done by recursively looping through
        /// all NHibernate mapped properties in the object graph and 
        /// examining if they are lazy loaded (represented
        /// by a proxy). It is at this moment unknown
        /// wether this approach is inefficient. This must be tested.
        /// </param>
        /// <param name="maxFetchDepth">The search depth.</param>
        /// <param name="modelNamespace"></param>
        /// <param name="session">The current session</param>

        /// <returns>A partly initialized entity,
        /// initialized to max fetch depth</returns>
        public static T InitializeEntity<T>(T entity,
                                            int maxFetchDepth, string modelNamespace,ISession session)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            // Let's reduce the max-fetch depth to something tolerable...
            if (maxFetchDepth <= 0 || maxFetchDepth > 6) maxFetchDepth = 6;
            // Okay, first we must identify all the proxies we want to initialize:
            ExtractMappedProperties(entity, 0, maxFetchDepth, false, modelNamespace, session,linkedList);
            return entity;
        }

        /// <summary>
        /// Search the object graph recursively for proxies,
        /// until a certain threshold has been reached.
        /// </summary>

        /// <param name="entity">The top node in the object
        /// graph where the search start.</param>
        /// <param name="depth">The current depth from
        /// the top node (which is depth 0)</param>
        /// <param name="maxDepth">The max search depth.</param>

        /// <param name="loadGraphCompletely">Bool flag indicating
        /// whether to ignore depth params</param>
        /// <param name="modelNamespace"></param>
        /// <param name="session">The current session to the db</param>
        private static void ExtractMappedProperties(object entity, int depth, 
            int maxDepth, bool loadGraphCompletely, 
            string modelNamespace, ISession session, LinkedList<string> linkedList)
        {
            bool isExtract;
            if (loadGraphCompletely) isExtract = true;
            else isExtract = (depth <= maxDepth);

            if (null != entity)
            {
                // Should we stay or should we go now?
                if (isExtract)
                {
                    // Check if the entity is a collection.
                    // If so, we must iterate the collection and
                    // check the items in the collection. 
                    // This will increase the depth level.
                    Type[] interfaces = entity.GetType().GetInterfaces();
                    
                    foreach (Type iface in interfaces)
                    {
                        if (iface == typeof(ICollection))
                        {
                            ICollection collection = (ICollection)entity;
                            if(collection.Count == 0) return;

                            foreach (object item in collection)
                            {
                                ExtractMappedProperties(item, depth + 1,
                                                          maxDepth, loadGraphCompletely,
                                                          modelNamespace, session, linkedList);
                            }
                            return;
                        }
                    }

                    // If we get here, then we know that we are
                    // not working with a collection, and that the entity
                    // holds properties we must search recursively.
                    // We are only interested in properties with NHAttributes.
                    // Maybe there is a better way to specify this
                    // in the GetProperties call (so that we only get an array
                    // of PropertyInfo's that have NH mappings).
                    //List<PropertyInfo> props = propertiesToInitialise[entity.GetType()];

                    Type entityType = NHibernateProxyHelper.GetClassWithoutInitializingProxy(entity);
                    string entityFullName = entityType.FullName;
                    if (!entityFullName.Contains(modelNamespace)) return;
                    if (!linkedList.Contains(entityFullName)) linkedList.AddLast(entityFullName);
                    int entityPosInList = PosInList(linkedList, entityFullName);
                    PropertyInfo[] props = entity.GetType().GetProperties();
                    foreach (PropertyInfo prop in props)
                    {
                        Type propType = prop.PropertyType;
                        string propFullName = prop.PropertyType.FullName;
                        
                        if (!propFullName.Contains(modelNamespace)
                            && !(propType is ICollection)) continue;
                        int propPosInList = PosInList(linkedList, propFullName);
                        if(propPosInList < entityPosInList) continue;
                        MethodInfo method = prop.GetGetMethod();
                        if (null != method)
                        {
                            //Console.WriteLine(entity.GetType().Name + "." + prop.Name + " is invoked.");
                            object proxy = method.Invoke(entity, new object[0]);     
                            
                            //if(proxy == null) continue;
                            /*if (!NHibernateUtil.IsInitialized(proxy))
                            {*/
                                // try to initialise
                                /*try
                                {*/
                                    LazyInit(proxy, entity, session);
                                /*}
                                catch (NullReferenceException exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }*/
                            /*}*/
                                ExtractMappedProperties(proxy, depth + 1, maxDepth,
                                                          loadGraphCompletely,
                                                          modelNamespace, session, linkedList);
                        }
                    }
                }
            }
        }

        private static int PosInList(LinkedList<string> linkedList, string entityFullName)
        {
            IEnumerator enumerator = linkedList.GetEnumerator();
            int i = 0;
            while(enumerator.MoveNext())
            {
                if (entityFullName.Equals(enumerator.Current.ToString())) return i;
                i++;
            }
            return int.MaxValue;
        }

        /// <summary>

        /// The core method delegating the hard lazy initialization
        /// work to the hibernate assemblies.
        /// </summary>
        /// <param name="proxy">The proxy to load</param>
        /// <param name="owner">The owning
        /// entity holding the reference</param>

        /// <param name="session">The current session to the db</param>
        private static void LazyInit(object proxy, object owner, ISession session)
        {
            if (null != proxy)
            {
                Type[] interfaces = proxy.GetType().GetInterfaces();
                foreach (Type iface in interfaces)
                {
                    if (iface == typeof(INHibernateProxy) ||
                        iface == typeof(IPersistentCollection))
                    {
                        if (!NHibernateUtil.IsInitialized(proxy))
                        {
                            if (iface == typeof(INHibernateProxy))
                                session.Lock(proxy, LockMode.None);
                            else //if (session.Contains(owner)) 
                                session.Lock(owner, LockMode.None);

                            NHibernateUtil.Initialize(proxy);
                        }

                        break;
                    }
                }
            }
        }

        #region ctor

        /// <summary>
        /// An alternative approach to initializes the
        /// <see cref="LazyInitializer"/> class.
        /// </summary>

        /// <remarks>
        /// this method should be called after
        /// the NH Cfg.Configuration object has been configured
        /// and before cfg.BuildSessionFactory(); has been called!
        /// This might be more demanding and difficult
        /// for those who work with DI tools. On the other hand
        /// this approach will work for ANY kind of mapping:
        /// Mapping.Attribute, Hbm and even NHibernate Fluent Interfaces.
        /// </remarks>
        /*public static void AlternativeConstructor()
        {
            var cfg = new Configuration();
            // get all types (with their lazy props) having lazy 
            // many/one-to-one properties
            var toOneQuery = from persistentClass in cfg.ClassMappings
                             let props = persistentClass.PropertyClosureIterator
                             select new { persistentClass.MappedClass, props }
                             into selection
                                 from prop in selection.props
                                 where prop.Value is NHibernate.Mapping.ToOne
                                 where ((NHibernate.Mapping.ToOne)prop.Value).IsLazy
                                 group selection.MappedClass.GetProperty(prop.Name)
                                 by selection.MappedClass;
            // get all types (with their lazy props) having lazy nh bag properties
            var bagQuery = from persistentClass in cfg.ClassMappings
                           let props = persistentClass.PropertyClosureIterator
                           select new { persistentClass.MappedClass, props }
                           into selection
                               from prop in selection.props
                               where prop.Value is NHibernate.Mapping.Collection
                               where ((NHibernate.Mapping.Collection)prop.Value).IsLazy
                               group selection.MappedClass.GetProperty(prop.Name)
                               by selection.MappedClass;
            // TODO: add queries of any other
            // mapping attribute you use that might be lazy.

            foreach (var value in toOneQuery)
                propertiesToInitialise.Add(value.Key, value.ToList());
            foreach (var value in bagQuery)
            {
                if (propertiesToInitialise.ContainsKey(value.Key))
                    propertiesToInitialise[value.Key].AddRange(value.ToList());
                else
                    propertiesToInitialise.Add(value.Key, value.ToList());
            }
            // TODO: add treatment of any other mapping
            // attribute you use that might be lazy.
        }

        /// <summary>

        /// Initializes the <see cref="LazyInitializer"/> class.
        /// </summary>
        static LazyInitializer()
        {
            
        }*/

        #endregion
    }
}