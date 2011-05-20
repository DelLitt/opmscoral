using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.SalePoints;

namespace AppFrame.View.SalePoints
{
    public interface ISalePointSubStockView
    {
        event EventHandler<SalePointEventArgs> LoadDepartmentsEvent;
        event EventHandler<SalePointEventArgs> SaveDepartmentSubStockEvent;

        ISalePointController SalePointController { set; }
    }
}
