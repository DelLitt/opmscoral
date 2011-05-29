using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public sealed class InnerClipboard
    {
        private static object innerObj= null;
        public static void SetText(string text)
        {
            innerObj = text;
        }
        public static string GetText()
        {
            return (string) innerObj;
        }
        public static void Clear()
        {
            innerObj = null;
        }
    }
}
