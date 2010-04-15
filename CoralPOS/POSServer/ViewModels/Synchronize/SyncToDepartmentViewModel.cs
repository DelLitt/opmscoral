			 

			 

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
using CoralPOS.Models;


namespace POSServer.ViewModels.Synchronize
{
    
    public class SyncToDepartmentViewModel : PosViewModel,ISyncToDepartmentViewModel  
    {

        private IShellViewModel _startViewModel;
        private IList _departments;

        private Department _selectedDepartment;

        private bool _departmentInfo;

        private bool _productMasterInfo;

        private bool _priceInfo;

        private IList _resultInfoList;

        public SyncToDepartmentViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
		        
        private IList _comboBox1;
        public IList comboBox1
        {
            get
            {
                return _comboBox1;
            }
            set
            {
                _comboBox1 = value;
                NotifyOfPropertyChange(() => comboBox1);
            }
        }
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _resultGrid;
        public IList ResultGrid
        {
            get
            {
                return _resultGrid;
            }
            set
            {
                _resultGrid = value;
                NotifyOfPropertyChange(() => ResultGrid);
            }
        }
				#endregion
		
		#region Methods

        public IList Departments
        {
            get { return _departments; }
            set { _departments = value; NotifyOfPropertyChange(()=>Departments);}
        }

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { _selectedDepartment = value; NotifyOfPropertyChange(() => SelectedDepartment); }
        }

        public bool DepartmentInfo
        {
            get { return _departmentInfo; }
            set { _departmentInfo = value; NotifyOfPropertyChange(() => DepartmentInfo); }
        }

        public bool ProductMasterInfo
        {
            get { return _productMasterInfo; }
            set { _productMasterInfo = value; NotifyOfPropertyChange(() => ProductMasterInfo); }
        }

        public bool PriceInfo
        {
            get { return _priceInfo; }
            set { _priceInfo = value; NotifyOfPropertyChange(() => PriceInfo); }
        }

        public IList ResultInfoList
        {
            get { return _resultInfoList; }
            set { _resultInfoList = value; NotifyOfPropertyChange(() => ResultInfoList); }
        }

        public void SyncToDepartment()
        {
            
        }
		        
        public void Quit()
        {
            
        }
				#endregion
		
        
        
    }
}