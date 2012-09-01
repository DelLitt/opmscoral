using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Helpers
{
    public class TryHelper
    {
        /// <summary>
        /// Silent call a function and retry if it failed
        /// </summary>
        /// <param name="func">function to call</param>
        /// <param name="numbers">times of retries</param>
        public static void Try(Action func,int numbers )
        {
            do
            {
                try { func(); return; }
                catch
                {
                    if (numbers <= 0) return;
                }
            } while (numbers-- > 0);

        }
    }
}
