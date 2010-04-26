using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace CoralPOS.Models
{
    [Serializable]
    [DataContract]
    public class SyncToDepartmentObject
    {
        public DateTime LastSyncTime { get; set;}
        public IList<StockOut> StockOutList { get; set;}
        
        [DataMember(Name = "1", Order = 1)]
        public Department Department { get; set;}
        
        
        public IList<ProductMaster> ProductMasterList { get; set;}
        
        
        public IList<MainPrice> PriceList { get; set;}
        
        
        public bool DepartmentInfo { get; set; }
        
        
        public bool ProductMasterInfo { get; set; }
        
        
        public bool PriceInfo { get; set; }


        // common information
        [DataMember(Name = "2", Order = 2)]
        public DataTable DepartmentList { get; set; }
        [DataMember(Name = "3", Order = 3)]
        public DataTable EmployeeInfo { get; set; }
        [DataMember(Name = "4", Order = 4)]
        public DataTable ProductMaster { get; set; }
        [DataMember(Name = "5", Order = 5)]
        public DataTable ProductType { get; set; }
        [DataMember(Name = "6", Order = 6)]
        public DataTable Category { get; set; }
        [DataMember(Name = "7", Order = 7)]
        public DataTable ProductColor { get; set; }
        [DataMember(Name = "8", Order = 8)]
        public DataTable ProductSize { get; set; }
        [DataMember(Name = "9", Order = 9)]
        public DataTable Product { get; set; }
        [DataMember(Name = "10", Order = 10)]
        public DataTable StockOut { get; set; }
        [DataMember(Name = "11", Order = 11)]
        public DataTable StockOutDetail { get; set; }

        [DataMember(Name = "12", Order = 12)]
        public DataTable Prices { get; set; }
    }
}