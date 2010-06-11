using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Extensions;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.Invocation;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.DTO;
using CoralPOS.Models;
using NHibernate.Criterion;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Stock;


namespace POSServer.ViewModels.Stock.Inventory
{
    [AttachMenuAndMainScreen(typeof(IInventoryMenuViewModel),typeof(IStockMainViewModel))]
    public class StockInventoryViewModel : PosViewModel,IStockInventoryViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInventoryViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields

        private long _logicalSum;
        private long _realSum;
        private string _createDate;
        public string CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
                NotifyOfPropertyChange(() => CreateDate);
            }
        }
		        
        private string _barcode;
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                NotifyOfPropertyChange(() => Barcode);
            }
        }
		        
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

        private bool _checkSelectedDepartment;
        public bool CheckSelectedDepartment
        {
            get
            {
                return _checkSelectedDepartment;
            }
            set
            {
                _checkSelectedDepartment = value;
                NotifyOfPropertyChange(()=>CheckSelectedDepartment);
            }
        }

        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                NotifyOfPropertyChange(() => SelectedDepartment);
            }
        }

        private ProductType _selectedProductType;
        public ProductType SelectedProductType
        {
            get
            {
                return _selectedProductType;
            }
            set
            {
                _selectedProductType = value;
                NotifyOfPropertyChange(() => SelectedProductType);
            }
        }
        public IDepartmentLogic DepartmentLogic { get; set; }
        public IDepartmentStockTempValidLogic DepartmentStockTempValidLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
		        
        private IList _departments;
        public IList Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value;
                NotifyOfPropertyChange(() => Departments);
            }
        }
		        
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
				#endregion
		
		#region List of date object
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

        private IList _stockInventoryListFooter;
        public IList StockInventoryListFooter
        {
            get
            {
                return _stockInventoryListFooter;
            }
            set
            {
                _stockInventoryListFooter = value;
                NotifyOfPropertyChange(() => StockInventoryListFooter);
            }
        }

        public long LogicalSum
        {
            get { return _logicalSum; }
            set { _logicalSum = value; NotifyOfPropertyChange(()=>LogicalSum);}
        }

        public long RealSum
        {
            get { return _realSum; }
            set { _realSum = value; NotifyOfPropertyChange(()=>RealSum);}
        }

        #endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void TempLoad()
        {
            
        }
		        
        public void TempSave()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End();
        }
		        
        public void button1()
        {
            
        }
		        
        public void SaveResult()
        {
            this.ExecuteAsync(SaveEvaluationResult); 
        }
		        
        public void Delete()
        {
            
        }
		        
        public void Reset()
        {
            Flow.IsRepeated = true;
            Flow.End();
        }
		
        private object SaveEvaluationResult()
        {
            DepartmentStockTempValidLogic.AddBatch(StockInventoryList as IList<DepartmentStockTempValid>);
            return 0;
        }


        public void InputByFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.txt | Text Files";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            // if has file to open
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                IList<string> errorList;
                IDictionary<string, long> productList = ObjectUtility.ReadProductList(openFileDialog.FileName,
                                                                                      out errorList);

                // add to stockOut list
                ArrayList details = new ArrayList(StockInventoryList);
                foreach (KeyValuePair<string, long> keyValuePair in productList)
                {
                    DepartmentStockTempValid result = (from sod in details.OfType<DepartmentStockTempValid>()
                                             where sod.Product.ProductId.Equals(keyValuePair.Key)
                                             select sod).FirstOrDefault();
                    if (result != null) // if exist in list
                    {
                        result.Quantity += keyValuePair.Value;
                    }
                    else
                    {
                        
                        // get information from database
                        DepartmentStockTempValid tempValid = DepartmentStockTempValidLogic.CreateFromProductId(keyValuePair.Key,SelectedDepartment.DepartmentId);
                        if(tempValid == null) throw new InvalidDataException("Can not found product in database !");
                        tempValid.GoodQuantity = keyValuePair.Value;
                        details.Add(tempValid);
                    }
                }
                StockInventoryList = details;
                CalculateSum();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProcessBarcode()
        {
            this.ExecuteAsync(() => LoadBarcode());

        }

        private object LoadBarcode()
        {
            if (ObjectUtility.LengthEqual(Barcode, 12))
            {
                // add to stockOut list
                string barCode = Barcode;
                ArrayList details = new ArrayList(StockInventoryList);
                DepartmentStockTempValid result = (from sod in details.OfType<DepartmentStockTempValid>()
                                                   where sod.Product.ProductId.Equals(barCode)
                                                   select sod).FirstOrDefault();
                if (result != null) // if exist in list
                {
                    result.Quantity += 1;
                }
                else
                {

                    // get information from database
                    DepartmentStockTempValid tempValid = DepartmentStockTempValidLogic.CreateFromProductId(barCode, SelectedDepartment.DepartmentId);
                    if (tempValid == null) throw new InvalidDataException("Can not found product in database !");
                    tempValid.GoodQuantity = 1;
                    details.Add(tempValid);
                }

            }
            CalculateSum();
            return null;
        }

        public void ProcessProductTypeChange()
        {
            
        }
        public void ChangeDepartmentForEvaluate()
        {
            BackgroundTask backgroundTask = new BackgroundTask(() => PopulateStockTempValidList(SelectedDepartment));
            backgroundTask.Completed +=backgroundTask_Completed;
            StartWaitingScreen(0);
            backgroundTask.Start(SelectedDepartment);
            
        }

        private void backgroundTask_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            StopWaitingScreen(0);
            CheckSelectedDepartment = false;
        }

        private object PopulateStockTempValidList(Department selectedDepartment)
        {
            IList<DepartmentStockTempValid> list = DepartmentStockTempValidLogic.FindStockTempValidForDepartment(SelectedDepartment);
            /* ------------ PATCH FOR USING DepartmentStockTempValidDTO --------- */
            var showList = DepartmentStockTempValidDTO.From(list);
            StockInventoryList = showList as IList;
            CalculateSum();
            // populate ProductTypeList
            var productMasterList = (from stockValid in list
                                     select stockValid.ProductMaster).Distinct().ToList();
            var productTypeList = (from prdMaster in productMasterList
                                   select prdMaster.ProductType).Distinct().ToList();
            productTypeList.Insert(0,new ProductType{TypeId = 0,TypeName = "TAT CA CAC LOAI"});
            ProductTypeList = productTypeList as IList;
            ProductMasterList = productMasterList as IList;
            return 0;
        }
        
        public override void Initialize()
        {
            ObjectCriteria<Department> crit = new ObjectCriteria<Department>();
            crit.AddOrder(m => m.DepartmentId,Order.Asc);
            IList<Department> departments = DepartmentLogic.FindAll(crit);
            
            Departments =  departments as IList;
            SelectedDepartment = departments[0];
            StockInventoryList = new ArrayList();
            CheckSelectedDepartment = true;

            IList list = new ArrayList();
        }

        private void CalculateSum()
        {
            long totalQuantity = 0;
            long totalGoodQuantity = 0;
            foreach (DepartmentStockTempValidDTO master in StockInventoryList)
            {
                master.CountQuantities();
                totalQuantity += master.TotalQuantity;
                totalGoodQuantity += master.TotalGoodQuantity;
            }
            LogicalSum = totalQuantity;
            RealSum = totalGoodQuantity;
        }
        #endregion
		
        
        
    }
}