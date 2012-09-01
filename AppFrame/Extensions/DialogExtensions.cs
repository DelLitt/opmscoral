using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace AppFrame.Extensions
{
    public class DialogExtensions
    {
        public static Action<IScreen> ShowDialog;
        public static Action<IScreen> HideDialog;
    }
}
