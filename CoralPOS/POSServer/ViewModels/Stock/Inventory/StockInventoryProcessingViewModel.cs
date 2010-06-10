			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utility;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;


namespace POSServer.ViewModels.Stock.Inventory
{
    //[PerRequest(typeof(IStockInventoryProcessingViewModel))]
    public class StockInventoryProcessingViewModel : PosViewModel,IStockInventoryProcessingViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInventoryProcessingViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
		        
        private string _logicalSum;
        public string LogicalSum
        {
            get
            {
                return _logicalSum;
            }
            set
            {
                _logicalSum = value;
                NotifyOfPropertyChange(() => LogicalSum);
            }
        }
		        
        private string _realSum;
        public string RealSum
        {
            get
            {
                return _realSum;
            }
            set
            {
                _realSum = value;
                NotifyOfPropertyChange(() => RealSum);
            }
        }

        private DepartmentStockTempValidPK _selectedEvaluationKey;
        public DepartmentStockTempValidPK SelectedEvaluationKey
        {
            get
            {
                return _selectedEvaluationKey;
            }
            set 
            {
                _selectedEvaluationKey = value;
                NotifyOfPropertyChange(() => SelectedEvaluationKey);
            }
        }

        public IDepartmentLogic DepartmentLogic { get; set; }
        public IDepartmentStockTempValidLogic DepartmentStockTempValidLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
		        
        private IList _productTypeList;
        public IList ProductTypeList
        {
            get
            {
                return _productTypeList;
            }
            set
            {
                _productTypeList = value;
                NotifyOfPropertyChange(() => ProductTypeList);
            }
        }
		        
        private IList _productMasterList;
        public IList ProductMasterList
        {
            get
            {
                return _productMasterList;
            }
            set
            {
                _productMasterList = value;
                NotifyOfPropertyChange(() => ProductMasterList);
            }
        }
				#endregion
		
		#region List of boolean object
		        
        private bool _filterDuplicate;
        public bool FilterDuplicate
        {
            get
            {
                return _filterDuplicate;
            }
            set
            {
                _filterDuplicate = value;
                NotifyOfPropertyChange(() => FilterDuplicate);
            }
        }
		        
        private bool _filterSlidedBarcode;
        public bool FilterSlidedBarcode
        {
            get
            {
                return _filterSlidedBarcode;
            }
            set
            {
                _filterSlidedBarcode = value;
                NotifyOfPropertyChange(() => FilterSlidedBarcode);
            }
        }
				#endregion
		
		#region List of date object
		        
        private DateTime _fromDate;
        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                NotifyOfPropertyChange(() => FromDate);
            }
        }
		        
        private DateTime _toDate;
        public DateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
                NotifyOfPropertyChange(() => ToDate);
            }
        }
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInventoryList;
        public IList StockInventoryList
        {
            get
            {
                return _stockInventoryList;
            }
            set
            {
                _stockInventoryList = value;
                NotifyOfPropertyChange(() => StockInventoryList);
            }
        }
		        
        private IList _evaluationList;
        public IList EvaluationList
        {
            get
            {
                return _evaluationList;
            }
            set
            {
                _evaluationList = value;
                NotifyOfPropertyChange(() => EvaluationList);
            }
        }

        

        #endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End();
        }
		        
        public void ExcelExport()
        {
            
        }
		        
        public void ProcessResult()
        {
            IList<DepartmentStockTempValid> list = Flow.Session.Get(FlowConstants.TEMP_VALID_PROCESSING_LIST) as IList<DepartmentStockTempValid>;

            // remove element which has TotalQuantity = RealTotalQuantity
            var processList1 = from tvl in list
                              where tvl.Quantity != tvl.GoodQuantity
                              select tvl;

            var okList = from t in list
                         group t by
                             new
                                 {
                                     t.ProductMaster.ProductMasterId,
                                     t.Product.ProductColor.ColorId,
                                     t.Product.ProductSize.SizeId
                                 }
                         into gr
                         from p1 in gr
                         where gr.Sum(m => m.Quantity) != gr.Sum(m => m.GoodQuantity)
                         select p1;
            foreach (DepartmentStockTempValid departmentStockTempValid in okList)
            {
                Console.WriteLine(departmentStockTempValid.ProductMaster.ProductName);
            }                    
                             /*new
                                    {
                                        TempValid = gr,
                                        TotalQuantity = gr.Sum(m => m.Quantity),
                                        RealTotalQuantity = gr.Sum(m => m.GoodQuantity)
                                    };*/
            
            /*var remainList =    from t in processList1
                                join p in okList on 
                                                new
                                                  {
                                                      t.ProductMaster.ProductMasterId,
                                                      t.Product.ProductColor.ColorId,
                                                      t.Product.ProductSize.SizeId
                                                  } 
                                                equals
                                                new  {
                                                        p.TempValid.Key.ProductMasterId,
                                                        p.TempValid.Key.ColorId,
                                                        p.TempValid.Key.SizeId
                                                   }
                                into ps
                                from p1 in ps
                                where p1.RealTotalQuantity!=p1.TotalQuantity
                                select p1.TempValid.Select(m =>m);*/

            
        }
		        
        public void Delete()
        {
            
        }
		        
        public void Reset()
        {
            
        }
		        
        public void SearchEvaluation()
        {
            DateTime fromDate = DateUtility.ZeroTime(FromDate);
            DateTime toDate = DateUtility.MaxTime(ToDate);
            IList<DepartmentStockTempValid> foundList = DepartmentStockTempValidLogic.FindByDate(fromDate,toDate);

            Flow.Session.Put(FlowConstants.TEMP_VALID_FOUND_LIST,foundList);

            var evaluateDateList =  (from tempValid in foundList
                                    group tempValid by new { tempValid.DepartmentStockTempValidPK.CreateDate,
                                                             tempValid.DepartmentStockTempValidPK.DepartmentId
                                                           } into gr
                                    select new DepartmentStockTempValidPK
                                               {
                                                  CreateDate = gr.Key.CreateDate,
                                                  DepartmentId = gr.Key.DepartmentId
                                               }).ToList();
            EvaluationList = evaluateDateList.ToList();
        }
		        
        public void Fixing()
        {
            
        }

        public void SelectEvaluationDate()
        {
            IList<DepartmentStockTempValid> foundList = Flow.Session.Get(FlowConstants.TEMP_VALID_FOUND_LIST) as IList<DepartmentStockTempValid>;
            var processList = from tempValid in foundList
                              where tempValid.DepartmentStockTempValidPK.CreateDate == SelectedEvaluationKey.CreateDate
                              select tempValid;
            Flow.Session.Put(FlowConstants.TEMP_VALID_PROCESSING_LIST,processList.ToList());

            StockInventoryList = processList.ToList();
        }
        public override void Initialize()
        {
            StockInventoryList = new ArrayList();
            EvaluationList = new ArrayList();
            FromDate = ToDate = DateTime.Now;
            SelectedEvaluationKey = new DepartmentStockTempValidPK();
        }

        #endregion
		
        
        
    }
}