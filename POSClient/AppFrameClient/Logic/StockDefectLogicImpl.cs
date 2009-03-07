using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockDefectLogicImpl : IStockDefectLogic
    {
        private IStockDefectDAO _stockDefectDAO;

        public IStockDefectDAO StockDefectDAO
        {
            get
            {
                return _stockDefectDAO;
            }
            set
            {
                _stockDefectDAO = value;
            }
        }

        /// <summary>
        /// Find StockDefect object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockDefect</param>
        /// <returns></returns>
        public StockDefect FindById(object id)
        {
            return StockDefectDAO.FindById(id);
        }

        /// <summary>
        /// Add StockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public StockDefect Add(StockDefect data)
        {
            StockDefectDAO.Add(data);
            return data;
        }

        /// <summary>
        /// Update StockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Update(StockDefect data)
        {
            StockDefectDAO.Update(data);
        }

        /// <summary>
        /// Delete StockDefect from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Delete(StockDefect data)
        {
            StockDefectDAO.Delete(data);
        }

        /// <summary>
        /// Delete StockDefect from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void DeleteById(object id)
        {
            StockDefectDAO.DeleteById(id);
        }

        /// <summary>
        /// Find all StockDefect from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockDefectDAO.FindAll(criteria);
        }

        /// <summary>
        /// Find all StockDefect from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockDefectDAO.FindPaging(criteria);
        }

        #region IStockDefectLogic Members


        public void Process(StockDefect defect)
        {
            // find exist stock base on productid
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", defect.Product.ProductId);
            IList existList = StockDefectDAO.FindAll(objectCriteria);

            if (existList.Count > 0) // exist stock ?
            {
                StockDefect existDefect = (StockDefect)existList[0];
                existDefect.DamageCount = defect.DamageCount;
                existDefect.Description = defect.Description;
                existDefect.ErrorCount = defect.ErrorCount;
                existDefect.LostCount = defect.LostCount;
                existDefect.GoodCount = defect.GoodCount;
                existDefect.Product = defect.Product;
                existDefect.ProductMaster = defect.ProductMaster;
                existDefect.Quantity = defect.Quantity;
                existDefect.Stock = defect.Stock;
                existDefect.UnconfirmCount = defect.UnconfirmCount;
                existDefect.UpdateDate = defect.UpdateDate;
                existDefect.UpdateId = defect.UpdateId;

                existDefect.ExclusiveKey = existDefect.ExclusiveKey + 1;
                defect.StockDefectId = existDefect.StockDefectId;

                StockDefectDAO.Update(existDefect);
            }
            else
            {
                StockDefectDAO.Add(defect);
            }
        }

        #endregion

        #region IStockDefectLogic Members


        public long FindMaxStockDefectId()
        {
            object maxId = StockDefectDAO.SelectSpecificType(null, Projections.Max("StockDefectId"));
            if (maxId != null)
            {
                return (long) maxId;
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}