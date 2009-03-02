using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Controls
{
    public partial class NumberTextBox : TextBox
    {
        private bool numberEntered = false;
        public NumberTextBox() : base()
        {
            this.KeyPress += new KeyPressEventHandler(NumberTextBox_KeyPress);
            this.KeyDown += new KeyEventHandler(NumberTextBox_KeyDown);
            realValue = "";
        }

        void NumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            numberEntered = false;
            if(e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back
                        || e.KeyCode != Keys.Delete
                        || e.KeyCode != Keys.Up
                        || e.KeyCode != Keys.Down
                        || e.KeyCode != Keys.Left
                        || e.KeyCode != Keys.Right
                        || e.KeyCode != Keys.LButton
                        || e.KeyCode != Keys.MButton
                        || e.KeyCode != Keys.RButton
                        || e.KeyCode != Keys.Home
                        || e.KeyCode != Keys.End
                        || e.KeyCode != Keys.Enter
                        )
                    {
                        numberEntered = true;
                    }
                }
            }
        }

        void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if(numberEntered)
            {
                e.Handled = true;
            }
        }

        private string realValue;
        
        
        public string Format
        {
            get;
            set;
        }
        
    }
}
