
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Menu.Management
{
    public interface ICostMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void CostManagement();
        
		        
        void TimeAttendance();
        
		        
        void CalendarPresentList();
        
		        
        void CalendarAbsentList();
        
		        
        void CreateCalendarPresent();
        
			#endregion
    }
}