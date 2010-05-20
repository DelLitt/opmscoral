			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.Tool
{
    [PerRequest(typeof(ISystemConfigViewModel))]
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
            
        }
		        
        public void Default()
        {
            
        }
		        
        public void Quit()
        {
            
        }
				#endregion
		
        
        
    }
}