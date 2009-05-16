using System;
using System.Collections;
using System.ComponentModel;
using AppFrame.Controls;

namespace AppFrame.Model
{
    #region ProductMaster
    /// <summary>
    /// ProductMaster object for NHibernate mapped table 'product_master'.
    /// </summary>
    [TypeDescriptionProvider(typeof(ComplexCustomDescriptionProvider<ProductMaster>))]
    [Serializable]
    public class DepartmentStockProductMasterView : System.IComparable
    {
    	#region Member Variables

        #endregion

        #region Constructors

        public DepartmentStockProductMasterView() 
        {
        }
        
        #endregion

        #region Public Properties
        public virtual DepartmentStockProductMasterViewPK DepartmentStockProductMasterViewPK { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual Department Department { get; set; }
        public virtual Int64 Quantity { get; set; }
        public virtual Int64 Price { get; set; }
        public virtual string LastStockInDate { get; set; }

        #endregion
        
        #region IComparable Methods
        
        public virtual int CompareTo(object obj)
        {
            return 0;
        }
        
        #endregion
        
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
    #endregion
}