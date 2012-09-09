using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    [PerRequest]
    public class PmSaveAction : PosAction
    {
        [Autowired]
        public IProductMasterLogic ProductMasterLogic { get; set; }
        [Autowired]
        public IMainPriceLogic MainPriceLogic { get; set; }
        private bool IsOK = false;
        private String message = "";
        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += SaveProductMasterCompleted;
            DoExecuteAsync(SaveProductMaster, null);
        }

        private void SaveProductMasterCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            if (IsOK)
            {
                MessageBox.Show(message);
                GoToNextNode();
            }
        }

        private object SaveProductMaster()
        {
            CoralPOS.Models.ProductMaster master = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_MASTER) as CoralPOS.Models.ProductMaster;
            IList productColors = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_COLORS_LIST) as IList;
            IList productSizes = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_SIZES_LIST) as IList;
            IsOK = ProductMasterLogic.Save(master, productColors, productSizes);
            if(IsOK)
            {
                message = master.ProductName + " đã được lưu thành công !";
                // save MainPrice with default value is 0. DO WE NEED ?
                MainPrice price = new MainPrice
                                      {
                                          MainPricePK = new MainPricePK
                                              {
                                                  DepartmentId = 0,
                                                  ProductMasterId = master.ProductMasterId
                                              },
                                              CreateDate = DateTime.Now,
                                              CreateId = "admin",
                                              DelFlg = 0,
                                              ExclusiveKey = 1,
                                              ProductMaster = master,
                                              UpdateDate = DateTime.Now,
                                              UpdateId = "admin",
                                              WholeSalePrice = 0,
                                              Price = 0
                                      };
                //MainPriceLogic.Add(price);
            }
            return null;
        }
    }
}
