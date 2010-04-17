using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrameClient.View.GoodsSale
{
    public partial class GoodsSalePrintForm : BaseForm
    {
        public GoodsSalePrintForm()
        {
            InitializeComponent();
        }

        public void FillForm(PurchaseOrder purchaseOrder)
        {
            PurchaseOrder = purchaseOrder;
            ModelToForm();
        }
        public PurchaseOrder PurchaseOrder
        {
            get; set;
        }
        public override void ModelToForm()
        {
            if(PurchaseOrder== null)
            {
                return;
            }
            lstBill.Items.Clear();
            lblDepartment.Text = CurrentDepartment.Get().DepartmentName.ToUpper();
            txtEmployee.Text = ClientInfo.getInstance().LoggedUser.Name.ToUpper();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            txtBillNumber.Text = PurchaseOrder.PurchaseOrderPK.PurchaseOrderId.ToUpper();

            foreach (PurchaseOrderDetail purchaseOrderDetail in PurchaseOrder.PurchaseOrderDetails)
            {
                lstBill.Items.Add(new ListViewItem(
                                      new string[]
                                          {
                                              purchaseOrderDetail.ProductMaster.ProductName,
                                              purchaseOrderDetail.Quantity.ToString(), 
                                              purchaseOrderDetail.Price.ToString("##,#00")
                                          }));
                
            }
            txtTotalAmount.Text = PurchaseOrder.PurchasePrice.ToString("##,#00");
            
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt (IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        public Bitmap CreateBitmap()
        {
            
            Bitmap memoryImage;
            Graphics mygraphics = this.CreateGraphics();
            this.Refresh();

            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            return memoryImage;
        }
    }
}
