			 

			 

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



namespace POSServer.ViewModels.Menu.Management
{
    [PerRequest(typeof(ICostMenuViewModel))]
    public class CostMenuViewModel : PosViewModel,ICostMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public CostMenuViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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