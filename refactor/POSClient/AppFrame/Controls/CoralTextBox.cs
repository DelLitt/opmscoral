using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Controls
{
    public class CoralTextBox : TextBox
    {
        private bool numberEntered = false;

        public bool DigitOnly
        {
            get;
            set;
        }

        private EventHandler RaiseLetterFormatChanged;
        private LetterFormat letterFormat;
        public LetterFormat LetterFormat
        {
            get
            {
                return letterFormat;
            }
            set
            {
                letterFormat = value;
            }

        }

        public CoralTextBox()
        {
            DigitOnly = false;
            LetterFormat = LetterFormat.Normal;
            this.KeyPress += new KeyPressEventHandler(CoralTextBox_KeyPress);
            this.KeyDown += new KeyEventHandler(CoralTextBox_KeyDown);
            this.TextChanged += new EventHandler(CoralTextBox_TextChanged);
        }

        void CoralTextBox_TextChanged(object sender, EventArgs e)
        {
            if(DigitOnly)
            {
                                
            }
            if (LetterFormat != LetterFormat.Normal)
            {
                if (LetterFormat == LetterFormat.Upper)
                {
                    Text = Text.ToUpper();
                }
                else
                {
                    Text = Text.ToLower();
                }
                SelectionStart = Text.Length;
            }
        }

        void CoralTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (DigitOnly)
            {
                numberEntered = false;
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
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
        }

        void CoralTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DigitOnly)
            {
                if (numberEntered)
                {
                    e.Handled = true;
                }
            }
        }

        public string Format
        {
            get;
            set;
        }

    }

    public enum LetterFormat { Normal, Upper, Lower }

   

}
