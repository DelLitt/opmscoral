
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Tool
{
	public interface ISystemConfigViewModel : IScreenNode
	{
		#region Fields
						
		string SyncImportPath
		{
			get;
			set;            
		}
						
		string SyncExportPath
		{
			get;
			set;            
		}
						
		string SyncErrorPath
		{
			get;
			set;            
		}
						
		string SyncSuccessPath
		{
			get;
			set;            
		}
						
		string SyncBackupPath
		{
			get;
			set;            
		}
						
		string DbToolPath
		{
			get;
			set;            
		}
			#endregion
		
		#region Methods
				
		void GetImportPath();
		
				
		void GetExportPath();
		
				
		void GetErrorPath();
		
				
		void GetSuccessPath();
		
				
		void GetBackupPath();
		
				
		void GetDbToolPath();
		
				
		void Update();
		
				
		void Default();
		
				
		void Quit();
		
			#endregion
	}
}