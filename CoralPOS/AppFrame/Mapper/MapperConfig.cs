using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using EmitMapper.MappingConfiguration;
namespace AppFrame.Mapper
{
    public class MapperConfig<TSource,TDest> where TSource : class where TDest:class
    {
        private IDictionary<string,string> fieldMaps = new Dictionary<string, string>();
        private IDictionary<string,bool> ignoreMaps = new Dictionary<string, bool>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MapperConfig<TSource, TDest> MapSameNames()
        {
            Type source = typeof (TSource);
            Type dest = typeof(TSource);
            
            PropertyInfo[] sourceInfos = source.GetProperties(BindingFlags.Public);
            PropertyInfo[] desInfos = source.GetProperties(BindingFlags.Public);
            foreach (PropertyInfo sourceInfo in sourceInfos)
            {
                foreach (PropertyInfo destInfo in desInfos)
                {
                    if(sourceInfo.Name.EndsWith(destInfo.Name))
                    {
                        fieldMaps[sourceInfo.Name] = destInfo.Name;
                        break;
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public MapperConfig<TSource, TDest> MapProperty(Expression<Func<TSource, string>> e1, Expression<Func<TSource, string>> e2)
        {
            // NOT implement yet
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public MapperConfig<TSource, TDest> MapProperty(string e1, string e2)
        {
            fieldMaps[e1] = e2;
            return this;
        }

        public MapperConfig<TSource, TDest> IgnoreProperty(Expression<Func<TSource,string>> e1, bool ignored)
        {

            return this;
        }

        public MapperConfig<TSource, TDest> MapProperty(string e1, bool ignored)
        {
            ignoreMaps[e1] = ignored;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usingIgnoreMap"></param>
        /// <returns></returns>
        public DefaultMapConfig GetSourceToDestConfig(bool usingIgnoreMap =false)
        {
            DefaultMapConfig mapConfig;
            if (usingIgnoreMap)
            {
                mapConfig = new DefaultMapConfig().MatchMembers((m1, m2) => fieldMaps[m1] == m2 && ignoreMaps[m1]);
            }
            else
            {
                mapConfig = new DefaultMapConfig().MatchMembers((m1, m2) => fieldMaps[m1] == m2);
            }
            return mapConfig;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usingIgnoreMap"></param>
        /// <returns></returns>
        public DefaultMapConfig GetDestToSourceConfig(bool usingIgnoreMap = false)
        {
            DefaultMapConfig mapConfig;
            if (usingIgnoreMap)
            {
                mapConfig = new DefaultMapConfig().MatchMembers((m2, m1) => m2 == fieldMaps[m1] && ignoreMaps[m1]);
            }
            else
            {
                mapConfig = new DefaultMapConfig().MatchMembers((m2, m1) => m2 == fieldMaps[m1]);
            }
            return mapConfig; 
        }
    }
}
