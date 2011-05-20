using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using InfoBox;

namespace AppFrameClient.View.Masters
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void categoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
            this.Validate();
            this.categoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.masterDB);
            InfoBox.InformationBox.Show("Lưu phân loại hàng thành công", new AutoCloseParameters(2));
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.masterDB.category);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            long tempCategoryId = 0;
            long maxCategoryId = 0;
            foreach ( DataRow row in masterDB.category.Rows)
            {
                Utility.ClientUtility.TryActionHelper(delegate() {
                                                                     tempCategoryId =
                                                                         Int64.Parse(
                                                                             row[masterDB.category.CATEGORY_IDColumn].
                                                                                 ToString()); }, 1);
                if (tempCategoryId > maxCategoryId)
                    maxCategoryId = tempCategoryId;
            }
            maxCategoryId += 1;
            cATEGORY_IDTextBox.Text = maxCategoryId.ToString();
            cREATE_DATEDateTimePicker.Value = DateTime.Now;
            uPDATE_DATEDateTimePicker.Value = DateTime.Now;
            cREATE_IDTextBox.Text = ClientInfo.getInstance().LoggedUser.Name;
            uPDATE_IDTextBox.Text = ClientInfo.getInstance().LoggedUser.Name;
            pARENT_CATEGORY_IDTextBox.Text = "0";
            eXCLUSIVE_KEYTextBox.Text = "0";
            dEL_FLGTextBox.Text = "0";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
