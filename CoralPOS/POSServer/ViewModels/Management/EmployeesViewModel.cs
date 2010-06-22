			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Utility;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;
using System.Linq;
using System.Linq.Expressions;
using POSServer.ViewModels.Menu.Management;


namespace POSServer.ViewModels.Management
{
    [AttachMenuAndMainScreen(typeof(IDeptEmpMenuViewModel), typeof(IManagementMainViewModel))]
    public class EmployeesViewModel : PosViewModel,IEmployeesViewModel  
    {

        private IShellViewModel _startViewModel;
        public EmployeesViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }
		        
        private string _employeeName;
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
                NotifyOfPropertyChange(() => EmployeeName);
            }
        }
		        
        private string _employeeId;
        public string EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
                NotifyOfPropertyChange(() => EmployeeId);
            }
        }
		        
        private string _cardId;
        public string CardId
        {
            get
            {
                return _cardId;
            }
            set
            {
                _cardId = value;
                NotifyOfPropertyChange(() => CardId);
            }
        }

        public IEmployeeInfoLogic EmployeeInfoLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List of boolean object
				#endregion
		
		#region List of date object
		        
        private DateTime _startDay;
        public DateTime StartDay
        {
            get
            {
                return _startDay;
            }
            set
            {
                _startDay = value;
                NotifyOfPropertyChange(() => StartDay);
            }
        }
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _employeeList;
        public IList EmployeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                NotifyOfPropertyChange(() => EmployeeList);
            }
        }
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Delete()
        {
            
        }
		        
        public void Edit()
        {
            
        }
		        
        public void Stop()
        {
            Flow.End();
        }
		        
        public void Create()
        {
            EmployeeInfo info = new EmployeeInfo
                                    {
                                        EmployeeName = EmployeeName,
                                        CreateDate = DateTime.Now,
                                        ExFld4= CardId,
                                        CreateId = "admin",
                                        UpdateDate = DateTime.Now,
                                        UpdateId = "admin",
                                        Birthday = StartDay
                                    };
            
            string empId = EmployeeInfoLogic.GenerateEmpId(info.EmployeeName);
            info.EmployeeId = empId;
            info.Barcode = EmployeeInfoLogic.GetNextBarcode();
            EmployeeInfoLogic.Add(info);
            MessageBox.Show("Save OK");
            InitContent();
        }

        private void InitContent()
        {
            EmployeeName = "";
            CardId = "";
            StartDay = DateTime.Now;
            IList<EmployeeInfo> list = EmployeeInfoLogic.FindAll(new ObjectCriteria<EmployeeInfo>());
            EmployeeList = list.OrderBy(m => m.EmployeeName).ToList();
        }

        public override void Initialize()
        {
            EmployeeList = new ArrayList();
            IList<EmployeeInfo> list = EmployeeInfoLogic.FindAll(new ObjectCriteria<EmployeeInfo>());
            EmployeeList = list.OrderBy(m => m.EmployeeName).ToList();
        }

        #endregion
		
        
        
    }
}