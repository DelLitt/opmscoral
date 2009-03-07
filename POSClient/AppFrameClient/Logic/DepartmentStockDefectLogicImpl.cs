using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Exceptions;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockDefectLogicImpl : IDepartmentStockDefectLogic
    {
        private IDepartmentStockDefectDAO _stockDefectDAO;

        public IDepartmentStockDefectDAO DepartmentStockDefectDAO
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
        /// Find DepartmentStockDefect object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockDefect</param>
        /// <returns></returns>
        public DepartmentStockDefect FindById(object id)
        {
            return DepartmentStockDefectDAO.FindById(id);
        }

        /// <summary>
        /// Add DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public DepartmentStockDefect Add(DepartmentStockDefect data)
        {
            DepartmentStockDefectDAO.Add(data);
            return data;
        }

        /// <summary>
        /// Update DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Update(DepartmentStockDefect data)
        {
            DepartmentStockDefectDAO.Update(data);
        }

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Delete(DepartmentStockDefect data)
        {
            DepartmentStockDefectDAO.Delete(data);
        }

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void DeleteById(object id)
        {
            DepartmentStockDefectDAO.DeleteById(id);
        }

        /// <summary>
        /// Find all DepartmentStockDefect from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockDefectDAO.FindAll(criteria);
        }

        /// <summary>
        /// Find all DepartmentStockDefect from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockDefectDAO.FindPaging(criteria);
        }

        #region IDepartmentStockDefectLogic Members

        [Transaction(ReadOnly = false)]
        public void Process(DepartmentStockDefect defect)
        {
            
            // find exist stock base on productid
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", defect.Product.ProductId);
            objectCriteria.AddEqCriteria("DepartmentStockDefectPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            IList existList = DepartmentStockDefectDAO.FindAll(objectCriteria);

            if (existList.Count > 0) // exist stock ?
            {
                DepartmentStockDefect existDefect = (DepartmentStockDefect)existList[0];
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
                defect.DepartmentStockDefectPK.DepartmentStockDefectId = existDefect.DepartmentStockDefectPK.DepartmentStockDefectId;
                defect.DepartmentStockDefectPK.DepartmentId = CurrentDepartment.Get().DepartmentId;


                DepartmentStockDefectDAO.Update(existDefect);
            }
            else
            {
                DepartmentStockDefectDAO.Add(defect);
            }
        }

        #endregion

        #region IDepartmentStockDefectLogic Members

        [Transaction(ReadOnly = false)]
        public void ProcessList(IList list)
        {
            object maxId = DepartmentStockDefectDAO.SelectSpecificType(null, Projections.Max("DepartmentStockDefectPK.DepartmentStockDefectId"));
            long nextMaxId = maxId != null ? (long) maxId : 1;

            foreach (DepartmentStockDefect defect in list)
            {

                // find exist stock base on productid
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("Product.ProductId", defect.Product.ProductId);
                objectCriteria.AddEqCriteria("DepartmentStockDefectPK.DepartmentId",
                                             CurrentDepartment.Get().DepartmentId);
                IList existList = DepartmentStockDefectDAO.FindAll(objectCriteria);

                if (existList.Count > 0) // exist stock ?
                {
                    DepartmentStockDefect existDefect = (DepartmentStockDefect) existList[0];
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
                    defect.DepartmentStockDefectPK.DepartmentStockDefectId =
                        existDefect.DepartmentStockDefectPK.DepartmentStockDefectId;
                    defect.DepartmentStockDefectPK.DepartmentId = CurrentDepartment.Get().DepartmentId;


                    DepartmentStockDefectDAO.Update(existDefect);
                }
                else
                {
                    defect.DepartmentStockDefectPK.DepartmentStockDefectId = nextMaxId++;
                    defect.DepartmentStockDefectPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
                    
                    DepartmentStockDefectDAO.Add(defect);
                }
            }
        }

        #endregion

        #region IDepartmentStockDefectLogic Members


        public long GetMaxDefectId()
        {
            object maxId = DepartmentStockDefectDAO.SelectSpecificType(null, Projections.Max("DepartmentStockDefectPK.DepartmentStockDefectId"));
            return maxId != null ? (long)maxId : 0;
        }

        #endregion
    }
}