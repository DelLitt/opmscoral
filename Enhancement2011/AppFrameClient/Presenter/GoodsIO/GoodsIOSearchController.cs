using System;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;

namespace AppFrameClient.Presenter.GoodsIO
{
    public class GoodsIOSearchController : IGoodsIOSearchController
    {
        #region View use in IGoodsIOSearchController

        private IGoodsIOSearchView _goodsIOSearchView;
        public IGoodsIOSearchView GoodsIOSearchView
        { 
            get
            {
                return _goodsIOSearchView;
            }
            set
            {
                _goodsIOSearchView = value;
                _goodsIOSearchView.SearchBlockInDetailEvent += new System.EventHandler<GoodsIOSearchEventArgs>(goodsIOSearchView_SearchBlockInDetailEvent);
                _goodsIOSearchView.LoadBlockInDetailEvent += new System.EventHandler<GoodsIOSearchEventArgs>(goodsIOSearchView_LoadBlockInDetailEvent);
                _goodsIOSearchView.DeleteBlockInDetailEvent += new System.EventHandler<GoodsIOSearchEventArgs>(goodsIOSearchView_DeleteBlockInDetailEvent);
            }
        }

        #endregion

        public void goodsIOSearchView_DeleteBlockInDetailEvent(object sender, GoodsIOSearchEventArgs e)
        {
            // validate delete items

            // delete
            BlockInDetailLogic.DeleteList(e.DeleteList);

            // search again
            var criteria = new ObjectCriteria();
            if (!string.IsNullOrEmpty(e.BlockDetailId))
            {
                criteria.AddLikeCriteria("BlockInDetailPK.BlockDetailId", string.Format("{0}%", e.BlockDetailId));
            }
            criteria.AddGreaterOrEqualsCriteria("ImportDate", DateUtility.ZeroTime(e.ImportDateFrom));
            criteria.AddLesserOrEqualsCriteria("ImportDate", DateUtility.MaxTime(e.ImportDateTo));
            if (!e.IsNeedDelete)
            {
                criteria.AddEqCriteria("DelFlg", (Int64)0);
            }
            e.BlockDetailList = BlockInDetailLogic.FindAll(criteria);
        }


        public void goodsIOSearchView_SearchBlockInDetailEvent(object sender, GoodsIOSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            if (!string.IsNullOrEmpty(e.BlockDetailId))
            {
                criteria.AddLikeCriteria("BlockInDetailPK.BlockDetailId", string.Format("{0}%", e.BlockDetailId));
            }
            criteria.AddGreaterOrEqualsCriteria("ImportDate", DateUtility.ZeroTime(e.ImportDateFrom));
            criteria.AddLesserOrEqualsCriteria("ImportDate", DateUtility.MaxTime(e.ImportDateTo));
            if (!e.IsNeedDelete)
            {
                criteria.AddEqCriteria("DelFlg", (Int64)0);
            }
            e.BlockDetailList = BlockInDetailLogic.FindAll(criteria);
        }

        public void goodsIOSearchView_LoadBlockInDetailEvent(object sender, GoodsIOSearchEventArgs e)
        {
        }

        #region Logic use in IGoodsIOSearchController
        public IBlockInDetailLogic BlockInDetailLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<GoodsIOSearchEventArgs>

        public GoodsIOSearchEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion
    }
}
