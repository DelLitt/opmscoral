using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Common.Logging;

namespace AppFrame.Common
{
    public class LogicItemPermission : IPermission
    {
        private static LogicItemPermission logicItemPermission;
        private const string SPACE_STRING = " ";
        private IDictionary<string, IList<Role>> permissionMap;
        #region IPermission Members

        public bool HasPermission(object accessingObject, BaseUser user)
        {
            ILog logger = LogManager.GetLogger("AppFrame");
            logger.Info("Check permission ");
            
            if (accessingObject == null || user == null)
            {
                return false;
            }
            // get key
            string key = (string)accessingObject;
            logger.Info(" key is" + key);
            // get valid role for accessing object
            IList<Role> validRoles = permissionMap[key];
            
            // check whether user is valid for accessing object
            for (int i = 0; i < validRoles.Count; i++)
            {
                Role validRole = validRoles[i];
                logger.Info(" Role name is " + validRole.Name);
                if (user.IsInRole(validRole))
                {
                    logger.Info("return true");
                    return true;
                }
            }
            logger.Info("return false");
            return false;
        }
        private LogicItemPermission()
        {
            permissionMap = new Dictionary<string, IList<Role>>();
        }

        //public LogicItemPermission(string filePath)
        //{
        //    permissionMap = new Dictionary<string, IList<Role>>();
        //    loadRoles(filePath);
        //}
        public static LogicItemPermission Instance()
        {
            if(logicItemPermission==null)
            {
                logicItemPermission = new LogicItemPermission();
            }
            return logicItemPermission;
        }
        #endregion

        public void loadRoles(string filePath)
        {
            FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/" + filePath, FileMode.Open);
            loadRoles((fileStream));
        }
        /// <summary>
        /// Load roles from a stream
        /// </summary>
        /// <param name="path"></param>
        public void loadRoles(Stream inputStream)
        {
            ILog logger = LogManager.GetLogger("AppFrame");
            XmlTextReader reader = new XmlTextReader(inputStream);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNodeList nodeList = doc.SelectNodes("//logicPermissions/logicPermission");
            foreach (XmlNode node in nodeList)
            {
                XmlNodeList permissionNode = node.ChildNodes;
                
                if (permissionNode.Count == 2)
                {
                    string logicNamesString = permissionNode[0].InnerText.Replace(SPACE_STRING, String.Empty);
                    string[] logicNames = logicNamesString.Split(',');
                    string rolesString = permissionNode[1].InnerText.Replace(SPACE_STRING, String.Empty);
                    IList<Role> roles = getRoleListFromString(rolesString);
                    foreach (string logicName in logicNames)
                    {
                        if (permissionMap.ContainsKey(logicName))
                        {
                            permissionMap[logicName] = updateRoleForLogic(permissionMap[logicName], roles);
                        }
                        else
                        {
                            permissionMap.Add(logicName,roles);
                        }

                    }
                }
            }

        }

        private IList<Role> updateRoleForLogic(IList<Role> currentRoles, IList<Role> newRoles)
        {
            if (currentRoles == null || currentRoles.Count == 0)
            {
                return newRoles;
            }
            
            foreach (Role newRole in newRoles)
            {
                if(!newRole.ExistInList(currentRoles))
                {
                    currentRoles.Add(newRole);
                }
            }
            return currentRoles;
        }
        private IList<Role> getRoleListFromString(string strRoles)
        {
            IList<Role> roles = new List<Role>();
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
