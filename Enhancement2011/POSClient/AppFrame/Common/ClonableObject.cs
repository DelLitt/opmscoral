using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AppFrame.Common
{
    [Serializable]
    public class ClonableObject : ICloneable
    {
        #region ICloneable Members

        public virtual object Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);                    
            ms.Position = 0;                           
            object obj = bf.Deserialize(ms);           
            ms.Close();
            return obj;
        }
        
        #endregion
    }
}
