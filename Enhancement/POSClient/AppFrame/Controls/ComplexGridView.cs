using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Controls
{
    public partial class ComplexGridView : DataGridView
    {
        public ComplexGridView() : base()
        {
            
        }

        protected override void OnColumnDataPropertyNameChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnDataPropertyNameChanged(e);
        }
    }
}
