using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using AppFrame.Common;

namespace AppFrame.Utility
{
    public sealed class MenuUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public MenuStrip buildMenu(String file)
        {
            MenuStrip mainMenu = new MenuStrip();
            // read file
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            // read
            XmlNodeList menuList = doc.SelectNodes("//MainMenu/Menu");
            if (menuList != null)
            {
                IEnumerator menuListEnum =
                    menuList.GetEnumerator();
                while (menuListEnum.MoveNext())
                {
                    XmlNode menu = (XmlNode)menuListEnum.Current;
                    // create menu 
                    ToolStripMenuItem formMenuItem = new ToolStripMenuItem();
                    formMenuItem.Text = menu.Attributes["label"].Value;
                    XmlNodeList menuItemList = menu.ChildNodes;
                    IEnumerator menuItemListEnum = menuItemList.GetEnumerator();
                    while (menuItemListEnum.MoveNext())
                    {
                        XmlNode menuItem = (XmlNode)menuItemListEnum.Current;
                        ToolStripMenuItem childMenuItem = new ToolStripMenuItem();
                        childMenuItem.Text = menuItem.Attributes["label"].Value;
                        formMenuItem.DropDownItems.Add(childMenuItem);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainForm"></param>
        /// <param name="clientInfo"></param>
        public static void setPermission(Form mainForm,ClientInfo clientInfo)
        {
            MenuStrip mainMenu = mainForm.MainMenuStrip;
            setPermission(clientInfo.LoggedUser, ref mainMenu, clientInfo.MenuPermissions);
            mainForm.Invalidate();
            mainForm.Refresh();
            mainMenu.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="menuStrip"></param>
        /// <param name="menuItemPermission"></param>
        public static void setPermission(BaseUser user, ref MenuStrip menuStrip, MenuItemPermission menuItemPermission)
        {
            for (int i = 0; i < menuStrip.Items.Count - 1; i++)
            {
                // 1. get Menu Item
                ToolStripMenuItem toolStripMenuItem = menuStrip.Items[i] as ToolStripMenuItem;
                // 2. Set permission
                setPermission(user, ref toolStripMenuItem, menuItemPermission);
                // 3. Set permission for child

            }
        }

        private static void setPermission(BaseUser user, ref ToolStripMenuItem menuItem, MenuItemPermission permission)
        {
            // 1. get Menu Item
            // 2. Check role of user
            if(menuItem == null)
                return;
            bool hasPermission = permission.HasPermission(menuItem.Name, user);
            // 3. Process menu presentation base on user's role.
            if (hasPermission)
            {
                menuItem.Enabled = true;
                menuItem.Visible = true;
            }
            else
            {
                switch (permission.DeniedAction)
                {
                    case MenuItemPermission.DISABLED:
                        menuItem.Enabled = false;
                        break;
                    case MenuItemPermission.INVISIBLE:
                        menuItem.Visible = false;
                        break;
                    case MenuItemPermission.POPUP:
                        break;
                    case MenuItemPermission.NORMAL:
                        break;
                }
            }
           for(int i = 0;i<menuItem.DropDownItems.Count;i++)
           {
               ToolStripMenuItem childMenuItem = menuItem.DropDownItems[i] as ToolStripMenuItem;
               setPermission(user,ref childMenuItem, permission);
           }
        }

    }
}