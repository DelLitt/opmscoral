using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Common
{
    public class GlobalCache
    {
        private static GlobalCache globalCache = null;
        private Form mainForm;
        public string WarningText { get; set; }

        private GlobalCache()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static GlobalCache Instance()
        {
            if (globalCache == null)
            {
                globalCache = new GlobalCache();
            }
            return globalCache;
        }

        /// <summary>
        /// main form of program
        /// </summary>
        public Form MainForm
        {
            get { return mainForm; }
            set { mainForm = value; }
        }

        

        
    }
}
