using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class LoginModelCollection : AfBaseCollection<LoginModel>
    {
        public LoginModelCollection(BindingSource source) : base(source)
        {
        }

        public LoginModelCollection()
        {
        }

        public LoginModelCollection(IList<LoginModel> list) : base(list)
        {
        }
    }
}
