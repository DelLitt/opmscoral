using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Caliburn.PresentationFramework.Behaviors;
using CoralPOS.Models;

namespace CoralPOS.DTO
{
    [Serializable()]
    [Validate()]
    [DataContract()]
    public class DepartmentStockTempValidDTO
    {

        [DataMember(Name = "1", Order = 1)]
        public virtual System.DateTime CreateDate
        {
            get;
            set;
        }

        [DataMember(Name = "2", Order = 2)]
        public virtual long DepartmentId
        {
            get;
            set;
        }

        public virtual IList<DepartmentStockTempValid> DepartmentStockTempValids
        {
            get; set;
        }

        [DataMember(Name = "5", Order = 5)]
        public virtual string CreateId
        {
            get;
            set;
        }

        [DataMember(Name = "6", Order = 6)]
        public virtual long TotalDamageQuantity
        {
            get;
            set;
        }

        [DataMember(Name = "7", Order = 7)]
        public virtual long DelFlg
        {
            get;
            set;
        }

        [DataMember(Name = "8", Order = 8)]
        public virtual long TotalErrorQuantity
        {
            get;
            set;
        }

        [DataMember(Name = "9", Order = 9)]
        public virtual long ExFld1
        {
            get;
            set;
        }

        [DataMember(Name = "10", Order = 10)]
        public virtual long ExFld2
        {
            get;
            set;
        }

        [DataMember(Name = "11", Order = 11)]
        public virtual long ExFld3
        {
            get;
            set;
        }

        [DataMember(Name = "12", Order = 12)]
        public virtual string ExFld4
        {
            get;
            set;
        }

        [DataMember(Name = "13", Order = 13)]
        public virtual string ExFld5
        {
            get;
            set;
        }

        [DataMember(Name = "14", Order = 14)]
        public virtual long ExclusiveKey
        {
            get;
            set;
        }

        [DataMember(Name = "15", Order = 15)]
        public virtual long Fixed
        {
            get;
            set;
        }

        [DataMember(Name = "16", Order = 16)]
        public virtual long TotalGoodQuantity
        {
            get;
            set;
        }

        [DataMember(Name = "17", Order = 17)]
        public virtual long TotalLostQuantity
        {
            get;
            set;
        }

        [DataMember(Name = "18", Order = 18)]
        public virtual long OnStorePrice
        {
            get;
            set;
        }

        [DataMember(Name = "19", Order = 19)]
        public virtual ProductMaster ProductMaster
        {
            get;
            set;
        }

        [DataMember(Name = "20", Order = 20)]
        public virtual long TotalQuantity
        {
            get;
            set;
        }

        [DataMember(Name = "21", Order = 21)]
        public virtual long TotalUnconfirmQuantity
        {
            get;
            set;
        }

        [DataMember(Name = "22", Order = 22)]
        public virtual System.DateTime UpdateDate
        {
            get;
            set;
        }

        [DataMember(Name = "23", Order = 23)]
        public virtual string UpdateId
        {
            get;
            set;
        }
        
        [DataMember(Name = "24", Order = 23)]
        public virtual ExProductColor ProductColor
        {
            get;
            set;
        }

        [DataMember(Name = "24", Order = 23)]
        public virtual ExProductSize ProductSize
        {
            get;
            set;
        }

        public void CountQuantities()
        {
            TotalQuantity = TotalGoodQuantity = 0;
            foreach (DepartmentStockTempValid departmentStockTempValid in DepartmentStockTempValids)
            {
                TotalQuantity += departmentStockTempValid.Quantity;
                TotalGoodQuantity += departmentStockTempValid.GoodQuantity;
            }
        }

        public static IList<DepartmentStockTempValidDTO> From(IList<DepartmentStockTempValid> list)
        {
            var result = from tvl in list
                         group tvl by new
                                          {
                                              tvl.DepartmentStockTempValidPK.CreateDate,
                                              tvl.ProductMaster.ProductName,
                                              tvl.Product.ProductColor.ColorId,
                                              tvl.Product.ProductSize.SizeId
                                          }
                         into grpTvl
                         from t in grpTvl
                         select new DepartmentStockTempValidDTO
                                    {
                                        CreateDate = grpTvl.Key.CreateDate,
                                        DepartmentId = t.DepartmentStockTempValidPK.DepartmentId,
                                        DepartmentStockTempValids = grpTvl.Select(m => m).ToList(),
                                        ProductMaster = t.ProductMaster,
                                        ProductColor = t.Product.ProductColor,
                                        ProductSize = t.Product.ProductSize,
                                        TotalQuantity = grpTvl.Sum(m=>m.Quantity),
                                        TotalGoodQuantity = grpTvl.Sum(m=>m.GoodQuantity)
                                    };
            return result.ToList();

        }
        protected bool Equals(DepartmentStockTempValidDTO entity)
        {
            if (entity == null) return false;
            if (!base.Equals(entity)) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DepartmentStockTempValidDTO);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();

            return result;
        }
    }
}
