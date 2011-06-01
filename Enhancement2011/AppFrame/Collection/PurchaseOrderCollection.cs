using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class PurchaseOrderCollection : AFBaseCollection<PurchaseOrder>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public PurchaseOrderCollection(BindingSource source) : base(source)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public PurchaseOrderCollection()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public PurchaseOrderCollection(IList<PurchaseOrder> list) : base(list)
        {
        }
    }
}
