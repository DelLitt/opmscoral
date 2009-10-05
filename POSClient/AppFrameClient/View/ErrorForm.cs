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
                return _errorDetails; 
            }
            set
            {
                _errorDetails = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = _errorDetails;
            lstErrorDetails.DataSource = bds;
        }
    }
}
