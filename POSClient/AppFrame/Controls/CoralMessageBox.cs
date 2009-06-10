using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Controls
{
    public partial class CoralMessageBox : Form
    {
        public CoralMessageBox()
        {
            InitializeComponent();
        }
        public static void Show(string message,string title,CoralMessageBoxButton buttonStyle,CoralMessageBoxIcon icon,CoralMessageBoxDefaultButton defaultButton)
        {
           
        }
    }
    public enum CoralMessageBoxButton { YesNo,YesNoCancel, OK, OKCancel,RetryCancel,AbortRetryIgnore }
    public enum CoralMessageBoxIcon { Asterisk,Error,Exclamation,Information,Question,None,Warning }
    public enum CoralMessageBoxDefaultButton { Button1,Button2,Button3 }
}
