using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utility;
using AppFrame.Utils;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.DTO;
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
		public StockInventoryProcessingViewModel()
		{
			_startViewModel = ShellViewModel.Current;
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

        private DepartmentInventoryChecking _selectedEvaluationKey;
		public DepartmentInventoryChecking SelectedEvaluationKey
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

		private DepartmentStockTempValidDTO _tempValidDTO;
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
                CalculateSum();
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

		public DepartmentStockTempValidDTO TempValidDTO
		{
			get { return _tempValidDTO; }
			set { _tempValidDTO = value; 
				NotifyOfPropertyChange(()=>TempValidDTO);
			}
		}

		#endregion
		
		#region Methods

        private void CalculateSum()
        {
            long logicalSum = 0;
            long realSum = 0;
            foreach (DepartmentStockTempValidDTO tempValid in _stockInventoryList)
            {
                tempValid.CountQuantities();
                logicalSum += tempValid.TotalQuantity;
                realSum += tempValid.TotalGoodQuantity;
            }
            LogicalSum = logicalSum.ToString();
            RealSum = realSum.ToString();
        }

		/// <summary>
		/// Helps this instance.
		/// </summary>
		public void Help()
		{
			
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		public void Stop()
		{
			Flow.End();
		}

		/// <summary>
		/// Excels export.
		/// </summary>
		public void ExcelExport()
		{
			
		}

		/// <summary>
		/// Processes the result.
		/// </summary>
		public void ProcessResult()
		{
			//IList<DepartmentStockTempValid> list = Flow.Session.Get(FlowConstants.TEMP_VALID_PROCESSING_LIST) as IList<DepartmentStockTempValid>;
			
			IList<DepartmentStockTempValidDTO> processList = StockInventoryList as IList<DepartmentStockTempValidDTO>;

			// remove element which has TotalQuantity = RealTotalQuantity
			/*var processList1 = from tvl in list
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
						 select p1;*/
			var okList = from dto in processList
						 from tempValid in dto.DepartmentStockTempValids
						 where    dto.TotalQuantity != dto.TotalGoodQuantity 
							   && dto.Fixed == 0
						 select tempValid;
			// set processing flag for these product
			foreach (DepartmentStockTempValid departmentStockTempValid in okList)
			{
				departmentStockTempValid.ExFld1 = 1;
			}
			Flow.Session.Put(FlowConstants.TEMP_VALID_PROCESSING_LIST, processList);
			GoToNextNode(); 
		}

		/// <summary>
		/// Deletes this instance.
		/// </summary>
		public void Delete()
		{
			
		}

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset()
		{
			
		}

		/// <summary>
		/// Searches evaluation.
		/// </summary>
		public void SearchEvaluation()
		{
			DateTime fromDate = DateUtility.ZeroTime(FromDate);
			DateTime toDate = DateUtility.MaxTime(ToDate);
		    IList<DepartmentInventoryChecking> foundList = DepartmentStockTempValidLogic.FindInventoryChecking(fromDate, toDate);

			Flow.Session.Put(FlowConstants.TEMP_VALID_FOUND_LIST,foundList);

            //var evaluateDateList =  (from tempValid in foundList
            //                        group tempValid by new { tempValid.DepartmentStockTempValidPK.CreateDate,
            //                                                 tempValid.DepartmentStockTempValidPK.DepartmentId
            //                                               } into gr
            //                        select new DepartmentStockTempValidPK
            //                                   {
            //                                      CreateDate = gr.Key.CreateDate,
            //                                      DepartmentId = gr.Key.DepartmentId
            //                                   }).ToList();
            
			//EvaluationList = evaluateDateList.ToList();
		    EvaluationList = ObjectConverter.ConvertFrom(foundList);
		}

		/// <summary>
		/// Fixings this instance.
		/// </summary>
		public void Fixing()
		{
			TempValidDTO.Fixed = 1;
		}

		/// <summary>
		/// Selects the evaluation date.
		/// </summary>
		public void SelectEvaluationDate()
		{
            IList<DepartmentInventoryChecking> foundList = Flow.Session.Get(FlowConstants.TEMP_VALID_FOUND_LIST) as IList<DepartmentInventoryChecking>;
			/*var selectedChecking = from inventoryChecking in foundList
							  where inventoryChecking.CreateDate == SelectedEvaluationKey.CreateDate
							  select inventoryChecking;*/
		    IList<DepartmentStockTempValid> processList = DepartmentStockTempValidLogic.LoadDepartmentStockTempValid(SelectedEvaluationKey);
			Flow.Session.Put(FlowConstants.TEMP_VALID_PROCESSING_LIST,processList.ToList());
			/* ------------ PATCH FOR USING DepartmentStockTempValidDTO --------- */
			var showList = DepartmentStockTempValidDTO.From(processList.ToList());
			StockInventoryList = showList.ToList();
		    
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		protected override void OnInitialize()
		{
			StockInventoryList = new ArrayList();
			EvaluationList = new ArrayList();
			FromDate = ToDate = DateTime.Now;
			SelectedEvaluationKey = new DepartmentInventoryChecking();
			TempValidDTO = new DepartmentStockTempValidDTO();
		}

		#endregion
		
		
		
	}
}