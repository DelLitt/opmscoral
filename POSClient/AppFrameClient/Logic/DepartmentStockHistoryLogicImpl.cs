using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Exceptions;
using NHibernate;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockHistoryLogicImpl : IDepartmentStockHistoryLogic
    {
        private IDepartmentStockHistoryDAO _stockHistoryDAO;

        public IDepartmentStockHistoryDAO DepartmentStockHistoryDAO
        {
            get
            {
                return _stockHistoryDAO;
            }
            set
            {
                _stockHistoryDAO = value;
            }
        }

        /// <summary>
        /// Find DepartmentStockDefect object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockDefect</param>
        /// <returns></returns>
        public DepartmentStockHistory FindById(object id)
        {
            return DepartmentStockHistoryDAO.FindById(id);
        }

        /// <summary>
        /// Add DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public DepartmentStockHistory Add(DepartmentStockHistory data)
        {
            DepartmentStockHistoryDAO.Add(data);
            return data;
        }

        /// <summary>
        /// Update DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Update(DepartmentStockHistory data)
        {
            DepartmentStockHistoryDAO.Update(data);
        }

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Delete(DepartmentStockHistory data)
        {
            DepartmentStockHistoryDAO.Delete(data);
        }

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void DeleteById(object id)
        {
            DepartmentStockHistoryDAO.DeleteById(id);
        }

        /// <summary>
        /// Find all DepartmentStockDefect from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockHistoryDAO.FindAll(criteria);
        }

        /// <summary>
        /// Find all DepartmentStockDefect from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockHistoryDAO.FindPaging(criteria);
        }

        #region IDepartmentStockHistoryLogic Members

        [Transaction(ReadOnly = false)]
        public void Process(DepartmentStockHistory defect)
        {
            
            // find exist stock base on productid
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", defect.Product.ProductId);
            objectCriteria.AddEqCriteria("DepartmentStockDefectPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            IList existList = DepartmentStockHistoryDAO.FindAll(objectCriteria);

            if (existList.Count > 0) // exist stock ?
            {
                DepartmentStockHistory existDefect = (DepartmentStockHistory)existList[0];
                existDefect.DamageCount = defect.DamageCount;
                existDefect.Description = defect.Description;
                existDefect.ErrorCount = defect.ErrorCount;
                existDefect.LostCount = defect.LostCount;
                existDefect.GoodCount = defect.GoodCount;
                existDefect.Product = defect.Product;
                existDefect.ProductMaster = defect.ProductMaster;
                existDefect.Quantity = defect.Quantity;
                existDefect.DepartmentStock = defect.DepartmentStock;
                existDefect.UnconfirmCount = defect.UnconfirmCount;
                existDefect.UpdateDate = defect.UpdateDate;
                existDefect.UpdateId = defect.UpdateId;

                existDefect.ExclusiveKey = existDefect.ExclusiveKey + 1;
                defect.DepartmentStockHistoryPK.DepartmentStockHistoryId = existDefect.DepartmentStockHistoryPK.DepartmentStockHistoryId;
                defect.DepartmentStockHistoryPK.DepartmentId = CurrentDepartment.Get().DepartmentId;


                DepartmentStockHistoryDAO.Update(existDefect);
            }
            else
            {
                DepartmentStockHistoryDAO.Add(defect);
            }
        }

        #endregion

        #region IDepartmentStockHistoryLogic Members

        [Transaction(ReadOnly = false)]
        public void ProcessList(IList list)
        {
            object maxId = DepartmentStockHistoryDAO.SelectSpecificType(null, Projections.Max("DepartmentStockDefectPK.DepartmentStockDefectId"));
            long nextMaxId = maxId != null ? (long) maxId : 1;

            foreach (DepartmentStockHistory defect in list)
            {

                // find exist stock base on productid
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("Product.ProductId", defect.Product.ProductId);
                objectCriteria.AddEqCriteria("DepartmentStockDefectPK.DepartmentId",
                                             CurrentDepartment.Get().DepartmentId);
                IList existList = DepartmentStockHistoryDAO.FindAll(objectCriteria);

                if (existList.Count > 0) // exist stock ?
                {
                    DepartmentStockHistory existDefect = (DepartmentStockHistory) existList[0];
                    existDefect.DamageCount = defect.DamageCount;
                    existDefect.Description = defect.Description;
                    existDefect.ErrorCount = defect.ErrorCount;
                    existDefect.LostCount = defect.LostCount;
                    existDefect.GoodCount = defect.GoodCount;
                    existDefect.Product = defect.Product;
                    existDefect.ProductMaster = defect.ProductMaster;
                    existDefect.Quantity = defect.Quantity;
                    existDefect.DepartmentStock = defect.DepartmentStock;
                    existDefect.UnconfirmCount = defect.UnconfirmCount;
                    existDefect.UpdateDate = defect.UpdateDate;
                    existDefect.UpdateId = defect.UpdateId;

                    existDefect.ExclusiveKey = existDefect.ExclusiveKey + 1;
                    defect.DepartmentStockHistoryPK.DepartmentStockHistoryId =
                        existDefect.DepartmentStockHistoryPK.DepartmentStockHistoryId;
                    defect.DepartmentStockHistoryPK.DepartmentId = CurrentDepartment.Get().DepartmentId;


                    DepartmentStockHistoryDAO.Update(existDefect);
                }
                else
                {
                    defect.DepartmentStockHistoryPK.DepartmentStockHistoryId = nextMaxId++;
                    defect.DepartmentStockHistoryPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
                    
                    DepartmentStockHistoryDAO.Add(defect);
                }
            }
        }

        #endregion

        #region IDepartmentStockHistoryLogic Members


        public long GetMaxDefectId()
        {
            object maxId = DepartmentStockHistoryDAO.SelectSpecificType(null, Projections.Max("DepartmentStockDefectPK.DepartmentStockDefectId"));
            return maxId != null ? (long)maxId : 0;
        }

        #endregion

        #region IDepartmentStockHistoryLogic Members


        public IList FindAllProductMasters()
        {
            return DepartmentStockHistoryDAO.FindAllProductMasters();
        }

        #endregion

        #region IDepartmentStockHistoryLogic Members


        public IList FindByProductMasterName(ProductMaster master)
        {
            return DepartmentStockHistoryDAO.FindByProductMasterName(master);
        }

        #endregion
    }
}