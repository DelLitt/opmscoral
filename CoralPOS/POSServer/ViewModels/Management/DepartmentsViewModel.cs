			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Utils;
using Caliburn.Micro;


using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Management;


namespace POSServer.ViewModels.Management
{
    [AttachMenuAndMainScreen(typeof(DeptEmpMenuViewModel),typeof(ManagementMainViewModel))]
    public class DepartmentsViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public DepartmentsViewModel()
        {
            _startViewModel = ShellViewModel.Current;
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
        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        /// <value>The selected department.</value>
        public Department SelectedDepartment { get; set; }

        /// <summary>
        /// Gets or sets the department logic.
        /// </summary>
        /// <value>The department logic.</value>
        public IDepartmentLogic DepartmentLogic
        {
            get; set;
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

        /// <summary>
        /// Helps this instance.
        /// </summary>
        public void Help()
        {
            
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            IList list = new ArrayList(_departmentsList);
            ObjectUtility.RemoveFromList(list, SelectedDepartment, "DepartmentName");
            DepartmentsList = list;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            DepartmentLogic.Update(DepartmentsList);
            SetBackToParentFlow(FlowConstants.DEPARTMENTS, DepartmentsList);
            GoToNextNode(); 
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Flow.End(); 
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        public void Create()
        {
            IList list = new ArrayList(_departmentsList);
            list.Add(new Department
            {
                DepartmentName = "NONAME",
                CreateDate = DateTime.Now,
                Address = "UNKNOWN"
            });
            DepartmentsList = list;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected override void OnInitialize()
        {
            DepartmentLogic.LoadDefinition(Flow.Session);
            IList list = null;
            list = Flow.Session.Get(FlowConstants.DEPARTMENTS) as IList;
            if (list == null) list = new ArrayList();
            DepartmentsList = list;
        }

        #endregion
		
        
        
    }
}