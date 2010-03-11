			 

			 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.Management
{
    [PerRequest(typeof(IDepartmentsViewModel))]
    public class DepartmentsViewModel : PosViewModel,IDepartmentsViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentsViewModel(IShellViewModel startViewModel)
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
		        
        private string _departmentName;
        public string DepartmentName
        {
            get
            {
                return _departmentName;
            }
            set
            {
                _departmentName = value;
                NotifyOfPropertyChange(() => DepartmentName);
            }
        }
		        
        private string _departmentId;
        public string DepartmentId
        {
            get
            {
                return _departmentId;
            }
            set
            {
                _departmentId = value;
                NotifyOfPropertyChange(() => DepartmentId);
            }
        }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _departmentsList;
        public IList DepartmentsList
        {
            get
            {
                return _departmentsList;
            }
            set
            {
                _departmentsList = value;
                NotifyOfPropertyChange(() => DepartmentsList);
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
            
        }
		        
        public void Create()
        {
            
        }
				#endregion
		
        
        
    }
}