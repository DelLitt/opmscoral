using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Controls;
using AppFrame.Model;

namespace AppFrameClient.ViewModel
{
    
    public class StockView
    {
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual Int64 StockQuantity { get;set;}
        public virtual string ProductDisplayName
        {
            get
            {
                if(ProductMaster!=null)
                return ProductMaster.TypeAndName;
                else
                {
                    return "Empty";
                }
            }
        }
    }
}
