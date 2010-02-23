using System; 
using System.Collections.Generic; 
using System.Text; 


namespace CoralPOS.Models {
    
    
    [Serializable()]
    public class ProductMaster {
        
        public ProductMaster() {
        }
        
        public virtual string ProductMasterId {
            get;
            set;
        }
        
        public virtual string Barcode {
            get;
            set;
        }
        
        public virtual long CategoryId {
            get;
            set;
        }
        
        public virtual long CountryId {
            get;
            set;
        }
        
        public virtual System.DateTime CreateDate {
            get;
            set;
        }
        
        public virtual string CreateId {
            get;
            set;
        }
        
        public virtual long DelFlg {
            get;
            set;
        }
        
        public virtual string Description {
            get;
            set;
        }
        
        public virtual long DistributorId {
            get;
            set;
        }
        
        public virtual long ExFld1 {
            get;
            set;
        }
        
        public virtual long ExFld2 {
            get;
            set;
        }
        
        public virtual long ExFld3 {
            get;
            set;
        }
        
        public virtual string ExFld4 {
            get;
            set;
        }
        
        public virtual string ExFld5 {
            get;
            set;
        }
        
        public virtual long ExclusiveKey {
            get;
            set;
        }
        
        public virtual string ImagePath {
            get;
            set;
        }
        
        public virtual long ManufacturerId {
            get;
            set;
        }
        
        public virtual long PackagerId {
            get;
            set;
        }
        
        public virtual string ProductName {
            get;
            set;
        }
        
        public virtual long SupplierId {
            get;
            set;
        }
        
        public virtual long TypeId {
            get;
            set;
        }
        
        public virtual long UnitId {
            get;
            set;
        }
        
        public virtual System.DateTime UpdateDate {
            get;
            set;
        }
        
        public virtual string UpdateId {
            get;
            set;
        }
        
        public virtual ProductType ProductType {
            get;
            set;
        }
        
        public virtual Category Category {
            get;
            set;
        }
        
        public virtual Country Country {
            get;
            set;
        }
        
        public virtual Supplier Supplier {
            get;
            set;
        }
        
        public virtual ProductUnit ProductUnit {
            get;
            set;
        }
   	 protected bool Equals(ProductMaster entity)
		{
			if (entity == null) return false;
			if (!base.Equals(entity)) return false;
			
			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj as ProductMaster);
		}

		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			
			return result;
		}
 }
}
