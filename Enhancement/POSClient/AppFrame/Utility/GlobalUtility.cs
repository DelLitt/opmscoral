using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame.Utility
{
    public sealed class GlobalUtility
    {
        public static AuthManager loadAuthenticationModule()
        {
            AuthManager authenticationManager = null;
            try
            {
                IApplicationContext ctx = ContextRegistry.GetContext();
                authenticationManager = ctx.GetObject("authentication") as AuthManager;
            }
            catch (Exception e)
            {
            }
            return authenticationManager;
        }

        public static object GetObject(string objectName)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            return ctx.GetObject(objectName);
        }
        /// <summary>
        /// return the first object of a type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetFirstObjectOfType(Type type)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();

            IDictionary test = ctx.GetObjectsOfType(type);
            IEnumerator enumerator = test.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return test[enumerator.Current];
            }
            else
            {
                return null;
            }
        }
        public static Form GetFormObject(string formName)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            return ctx.GetObject(formName) as Form;
        }

        public static T GetFormObject<T>(string formName) where T : Form
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            return ctx.GetObject(formName, typeof(T)) as T;
        }

        public static Form GetChildFormObject(Form parentForm, string formName)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            Form childForm = ctx.GetObject(formName) as Form;
            if (childForm != null)
            {
                childForm.MdiParent = parentForm;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.Location = new Point(0, 0);
            }
            return childForm;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentForm"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static T GetChildFormObject<T>(Form parentForm, string formName) where T : Form
        {
            Delegate MethodInvoker;
            IApplicationContext ctx = ContextRegistry.GetContext();
            T childForm = ctx.GetObject(formName, typeof(T)) as T;



            if (childForm != null)
            {
                MethodInvoker del = delegate
                {
                    childForm.MdiParent = parentForm;
                    childForm.StartPosition = FormStartPosition.Manual;
                    childForm.Location = new Point(0, 0);
                };

                parentForm.Invoke(del);
            }

            return childForm;
        }


        /// <summary>
        /// Get only one instance of child form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentForm"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static T GetOnlyChildFormObject<T>(Form parentForm, string formName) where T : Form
        {
            T returnForm = null;

            if (parentForm.HasChildren)
            {
                // check whether has child in same type
                foreach (Form childForm in parentForm.MdiChildren)
                {
                    if (childForm is T)
                    {
                        if (returnForm == null)
                        {
                            returnForm = childForm as T;
                        }
                        else
                        {
                            childForm.Close();
                        }
                        
                    }
                }

            }
            // if can not find out instance  then create new
            if (returnForm == null)
            {
                returnForm = GetChildFormObject<T>(parentForm, formName);
            }
            return returnForm;
        }
        public static void CloseAllChildForm(Form mainForm)
        {
            if (mainForm.HasChildren)
            {
                // check whether has child in same type
                foreach (Form childForm in mainForm.MdiChildren)
                {
                    childForm.Close();
                }

            }
        }
        /// <summary>
        /// Localize a form base in a resource file
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="form"></param>
        public static void LocalizeForm(ResourceManager manager, Form form)
        {

        }

        public static void ShowForm(Form form)
        {
            Delegate MethodInvoker;
            MethodInvoker mi = () => form.Show();
            if (form.InvokeRequired)
            {
                form.Invoke(mi);
            }
            else
            {
                form.Show();
            }
        }
    }
}
