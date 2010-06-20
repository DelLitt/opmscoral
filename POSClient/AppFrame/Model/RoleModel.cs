using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Model
{
    [Serializable]
    public class RoleModel : BaseEventArgs
    {
        private int id;
        private String name;


        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        
    }
}
