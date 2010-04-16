using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NMG.Core.Domain;

namespace NMG.Core
{
    [Serializable]
    public class TableReference
    {
        public string Name { get; set; }
        public string ReferenceTable { get; set; }
        public ReferenceType ReferenceType { get; set; }
        
        public Dictionary<ColumnDetail, ColumnDetail> TableColumns { get; set; }
    }

    public enum ReferenceType
    {
        OneToMany,ManyToOne,OneToOne,ManyToMany
    }

}
