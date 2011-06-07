using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Common
{
    public class AppFrameConroller
    {
        public IPresenter MainPresenter { get; set; }
        public IPresenter CurrentPresenter { get; set; }
    }
}
