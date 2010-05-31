			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Common;
using CoralPOS.Models;
using Neodynamic.WPF;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Tool
{

    [AttachMenuAndMainScreen(typeof(IToolMainViewModel), typeof(IMainView))]
    public class SystemConfigViewModel : PosViewModel,ISystemConfigViewModel  
    {

        private IShellViewModel _startViewModel;
        public SystemConfigViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _syncImportPath;
        public string SyncImportPath
        {
            get
            {
                return _syncImportPath;
            }
            set
            {
                _syncImportPath = value;
                NotifyOfPropertyChange(() => SyncImportPath);
            }
        }
		        
        private string _syncExportPath;
        public string SyncExportPath
        {
            get
            {
                return _syncExportPath;
            }
            set
            {
                _syncExportPath = value;
                NotifyOfPropertyChange(() => SyncExportPath);
            }
        }
		        
        private string _syncErrorPath;
        public string SyncErrorPath
        {
            get
            {
                return _syncErrorPath;
            }
            set
            {
                _syncErrorPath = value;
                NotifyOfPropertyChange(() => SyncErrorPath);
            }
        }
		        
        private string _syncSuccessPath;
        public string SyncSuccessPath
        {
            get
            {
                return _syncSuccessPath;
            }
            set
            {
                _syncSuccessPath = value;
                NotifyOfPropertyChange(() => SyncSuccessPath);
            }
        }
		        
        private string _syncBackupPath;
        public string SyncBackupPath
        {
            get
            {
                return _syncBackupPath;
            }
            set
            {
                _syncBackupPath = value;
                NotifyOfPropertyChange(() => SyncBackupPath);
            }
        }
		        
        private string _dbToolPath;
        public string DbToolPath
        {
            get
            {
                return _dbToolPath;
            }
            set
            {
                _dbToolPath = value;
                NotifyOfPropertyChange(() => DbToolPath);
            }
        }
				#endregion
		

		#region List use to fetch object for view
		        
        private IList _billPrinterList;
        public IList BillPrinterList
        {
            get
            {
                return _billPrinterList;
            }
            set
            {
                _billPrinterList = value;
                NotifyOfPropertyChange(() => BillPrinterList);
            }
        }
		        
        private IList _barcodeTypeList;
        public IList BarcodeTypeList
        {
            get
            {
                return _barcodeTypeList;
            }
            set
            {
                _barcodeTypeList = value;
                NotifyOfPropertyChange(() => BarcodeTypeList);
            }
        }
		        
        private IList _subStockInvoiceStockOutList;
        public IList SubStockInvoiceStockOutList
        {
            get
            {
                return _subStockInvoiceStockOutList;
            }
            set
            {
                _subStockInvoiceStockOutList = value;
                NotifyOfPropertyChange(() => SubStockInvoiceStockOutList);
            }
        }
		        
        private IList _connectionProtocol;
        public IList ConnectionProtocol
        {
            get
            {
                return _connectionProtocol;
            }
            set
            {
                _connectionProtocol = value;
                NotifyOfPropertyChange(() => ConnectionProtocol);
            }
        }
				#endregion

        private string _selectedBarcode;
        public string SelectedBarcode
        {
            get
            {
                return _selectedBarcode; 
            }
            set
            {
                _selectedBarcode = value;
                NotifyOfPropertyChange(()=>SelectedBarcode);
            }

        }

        private string _selectedPrinter;
        public string SelectedPrinter
        {
            get
            {
                return _selectedPrinter;
            }
            set
            {
                _selectedPrinter = value;
                NotifyOfPropertyChange(() => SelectedPrinter);
            }

        }

        private Department _selectedExportDept;
        public Department SelectedExportDept
        {
            get
            {
                return _selectedExportDept;
            }
            set
            {
                _selectedExportDept = value;
                NotifyOfPropertyChange(() => SelectedExportDept);
            }

        }
        
		#region List of boolean object
		        
        private bool _negativeSelling;
        public bool NegativeSelling
        {
            get
            {
                return _negativeSelling;
            }
            set
            {
                _negativeSelling = value;
                NotifyOfPropertyChange(() => NegativeSelling);
            }
        }
		        
        private bool _negativeStockOut;
        public bool NegativeStockOut
        {
            get
            {
                return _negativeStockOut;
            }
            set
            {
                _negativeStockOut = value;
                NotifyOfPropertyChange(() => NegativeStockOut);
            }
        }
		        
        private bool _stockInConfirm;
        public bool StockInConfirm
        {
            get
            {
                return _stockInConfirm;
            }
            set
            {
                _stockInConfirm = value;
                NotifyOfPropertyChange(() => StockInConfirm);
            }
        }
		        
        private bool _stockOutConfirm;
        public bool StockOutConfirm
        {
            get
            {
                return _stockOutConfirm;
            }
            set
            {
                _stockOutConfirm = value;
                NotifyOfPropertyChange(() => StockOutConfirm);
            }
        }
		        
        private bool _purchaseOrderConfirm;
        public bool PurchaseOrderConfirm
        {
            get
            {
                return _purchaseOrderConfirm;
            }
            set
            {
                _purchaseOrderConfirm = value;
                NotifyOfPropertyChange(() => PurchaseOrderConfirm);
            }
        }
		        
        private bool _subStockEmployeeChecking;
        private string _selectedProtocol;

        public bool SubStockEmployeeChecking
        {
            get
            {
                return _subStockEmployeeChecking;
            }
            set
            {
                _subStockEmployeeChecking = value;
                NotifyOfPropertyChange(() => SubStockEmployeeChecking);
            }
        }

        public IDepartmentLogic DepartmentLogic { get; set; }
				#endregion
		
		#region List of date object
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void GetImportPath()
        {
            
        }
		        
        public void GetExportPath()
        {
            
        }
		        
        public void GetErrorPath()
        {
            
        }
		        
        public void GetSuccessPath()
        {
            
        }
		        
        public void GetBackupPath()
        {
            
        }
		        
        public void GetDbToolPath()
        {
            
        }
		        
        public void Update()
        {
            SystemConfig config = SystemConfig.Instance;

            config.SyncImportPath = SyncImportPath;
            config.SyncExportPath = SyncExportPath;
            config.SyncErrorPath = SyncErrorPath;
            config.SyncBackupPath = SyncBackupPath;
            config.SyncSuccessPath = SyncSuccessPath;
            config.NegativeSelling = NegativeSelling;
            config.NegativeStockOut = NegativeStockOut;
            config.DbToolPath = DbToolPath;
            config.StockInConfirm = StockInConfirm;
            config.StockOutConfirm = StockOutConfirm;
            config.SubStockEmployeeChecking = SubStockEmployeeChecking;
            config.PurchaseOrderConfirm = PurchaseOrderConfirm;

            // printer
            config.BillPrinter = SelectedPrinter;

            config.BarcodeType = SelectedBarcode;
            config.ConnectionProtocol = SelectedProtocol;

            config.Save();
            MessageBox.Show("Update config OK!");
            
        }


        public string SelectedProtocol
        {
            get {
                return _selectedProtocol;
            }
            set {
                _selectedProtocol = value;
                NotifyOfPropertyChange(()=>SelectedProtocol);
            }
        }

        public void Default()
        {
            SystemConfig.Instance.CreateDefaultValue();

        }
		        
        public void Quit()
        {
            Flow.End();
        }

        public override void Initialize()
        {
            SystemConfig config = SystemConfig.Instance;
            bool loadSuccess = config.Load();
            if(!loadSuccess)
            {
                config.CreateDefaultValue();
            }
            // load printer lists
            IList cboPrinters = new ArrayList();
            PrinterSettings.StringCollection printerNames = PrinterSettings.InstalledPrinters;
            foreach (string printerName in printerNames)
            {
                cboPrinters.Add(printerName);
            }
            BillPrinterList = cboPrinters;
            // load department list
            IList deptList = DepartmentLogic.FindAll(new ObjectCriteria<Department>()) as IList;
            SubStockInvoiceStockOutList = deptList;

            BarcodeTypeList = Enum.GetNames(typeof(Symbology));
            // protocol list
            IList protocolList = new ArrayList();
            protocolList.Add("TcpIp");
            protocolList.Add("Http");
            ConnectionProtocol = protocolList;
            LoadConfigToViewModel();

            
        }

        private void LoadConfigToViewModel()
        {
            SystemConfig config = SystemConfig.Instance;

            SyncImportPath = config.SyncImportPath;
            SyncExportPath = config.SyncExportPath;
            SyncErrorPath = config.SyncErrorPath;
            SyncBackupPath = config.SyncBackupPath;
            SyncSuccessPath = config.SyncSuccessPath;
            NegativeSelling = config.NegativeSelling;
            NegativeStockOut = config.NegativeStockOut;
            DbToolPath = config.DbToolPath;
            StockInConfirm = config.StockInConfirm;
            StockOutConfirm = config.StockOutConfirm;
            SubStockEmployeeChecking = config.SubStockEmployeeChecking;
            PurchaseOrderConfirm = config.PurchaseOrderConfirm;
            SelectedPrinter = config.BillPrinter;
            SelectedBarcode = config.BarcodeType;
            SelectedProtocol = config.ConnectionProtocol;
        }

        #endregion
		
        
        
    }
}