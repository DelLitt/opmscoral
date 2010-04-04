using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public class DefaultSession : ISession
    {
        private IDictionary<string,object> _dictionary = new Dictionary<string, object>();
        public void Put(string key, object value)
        {
            if (IsSet(key))
            {
                _dictionary[key] = value;
            }
            else
            {
                _dictionary.Add(key, value);
            }
        }

        public object Get(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                return _dictionary[key];
            }
            else
            {
                return null;
            }
        }

        public void Remove(string key)
        {
            _dictionary.Remove(key);
        }

        public bool IsSet(string key)
        {
            return _dictionary.ContainsKey(key);  
        }
    }
}
