using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class ProductCollection : AFBaseCollection<Product>
    {
        public ProductCollection(BindingSource source) : base(source)
        {
        }

        public ProductCollection()
        {
        }

        public ProductCollection(IList<Product> list) : base(list)
        {
        }
    }
}
