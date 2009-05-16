using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AppFrame.Controls
{
    public partial class ComplexBindingSource : BindingSource
    {
        public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection parentPDs = base.GetItemProperties(listAccessors);
            return ComplexListPropertyHelper.GetList(parentPDs,DataSource.GetType());
        }
    }
}
