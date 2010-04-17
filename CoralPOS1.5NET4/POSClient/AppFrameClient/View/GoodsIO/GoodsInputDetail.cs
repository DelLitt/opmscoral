using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AppFrame.Logic;
using AppFrame.Model;

namespace AppFrameClient.View.GoodsIO
{
    public partial class GoodsInputDetail : Form
    {
        #region Members
        public IBlockInDetailLogic BlockInDetailLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public Product Product { get; set; }
        #endregion

        public GoodsInputDetail()
        {
            InitializeComponent();
        }

        private void GoodsInputDetail_Load(object sender, EventArgs e)
        {
/*            if (sizeList == null)
            {
                sizeList = SizeLogic.FindAll(null);
                cbbProductSize.DisplayMember = "SizeName";
                cbbProductSize.DataSource = sizeList;
            }
            if (colorList == null)
            {
                colorList = ColorLogic.FindAll(null);
                cbbProductColor.DisplayMember = "ColorName";
                cbbProductColor.DataSource = colorList;
            }
            if (typeList == null)
            {
                typeList = TypeLogic.FindAll(null);
                cbbProductType.DisplayMember = "TypeName";
                cbbProductType.DataSource = typeList;
            }
            if (countryList == null)
            {
                countryList = CountryLogic.FindAll(null);
                cbbCountry.DisplayMember = "CountryName";
                cbbCountry.DataSource = countryList;
            }*/
            PopullateProduct();
        }

        private void PopullateProduct()
        {
            if (Product != null)
            {

                PopullateProductMaster(Product.ProductMaster);
            }
        }

        private void PopullateProductMaster(ProductMaster productMaster)
        {
            txtProductName.Text = productMaster.ProductName;
            txtProductMasterId.Text = productMaster.ProductMasterId.ToString();
            if (productMaster.ProductType != null)
            {
                txtProductType.Text = productMaster.ProductType.TypeName;
            }
            else
            {
                txtProductType.Text = "";
            }

            if (productMaster.ProductSize != null)
            {
                txtProductSize.Text = productMaster.ProductSize.SizeName;
            }
            else
            {
                txtProductSize.Text = "";
            }

            if (productMaster.ProductColor != null)
            {
                txtProductColor.Text = productMaster.ProductColor.ColorName;
            }
            else
            {
                txtProductColor.Text = "";
            }

            if (productMaster.Country != null)
            {
                txtCountry.Text = productMaster.Country.CountryName;
            }
            else
            {
                txtCountry.Text = "";
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (Product == null) {
                Product = new Product();
            }
            if (Product.ProductMaster == null) 
            {
                Product.ProductMaster = new ProductMaster();
            }
            Product.ProductMaster.ProductName = txtProductName.Text;
            
            this.Close();
        }

        private void btnSelectProductMaster_Click(object sender, EventArgs e)
        {
            if (txtProductMasterId.Text.Length != 0)
            {
                ProductMaster productMaster = ProductMasterLogic.FindById(Int64.Parse(txtProductMasterId.Text));
                if (productMaster == null)
                {
                    MessageBox.Show("Không tìm thấy mã sản phẩm này!");
                }
                else
                {
                    PopullateProductMaster(productMaster);
                }
            }
        }
    }
}
