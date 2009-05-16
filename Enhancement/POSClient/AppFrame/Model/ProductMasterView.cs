using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Model;

namespace AppFrame.Model
{
    public class ProductMasterView
    {
        public virtual string ImagePath { get; set; }
        
        public virtual string Barcode { get; set; }
        public virtual IList ProductMasterIdList
        {
            get; set;
        }

        public virtual string ProductName
        {
            get;set;
        }
        public virtual string Description
        {
            get;set;
        }
        
        public virtual Packager Packager
        {
            get;set;
        }


        public virtual ProductColor ProductColor
        {
            get;set;
        }


        public virtual Country Country
        {
            get;set;
        }


        public virtual Category Category
        {
            get;set;
        }


        public virtual Manufacturer Manufacturer
        {
            get;set;
        }


        public virtual ProductSize ProductSize
        {
            get;set;
        }


        // Product
        public virtual IList ProductMasters
        {
            get;set;
        }


        public virtual Distributor Distributor
        {
            get;set;
        }


        public virtual ProductType ProductType
        {
            get;set;
        }
    }
}
