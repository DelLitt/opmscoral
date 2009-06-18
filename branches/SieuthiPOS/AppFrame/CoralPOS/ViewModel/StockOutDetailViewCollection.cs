﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoralPOS.Interfaces.Collection;
using AppFrame.Collection;

namespace CoralPOS.ViewModel
{
    public class StockOutDetailViewCollection : BaseCollection<StockOutDetailView>
    {
        public StockOutDetailViewCollection(BindingSource source) : base(source)
        {
        }

        public StockOutDetailViewCollection()
        {
        }

        public StockOutDetailViewCollection(IList<StockOutDetailView> list) : base(list)
        {
        }
    }
}