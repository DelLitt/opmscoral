using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Base.Synchronize;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using CoralPOS.Models;
using Microsoft.Practices.ServiceLocation;
using POSServer.Actions.Stock.StockOut;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;
using ProtoBuf;
using ClientUtility = POSServer.Utils.ClientUtility;

namespace POSServer.Actions.Synchronize
{
    public class SyncToDepartmentAction : PosAction, ISyncToDepartmentAction
    {
        public ISyncLogic SyncLogic { get; set; }
        private IList resultList = null;

        public override void DoExecute()
        {
            SyncToDepartmentObject toDepartmentObject = Flow.Session.Get(FlowConstants.SYNC_TO_DEPARTMENT) as SyncToDepartmentObject;
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += SyncToDepartmentCompleted;
            DoExecuteAsync(() => SyncToDepartment(toDepartmentObject), toDepartmentObject);
            GoToNextNode();
        }
               
        
        public object SyncToDepartment(SyncToDepartmentObject toDepartmentObject)
        {
            toDepartmentObject = SyncLogic.SyncToDepartment(toDepartmentObject);
            IList departmentUsbList = ClientUtility.GetUSBDrives();
            foreach (var POSSyncDrive in departmentUsbList)
            {

                //var exportPath = (string)configurationAppSettings.GetValue("SyncExportPath", typeof(String));
                var configExportPath = POSSyncDrive + ClientSetting.SyncExportPath;
                if (string.IsNullOrEmpty(configExportPath) || !Directory.Exists(configExportPath))
                {
                    MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + configExportPath + "!Hãy kiễm tra file cấu hình phần SyncExportPath");
                    return -1;
                }
                resultList = new ArrayList();
                

                    Department department = toDepartmentObject.Department;
                    var exportPath = ClientUtility.EnsureSyncPath(configExportPath, department);
                    int countSyncFile = 1;
                        //DateTime lastSyncTime = ClientUtility.GetLastSyncTime(exportPath, department, ClientUtility.SyncType.SyncDown);
                        /*deptEvent = new DepartmentStockInEventArgs();
                        deptEvent.LastSyncTime = lastSyncTime;
                        deptEvent.Department = department;
                        EventUtility.fireEvent(LoadDepartmentStockInForExportEvent, this, deptEvent);

                        int countSyncFile = 1;
                        if (deptEvent.SyncFromMainToDepartment != null)*/
                            SyncToDepartmentObject first = new SyncToDepartmentObject();
                    first.Department = toDepartmentObject.Department;
                    first.ProductList = toDepartmentObject.ProductList;
                    first.PriceList = toDepartmentObject.PriceList;

                            string fileName = exportPath + "\\" + department.DepartmentId
                                              + "_" + countSyncFile.ToString()
                                              + "_SyncDown_"
                                              + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                                              + CommonConstants.SERVER_SYNC_FORMAT;
                            SyncResult result = new SyncResult();
                            result.FileName = fileName;
                            result.Status = "Thành công";
                            resultList.Add(result);
                            Stream stream = File.Open(fileName, FileMode.Create);
                            
                            Serializer.Serialize(stream, first);
                            stream.Flush();
                            stream.Close();

                            // write each stock out to a sync file for avoiding duplicate update
                            if (!ObjectUtility.IsNullOrEmpty(toDepartmentObject.StockOutList))
                            {
                                foreach (StockOut stockOut in toDepartmentObject.StockOutList)
                                {
                                    countSyncFile += 1;
                                    SyncToDepartmentObject soSync = new SyncToDepartmentObject();
                                    soSync.Department = toDepartmentObject.Department;
                                    soSync.StockOutList = new List<StockOut>();
                                    soSync.StockOutList.Add(stockOut);

                                    string soFileName = exportPath + "\\" + department.DepartmentId
                                                  + "_" + countSyncFile.ToString()
                                                  + "_SyncDown_"
                                                  + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                                                  + CommonConstants.SERVER_SYNC_FORMAT;
                                    SyncResult soResult = new SyncResult();
                                    soResult.FileName = soFileName;
                                    soResult.Status = "Thành công";
                                    resultList.Add(soResult);
                                    Stream soStream = File.Open(soFileName, FileMode.Create);
                                    Serializer.Serialize(stream, soSync);
                                    soStream.Flush();
                                    soStream.Close();
                                }
                            }
                    
                
                MessageBox.Show("Đồng bộ hoàn tất !");
            }
            return 0;
        }

        private IList<UsbSyncDisc> GetUSBDrives()
        {
            return new List<UsbSyncDisc>();
        }

        private void SyncToDepartmentCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StopLoading();
            GoToNextNode();
        }
    }
}
