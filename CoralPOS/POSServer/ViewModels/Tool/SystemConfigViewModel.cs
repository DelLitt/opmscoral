			 

			 

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
		        
        private IList _billPrinter;
        public IList BillPrinter
        {
            get
            {
                return _billPrinter;
            }
            set
            {
                _billPrinter = value;
                NotifyOfPropertyChange(() => BillPrinter);
            }
        }
		        
        private IList _barcodeType;
        public IList BarcodeType
        {
            get
            {
                return _barcodeType;
            }
            set
            {
                _barcodeType = value;
                NotifyOfPropertyChange(() => BarcodeType);
            }
        }
		        
        private IList _subStockInvoiceStockOut;
        public IList SubStockInvoiceStockOut
        {
            get
            {
                return _subStockInvoiceStockOut;
            }
            set
            {
                _subStockInvoiceStockOut = value;
                NotifyOfPropertyChange(() => SubStockInvoiceStockOut);
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
		        
        private IList _negativeSelling;
        public IList NegativeSelling
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
		        
        private IList _negativeStockOut;
        public IList NegativeStockOut
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
		        
        private IList _stockInConfirm;
        public IList StockInConfirm
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
		        
        private IList _stockOutConfirm;
        public IList StockOutConfirm
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
		        
        private IList _purchaseOrderConfirm;
        public IList PurchaseOrderConfirm
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
		        
        private IList _subStockEmployeeChecking;
        public IList SubStockEmployeeChecking
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