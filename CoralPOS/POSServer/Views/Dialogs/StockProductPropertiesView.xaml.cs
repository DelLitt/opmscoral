﻿using System;
using System.Windows.Controls;
using System.Windows.Input;
using AppFrame.WPF;

namespace POSServer.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for ProductPropertiesView.xaml
    /// </summary>
    public partial class StockProductPropertiesView : UserControl
    {
        public StockProductPropertiesView()
        {
            InitializeComponent();
        }

        private void DataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid) sender;
            if(e.Key == Key.NumPad0 || e.Key == Key.D0)
            {
                foreach (DataGridRow row in grid.Items)
                {
                    row.IsSelected = !row.IsSelected;
                }
            }
            if(   (e.Key >= Key.NumPad1 && e.Key <=Key.NumPad9)
               || (e.Key >= Key.D1 && e.Key <=Key.D9))
            {
                KeyConverter converter = new KeyConverter(); 
                
                try
                {
                    int select = (int)converter.ConvertTo(e.Key,typeof(int));
                    DataGridRow row = (DataGridRow)grid.Items[select];
                    row.IsSelected = !row.IsSelected;
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.OemPlus)
            {
                ListBox listBox = (ListBox) sender;
                int addColorList = 0;
                if (listBox.Name.Equals("ExtraProductColorList"))
                {
                    addColorList = 1;
                }
                else
                {
                    addColorList = 2;
                }
                //this.Send("UpdateChosenList",addColorList);
            }
        }
        
    }
}
