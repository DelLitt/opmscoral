using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Utility.Mapper
{
    public abstract class FormTransform<TForm, TObject> : BaseTransform<TForm, TObject> where TForm : Form, new()
    {
        
        
        
        /// <summary>
        /// Transoform an model to a form in a basic way
        /// </summary>
        /// <param name="form">destination form</param>
        /// <param name="sourceObject">object model</param>
        public void BaseTransform(ref TForm form,TObject sourceObject)
        {
            const char SEPARATOR = '.';
            IEnumerator enumMap = MapProperties.Keys.GetEnumerator();


            while (enumMap.MoveNext())
            {
                // get key under string[] 
                string[] controlInfo = enumMap.Current.ToString().Split(SEPARATOR);
                // get control name
                string controlName = controlInfo[0];
                // get control value
                string controlValue = controlInfo[1];
                // get control needs to set value
                Control control = form.Controls[controlName];

                string key = (string)enumMap.Current;

                SetValue(control, controlValue, sourceObject, MapProperties[key]);
            }
        }
    }
}
