using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AppFrame.Common
{
    [Serializable]
    public class BaseUser
    {
        public const string ROLES = "Roles";
        public const string ISGUEST = "IsGuest";
        public const string NAME = "Name";
        public event EventHandler StateChanged;
        private const string Test= "Khách";
        // START properties
        private string name;
        private bool isGuest = true;
        private string fullName;
        private IList roles=new ArrayList();
        // END   properties        
        
        

        
        public BaseUser()
        {
            
        }

        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {
                name = value;
            }
        }
        [XmlArrayItem(typeof(Role))]
        public IList Roles
        {
            get 
            {
                return roles;
            }
            set
            {
                roles = value;
            }
        }
        
        /// <summary>
        /// IsGuest property
        /// </summary>
        public bool IsGuest
        {
            get
            {
                return isGuest;
            }
            set
            {
                isGuest = value;
            }
        
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        /// <summary>
        /// Check whether user has this role or not.
        /// Note : If have '*' or '@' in your roles , it will be override all roles
        /// </summary>
        /// <param name="checkRole"></param>
        /// <returns></returns>
        public bool IsInRole(Role checkRole)
        {
            
            // if checkRole = * so everyone can use
            if (checkRole.Name.Equals("*"))
            {
                return true;
            }
            // if checkRole = @ so just logged in user
            if (checkRole.Name.Equals("@"))
            {
                return !IsGuest;
            }

            if (checkRole.Name.Equals("%"))
            {
                return IsGuest;
            }
            IList innerRoles = Roles;
            // if does not has role then return false
            if(innerRoles == null)
            {
                return false;
            }
            foreach (Role role in innerRoles)
            {
                
                // if has role name so check
                if(role.Equals(checkRole))
                {
                    return true;
                }
            }
            return false;
        }
        
        public BaseUser Clone()
        {
            return (BaseUser)MemberwiseClone();
        }
    }
}