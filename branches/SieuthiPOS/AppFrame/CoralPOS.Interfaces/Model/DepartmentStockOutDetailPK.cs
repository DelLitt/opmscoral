﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoralPOS.Interfaces.Model
{
    [Serializable]
    public class DepartmentStockOutDetailPK
    {
        public virtual Int64 StockOutId
        {
            get;
            set;
        }
        public virtual Int64 DepartmentId
        {
            get;
            set;
        }
        public virtual string ProductId
        {
            get;
            set;
        }
        #region Equals and GetHashCode Methods
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}