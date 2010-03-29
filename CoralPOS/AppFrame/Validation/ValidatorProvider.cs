using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;

namespace AppFrame.Validation
{
    public class ValidatorProvider
    {
        private static Dictionary<string,string> validators = new Dictionary<string, string>();
        public static IObjectValidator<T> For<T>(T obj) where T:class
        {
            foreach (KeyValuePair<string, string> keyValuePair in validators)
            {
                if (keyValuePair.Key.Equals(typeof(T).Name))
                {
                    IObjectValidator<T> validator = 
                        ServiceLocator.Current.GetInstance(Type.GetType(keyValuePair.Value)) as IObjectValidator<T>;
                    if(validator!=null)
                    {
                        validator.Target = obj;
                    }
                    else
                    {
                        return validator;
                    }
                }
            }
            return null;
        }
        public static void Register(Type obj,Type validator)
        {
            validators.Add(obj.Name,validator.Name);
        }

        public static POSError CreateError(string errorName, string errorDetail, string invalidProperty, string stackTrace)
        {
            return new POSError(errorName, errorDetail, invalidProperty, stackTrace);
        }
        public static POSError CreateError(string errorName, string errorDetail, string invalidProperty)
        {
            return new POSError(errorName, errorDetail, invalidProperty, null);
        }
        public static POSError CreateError(string errorName, string errorDetail)
        {
            return new POSError(errorName, errorDetail, null, null);
        }
        public static POSError CreateError(string errorName)
        {
            return new POSError(errorName, null, null, null);
        }
    }
}
