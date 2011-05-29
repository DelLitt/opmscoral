using System;

namespace AppFrame
{
   [Serializable]
   public class SearchCriteria
   {
      private int pageSize = 20;
      private int pageIndex = 1;

      public virtual int PageSize
      {
         get { return pageSize; }
         set { pageSize = value; }
      }

      public virtual int PageIndex
      {
         get { return pageIndex; }
         set { pageIndex = value; }
      }
   }
}