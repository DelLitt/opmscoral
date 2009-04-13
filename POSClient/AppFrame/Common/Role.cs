using System;
using System.Collections.Generic;

namespace AppFrame.Common
{
    [Serializable]
    public class Role 
    {

        public Role(string roleName)
        {
            name = roleName;
        }
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual bool ExistInList(IList<Role> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                Role inRole = list[i];
                if (Equals(inRole))
                {
                    return true;
                }
            }
            return false;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
 
            if (Name.Equals((obj as Role).Name))
            {
                return true;
            }
            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return base.GetHashCode();
        }

        
    }
}