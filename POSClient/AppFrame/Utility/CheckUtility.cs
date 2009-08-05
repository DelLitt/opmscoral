using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Utility
{
    public sealed class CheckUtility
    {
        public static bool IsNullOrEmpty(string checkStr)
        {
            return checkStr == null || checkStr.Length == 0;
        }
        public static bool StringStartWith(string checkStr,string[] checkPatterns)
        {
            foreach (string pattern in checkPatterns)
            {
                if(checkStr.StartsWith(pattern))
                {
                    return true;
                }
            }
            return false;
        }
        public static string PadString(string padString,int length)
        {
            if(padString.Length >= length)
            {
                return padString.Substring(0, length);
            }
            else
            {
                return padString.PadRight(length, '_');
            }
        }
        public static void FormatUpper(TextBox  textBox)
        {
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = textBox.Text.Length;
        }

        public static bool IsNullOrEmpty(IList prdList)
        {
            return (prdList == null || prdList.Count == 0);
        }
    }

}
