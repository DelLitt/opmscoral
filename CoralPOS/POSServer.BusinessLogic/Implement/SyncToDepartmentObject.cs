using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CoralPOS.Models;

namespace POSServer.BusinessLogic.Implement
{
    [Serializable]
    [DataContract]
    public class SyncToDepartmentObject
    {
        [DataMember(Name = "1", Order = 1)]
        public IList<StockOut> StockOutList { get; set;}

        [DataMember(Name = "2", Order = 2)]
        public Department Department { get; set;}
        
        [DataMember(Name = "3", Order = 3)]
        public IList<Product> ProductList { get; set;}
        
        [DataMember(Name = "4", Order = 4)]
        public IList<MainPrice> PriceList { get; set;}
        
        [DataMember(Name = "5", Order = 5)]
        public bool DepartmentInfo { get; set; }
        
        [DataMember(Name = "6", Order = 6)]
        public bool ProductMasterInfo { get; set; }
        
        [DataMember(Name = "7", Order = 7)]
        public bool PriceInfo { get; set; }
    }
}