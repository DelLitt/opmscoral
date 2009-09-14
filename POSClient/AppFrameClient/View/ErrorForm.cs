using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrameClient.View
{
    public partial class ErrorForm : Form,ErrorObject
    {
        

        private string _errorString;

        private List<string> _errorDetails;

        public ErrorForm()
        {
            InitializeComponent();
            _errorDetails = new List<string>();
        }

        public string Caption
        {
            get
            {
                return this.Caption;
            }
            set
            {
                Caption = value;
            }
        }

        public string ErrorString
        {
            get
            {
                return txtErrorString.Text;
            }
            set
            {
                txtErrorString.Text = value;
            }
        }

        public List<string> ErrorDetails
        {
            get
            {
                _errorDetails.Clear();
                foreach (string s in lstErrorDetails.Items)
                {
                  _errorDetails.Add(s);      
                }
                return _errorDetails;
            }
            set
            {
                lstErrorDetails.Items.Clear();
                foreach (string s in value)
                {
                    lstErrorDetails.Items.Add(s); 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
