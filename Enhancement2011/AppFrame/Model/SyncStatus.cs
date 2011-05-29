using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Model
{
    public class SyncStatus
    {
        public virtual DateTime LastSyncDate { get; set; }
        public virtual string CreateId { get; set; }
    }
}
