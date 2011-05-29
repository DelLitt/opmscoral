using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using AppFrame.Common;

namespace AppFrame.Common
{
    public class MenuItemPermission : IPermission
    {
        public const int DISABLED = 1;
        public const int INVISIBLE = 2;
        public const int NORMAL = 0;
        public const int POPUP = 3;

        /// <summary>
        /// map contains roles for each menuitem, separate by Name
        /// </summary>
        private readonly IDictionary<string, List<Role>> menuItemMap;

        /// <summary>
        /// Action taken when deny
        /// </summary>
        private int deniedAction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerDenierAction"></param>
        public MenuItemPermission(int outerDenierAction)
        {
            DeniedAction = outerDenierAction;
            menuItemMap = new Dictionary<string, List<Role>>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int DeniedAction
        {
            get { return deniedAction; }
            set { deniedAction = value; }
        }

        #region IPermission Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessingObject"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool HasPermission(object accessingObject, BaseUser user)
        {
            if (accessingObject == null || user == null)
            {
                return false;
            }
            // get key
            string key = (string) accessingObject;
            // get valid role for accessing object
            List<Role> validRoles = menuItemMap[key];
            // check whether user is valid for accessing object
            for (int i = 0; i < validRoles.Count; i++)
            {
                Role validRole = validRoles[i];
                if (user.IsInRole(validRole))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        public void loadRoles(string filePath)
        {
            FileStream fileStream = new FileStream(filePath,FileMode.Open);
            loadRoles((fileStream));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        public void loadRoles(Stream inputStream)
        {
            XmlTextReader reader = new XmlTextReader(inputStream);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNodeList nodeList = doc.SelectNodes("//mainmenu/menu");
            foreach (XmlNode node in nodeList)
            {
                // add menu to menuItemMap
                string menuName = node.Attributes["name"].InnerText;
                string strRoles = node.Attributes["role"].InnerText;
                List<Role> roles = getRoleListFromString(strRoles);
                menuItemMap.Add(menuName.Trim(),roles);
                // add child menu to menuItemMap
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    string childMenuName = childNode.Attributes["name"].InnerText;
                    string childStrRoles = childNode.Attributes["role"].InnerText;
                    List<Role> childRoles = getRoleListFromString(childStrRoles);
                    menuItemMap.Add(childMenuName.Trim(), childRoles);                                        
                }
            }
            
        }

        private List<Role> getRoleListFromString(string strRoles)
        {
            List<Role> roles = new List<Role>();
            string[] arrRoles = strRoles.Split(',');            
            foreach (string strRole in arrRoles)
            {
                Role role = new Role();
                role.Name = strRole.Trim();    
                roles.Add(role);
            }
            return roles;    
        }
    }
}