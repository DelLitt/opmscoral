using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View;
using AppFrame.View.GoodsIO;
using NHibernate.Criterion;

namespace AppFrameClient.Presenter
{
    public class PosLogController : IPosLogController
    {
        #region View use in IGoodsIOSearchController

        private IPosLogView _posLogView;
        public IPosLogView PosLogView
        { 
            get
            {
                return _posLogView;
            }
            set
            {
                _posLogView = value;
                _posLogView.GetPosLogEvent += new System.EventHandler<PosLogEventArgs>(posLogView_GetPosLogEvent);
                _posLogView.SearchPosLogEvent += new System.EventHandler<PosLogEventArgs>(posLogView_SearchPosLogEvent);
            }
        }

        private void posLogView_SearchPosLogEvent(object sender, PosLogEventArgs e)
        {
            var criteria = new ObjectCriteria();
            if(!string.IsNullOrEmpty(e.Username))
            {
                criteria.AddLikeCriteria("PosUser", e.Username + "%");    
            }
            if(!string.IsNullOrEmpty(e.Action))
            {
                criteria.AddLikeCriteria("PosAction", e.Action + "%");    
            }
            DateTime fromDate = e.LogDateFrom;
            DateTime toDate = e.LogDateTo;
            criteria.AddGreaterOrEqualsCriteria("Date", fromDate);
            criteria.AddLesserOrEqualsCriteria("Date", toDate);
            criteria.AddOrder("Date", false);
            IList list = PosLogLogic.FindAll(criteria);
            e.PosLogList = list;
        }

        #endregion

        public void posLogView_GetPosLogEvent(object sender, PosLogEventArgs e)
        {
            if (e.PosLogId > 0)
            {
                e.PosLog = PosLogLogic.FindById(e.PosLogId);
            }
        }

        #region Implementation of IBaseController<PosLogEventArgs>

        public PosLogEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion

        public IPosLogLogic PosLogLogic { get; set; }
    }
}
