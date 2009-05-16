using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.Masters;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.Masters;

namespace AppFrameClient.Presenter.Masters
{
    public class UniversalMasterSaveController : IUniversalMasterSaveController
    {
        #region View use in IGoodsIOSearchController

        private IUniversalMasterSaveView _universalMasterSaveView;
        public IUniversalMasterSaveView UniversalMasterSaveView
        { 
            get
            {
                return _universalMasterSaveView;
            }
            set
            {
                _universalMasterSaveView = value;
                _universalMasterSaveView.SaveUniversalMasterEvent += new System.EventHandler<UniversalMasterSaveEventArgs>(universalMasterSaveView_SaveUniversalMasterEvent);
            }
        }

        #endregion

        public void universalMasterSaveView_SaveUniversalMasterEvent(object sender, UniversalMasterSaveEventArgs e)
        {
            object obj = null;
            switch (e.MasterType)
            {
                case MasterType.PRODUCT_TYPE:
                    if (e.Id != 0)
                    {
                        obj = new ProductType{TypeId = e.Id, TypeName = e.Name, UpdateDate = DateTime.Now};
                        ProductTypeLogic.Update((ProductType)obj);
                    } 
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("TypeName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = ProductTypeLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new ProductType { TypeName = e.Name, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                            ProductTypeLogic.Add((ProductType)obj);
                        } 
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                case MasterType.PRODUCT_SIZE:
                    if (e.Id != 0)
                    {
                        obj = new ProductSize { SizeId = e.Id, SizeName = e.Name };
                        ProductSizeLogic.Update((ProductSize)obj);
                    }
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("SizeName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = ProductSizeLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new ProductSize { SizeName = e.Name };
                            ProductSizeLogic.Add((ProductSize)obj);
                        }
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                case MasterType.PRODUCT_COLOR:
                    if (e.Id != 0)
                    {
                        obj = new ProductColor { ColorId = e.Id, ColorName = e.Name };
                        ProductColorLogic.Update((ProductColor)obj);
                    }
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("ColorName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = ProductColorLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new ProductColor { ColorName = e.Name };
                            ProductColorLogic.Add((ProductColor)obj);
                        }
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                case MasterType.COUNTRY:
                    if (e.Id != 0)
                    {
                        obj = new Country { CountryId = e.Id, CountryName = e.Name };
                        CountryLogic.Update((Country)obj);
                    }
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("CountryName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = CountryLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new Country { CountryName = e.Name };
                            CountryLogic.Add((Country)obj);
                        }
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                case MasterType.DISTRIBUTOR:
                    if (e.Id != 0)
                    {
                        obj = new Distributor { DistributorId = e.Id, DistributorName = e.Name };
                        DistributorLogic.Update((Distributor)obj);
                    }
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("DistributorName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = DistributorLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new Distributor { DistributorName = e.Name };
                            DistributorLogic.Add((Distributor)obj);
                        }
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                case MasterType.MANUFACTURER:
                    if (e.Id != 0)
                    {
                        obj = new Manufacturer { ManufacturerId = e.Id, ManufacturerName = e.Name };
                        ManufacturerLogic.Update((Manufacturer)obj);
                    }
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("ManufacturerName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = ManufacturerLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new Manufacturer { ManufacturerName = e.Name };
                            ManufacturerLogic.Add((Manufacturer)obj);
                        }
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                case MasterType.PACKAGER:
                    if (e.Id != 0)
                    {
                        obj = new Packager { PackagerId = e.Id, PackagerName = e.Name };
                        PackagerLogic.Update((Packager)obj);
                    }
                    else
                    {
                        var criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("PackagerName", e.Name).AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList list = PackagerLogic.FindAll(criteria);
                        if (list.Count == 0)
                        {
                            obj = new Packager { PackagerName = e.Name };
                            PackagerLogic.Add((Packager)obj);
                        }
                        else
                        {
                            obj = list[0];
                        }
                    }
                    break;
                default:
                    break;
            }
            e.CreatedData = obj;
        }

        #region Logic use in IUniversalMasterSaveController
        public ICountryLogic CountryLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IManufacturerLogic ManufacturerLogic { get; set; }
        public IDistributorLogic DistributorLogic { get; set; }
        public IPackagerLogic PackagerLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<GoodsIOSearchEventArgs>

        public UniversalMasterSaveEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion

    }
}