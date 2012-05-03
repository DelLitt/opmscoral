			 

			 

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



namespace POSClient.ViewModels.Stock
{
    [PerRequest(typeof(ITemplatePOSViewModel))]
    public class TemplatePOSViewModel : PosViewModel,ITemplatePOSViewModel  
    {

        private IShellViewModel _startViewModel;
        public TemplatePOSViewModel(IShellViewModel startViewModel)
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
		        
        public void Task()
        {
            
        }
		        
        public void button1()
        {
            
        }
		        
        public void button2()
        {
            
        }
		        
        public void button3()
        {
            
        }
		        
        public void button4()
        {
            
        }
		        
        public void button5()
        {
            
        }
		        
        public void button6()
        {
            
        }
				#endregion
		
        
        
    }
}