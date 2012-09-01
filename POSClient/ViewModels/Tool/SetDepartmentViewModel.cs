			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;



namespace POSClient.ViewModels.Tool
{
    [PerRequest(typeof(ISetDepartmentViewModel))]
    public class SetDepartmentViewModel : PosViewModel,ISetDepartmentViewModel  
    {

        private IShellViewModel _startViewModel;
        public SetDepartmentViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
		        
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
		        
        public void SetDepartment()
        {
            
        }
		        
        public void Stop()
        {
            
        }
				#endregion
		
        
        
    }
}