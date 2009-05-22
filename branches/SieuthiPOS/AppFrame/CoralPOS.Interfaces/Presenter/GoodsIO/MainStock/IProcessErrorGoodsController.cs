﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.View.GoodsIO.MainStock;
using CoralPOS.Interfaces.Logic;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IProcessErrorGoodsController
    {
        IProcessErrorGoodsView ProcessErrorGoodsView { get; set; }

        IStockOutLogic StockOutLogic { get; set; }
        IStockOutDetailLogic StockOutDetailLogic { get; set; }
        IStockLogic StockLogic { get; set; }

        IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
        IDepartmentStockLogic DepartmentStockLogic { get; set; }
    }
}
