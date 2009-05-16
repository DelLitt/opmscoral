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
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
    }
}
