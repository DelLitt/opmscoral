			 

			 

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



namespace POSServer.ViewModels.Menu.Management
{
    [PerRequest]
    public class CostMenuViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public CostMenuViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void CostManagement()
        {
            
        }
		        
        public void TimeAttendance()
        {
            
        }
		        
        public void CalendarPresentList()
        {
            
        }
		        
        public void CalendarAbsentList()
        {
            
        }
		        
        public void CreateCalendarPresent()
        {
            
        }
				#endregion
		
        
        
    }
}