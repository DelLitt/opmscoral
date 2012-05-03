using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Extensions;
using AppFrame.Invocation;
using AppFrame.Utils;
using CoralPOS.DTO;
using CoralPOS.Models;
using NHibernate.Criterion;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Stock;
using MessageBox = System.Windows.MessageBox;


namespace POSServer.ViewModels.Stock.Inventory
{
    /// <summary>
    /// 
    /// </summary>
    [AttachMenuAndMainScreen(typeof(IInventoryMenuViewModel),typeof(IStockMainViewModel))]
    public class StockInventoryViewModel : PosViewModel,IStockInventoryViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInventoryViewModel()
        {
            _startViewModel = ShellViewModel.Current;
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
        /// <summary>
        /// Gets or sets the stock inventory list.
        /// </summary>
        /// <value>The stock inventory list.</value>
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

        /// <summary>
        /// Helps this instance.
        /// </summary>
        public void Help()
        {
            
        }

        /// <summary>
        /// Temps the load.
        /// </summary>
        public void TempLoad()
        {
            
        }

        /// <summary>
        /// Temps the save.
        /// </summary>
        public void TempSave()
        {
            
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Flow.End();
        }
		        
        public void button1()
        {
            
        }

        /// <summary>
        /// Saves the result.
        /// </summary>
        public void SaveResult()
        {
            this.ExecuteAsync(SaveEvaluationResult); 
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
            Flow.IsRepeated = true;
            Flow.End();
        }

        /// <summary>
        /// Saves the evaluation result.
        /// </summary>
        /// <returns></returns>
        private object SaveEvaluationResult()
        {
            var saveResult = from dto in StockInventoryList.OfType<DepartmentStockTempValidDTO>()
                             from stv in dto.DepartmentStockTempValids
                             select stv;
            DepartmentStockTempValidLogic.AddBatch(saveResult.ToList());
            MessageBox.Show("Save successfully !");
            return 0;
        }


        /// <summary>
        /// Inputs by file.
        /// </summary>
        public void InputByFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.txt | Text Files";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            // if has file to open
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                this.ExecuteAsync(()=>
                                      {
                                          IList<string> errorList;
                                          IDictionary<string, long> productList = ObjectUtility.ReadProductList(openFileDialog.FileName,
                                                                                                                out errorList);

                                          // add to stockOut list
                                          ArrayList details = new ArrayList(StockInventoryList);

                                          foreach (KeyValuePair<string, long> keyValuePair in productList)
                                          {
                                              InsertBarcodeToList(details, keyValuePair.Key, keyValuePair.Value);
                                          }
                                          StockInventoryList = details;
                                          CalculateSum();
                                          return null;
                                      });
                
            }
        }

        /// <summary>
        /// Inserts the barcode to list.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="productId">The product id.</param>
        /// <param name="quantity">The quantity.</param>
        private void InsertBarcodeToList(ArrayList details, string productId, long quantity)
        {
            DepartmentStockTempValid result = (from sod in details.OfType<DepartmentStockTempValidDTO>()
                                               from stv in sod.DepartmentStockTempValids
                                               where stv.Product.ProductId.Equals(productId)
                                               select stv).FirstOrDefault();
            if (result != null) // if exist in list
            {
                result.GoodQuantity += quantity;
            }
            else
            {

                // get information from database
                DepartmentStockTempValid tempValid = DepartmentStockTempValidLogic.CreateFromProductId(productId, SelectedDepartment.DepartmentId);
                if (tempValid == null) throw new InvalidDataException("Can not found product in database !");
                tempValid.GoodQuantity = quantity;

                DepartmentStockTempValidDTO dto = (from sod in details.OfType<DepartmentStockTempValidDTO>()
                                                   where
                                                           sod.ProductMaster.ProductMasterId == tempValid.ProductMaster.ProductMasterId
                                                       && sod.ProductColor.ColorId == tempValid.Product.ProductColor.ColorId
                                                       && sod.ProductSize.SizeId == tempValid.Product.ProductSize.SizeId
                                                   select sod).FirstOrDefault();
                if (dto != null)
                {
                    dto.DepartmentStockTempValids.Add(tempValid);
                }
                else
                {
                    details.Add(DepartmentStockTempValidDTO.CreateFrom(tempValid));
                }
            }
        }


        /// <summary>
        /// Processes the barcode.
        /// </summary>
        public void ProcessBarcode()
        {
            this.ExecuteAsync(() => LoadBarcode());

        }

        /// <summary>
        /// Loads the barcode.
        /// </summary>
        /// <returns></returns>
        private object LoadBarcode()
        {
            if (ObjectUtility.LengthEqual(Barcode, 12))
            {
                ArrayList details = new ArrayList(StockInventoryList);
                // add to stockOut list
                string barCode = Barcode;
                InsertBarcodeToList(details,barCode,1);
                #region useless
                /*ArrayList details = new ArrayList(StockInventoryList);
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
                }*/
                
                #endregion
                StockInventoryList = details;

            }
            CalculateSum();
            return null;
        }

        /// <summary>
        /// Processes the product type change.
        /// </summary>
        public void ProcessProductTypeChange()
        {
            
        }
        /// <summary>
        /// Changes the department for evaluate.
        /// </summary>
        public void ChangeDepartmentForEvaluate()
        {
            BackgroundTask backgroundTask = new BackgroundTask(() => PopulateStockTempValidList(SelectedDepartment));
            backgroundTask.Completed +=backgroundTask_Completed;
            StartWaitingScreen(0);
            backgroundTask.Start(SelectedDepartment);
            
        }

        /// <summary>
        /// Handles the Completed event of the backgroundTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundTask_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            StopWaitingScreen(0);
            CheckSelectedDepartment = false;
        }

        /// <summary>
        /// Populates the stock temp valid list.
        /// </summary>
        /// <param name="selectedDepartment">The selected department.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected override void OnInitialize()
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

        /// <summary>
        /// Calculates the sum.
        /// </summary>
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