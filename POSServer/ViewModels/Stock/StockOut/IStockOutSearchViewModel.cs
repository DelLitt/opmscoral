
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.Stock.StockOut
{
    public interface IStockOutSearchViewModel : IScreenNode
    {
        #region Fields

        string ProductMasterNames
        {
            get;
            set;
        }

        string ProductTypes
        {
            get;
            set;
        }

        bool DepartmentPick { get; set; }
        bool DatePick { get; set; }
        Department SelectedDepartment { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        IList CategoryList { get; set; }
        IList Departments { get; set; }
        IStockOutLogic StockOutLogic { get; set; }
        ICategoryLogic CategoryLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; }
        Category SelectedCategory { get; set; }

        #endregion
		
		#region Methods
		        
        void Help();
        
		        
        void ViewDetail();
        
		        
        void Stop();
        
		        
        void Search();
        
			#endregion
    }
}