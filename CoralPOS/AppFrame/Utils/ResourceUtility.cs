using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using AppFrame.Common;
using Spring.Context.Support;

namespace AppFrame.Utility
{
    public sealed class ResourceUtility
    {

        public static string GetString(string baseName,string key,object runType)
        {
            ResourceManager resourceManager = new ResourceManager(baseName,runType.GetType().Assembly);
            return resourceManager.GetString(key);
        }
        public static string GetErrorString(string name)
        {
            ResourceSetMessageSource messageSource =
                GlobalUtility.GetObject(CommonConstants.ERROR_RESOURCES) as ResourceSetMessageSource;

            if (messageSource != null)
            {
                return messageSource.GetMessage(name);
            }
            else
            {
                return null;
            }
        }

        public static string GetMessageString(string name)
        {
            ResourceSetMessageSource messageSource =
               GlobalUtility.GetObject(CommonConstants.MESSAGE_RESOURCES) as ResourceSetMessageSource;

            if (messageSource != null)
            {
                return messageSource.GetMessage(name);
            }
            else
            {
                return null;
            }
        }
    }
}
