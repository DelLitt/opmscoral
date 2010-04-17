using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    public class PurchaseOrderView
    {
        public string PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public string SellDescription { get; set; }
        public long SellQuantity { get; set; }
        public long SellAmount { get; set; }
        public IList ReturnPOList { get; set; }
        public long ReturnQuantity { get; set; }
        public long ReturnAmount { get; set; }
        public string ReturnDescription { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
