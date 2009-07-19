using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportPOSData
{
    public class ImportObject
    {
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int TypeId { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string TypeName { get; set; }
        public string ProductMasterId { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public long Price { get; set; }
        public long MassPrice { get; set; }
        public long Quantity { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
    }
}
