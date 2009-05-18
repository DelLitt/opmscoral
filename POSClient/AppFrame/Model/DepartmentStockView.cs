using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    [Serializable]
    public class DepartmentStockView
    {
        public virtual Int64 GoodQuantity { get; set; }
        public virtual Int64 DamageQuantity { get; set; }
        public virtual Int64 ErrorQuantity { get; set; }
        public virtual Int64 LostQuantity { get; set; }
        public virtual Int64 UnconfirmQuantity { get; set; }

        public virtual Int64 OldGoodQuantity { get; set; }
        public virtual Int64 OldDamageQuantity { get; set; }
        public virtual Int64 OldErrorQuantity { get; set; }
        public virtual Int64 OldLostQuantity { get; set; }
        public virtual Int64 OldUnconfirmQuantity { get; set; }

        public virtual Int64 DepartmentId
        {
            get; set;
        }
        public virtual string ProductId
        {
            get;set;
        }

        public virtual Int64 Quantity
        {
            get;set;
        }
        public virtual Int64 OnStorePrice
        {
            get;set;
        }
        public virtual DateTime CreateDate
        {
            get;set;
        }
        public virtual string CreateId
        {
            get;set;
        }
        public virtual DateTime UpdateDate
        {
            get;set;
        }
        public virtual string UpdateId
        {
            get;set;
        }
        public virtual Int64 ExclusiveKey
        {
            get;set;
        }
        public virtual Int64 DelFlg
        {
            get;set;
        }

        public virtual IList DepartmentStocks
        {
            get;set;
        }
        public virtual ProductMaster ProductMaster { get; set; }
    }
}
