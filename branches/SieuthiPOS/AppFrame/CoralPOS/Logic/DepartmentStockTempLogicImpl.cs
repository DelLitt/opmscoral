using System;
using System.Collections;
using System.Text;
using AppFrame;
using CoralPOS.Interfaces.Common;
using CoralPOS.Interfaces.Exceptions;
using CoralPOS.Interfaces.Utility.Mapper;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using CoralPOS.Interfaces.Model;
using CoralPOS.Interfaces.DataLayer;

namespace CoralPOS.Logic
{
    public class DepartmentStockTempLogicImpl : IDepartmentStockTempLogic
    {
        public IDepartmentStockTempDAO DepartmentStockTempDAO { get; set; }
        
        /// <summary>
        /// Find DepartmentStockTemp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemp</param>
        /// <returns></returns>
        public DepartmentStockTemp FindById(object id)
        {
            return DepartmentStockTempDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockTemp Add(DepartmentStockTemp data)
        {
            DepartmentStockTempDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockTemp data)
        {
            DepartmentStockTempDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockTemp data)
        {
            DepartmentStockTempDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockTempDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockTempDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockTempDAO.FindPaging(criteria);
        }

        public void TempSave(IList saveStockViewList)
        {
            foreach (DepartmentStockView view in saveStockViewList)
            {
                foreach (DepartmentStock stock in view.DepartmentStocks)
                {
                    DepartmentStockTemp temp = new DepartmentStockTempMapper().Convert(stock);
                    ObjectCriteria crit = new ObjectCriteria();
                    crit.AddEqCriteria("TempSave", 1);
                    crit.AddEqCriteria("Fixed", 0);
                    crit.AddEqCriteria("DelFlg", 0);            
                    crit.AddEqCriteria("DepartmentStockTempPK.DepartmentId",temp.DepartmentStockTempPK.DepartmentId);
                    crit.AddEqCriteria("DepartmentStockTempPK.ProductId", temp.DepartmentStockTempPK.ProductId);
                    IList list =DepartmentStockTempDAO.FindAll(crit);
                    if(list == null || list.Count == 0)
                    {
                        temp.TempSave = 1;
                        DepartmentStockTempDAO.Add(temp);
                    }
                    else
                    {
                        DepartmentStockTemp tempSave = (DepartmentStockTemp) list[0];
                        tempSave.Quantity = temp.Quantity;
                        tempSave.GoodQuantity = temp.GoodQuantity;
                        tempSave.ErrorQuantity = temp.ErrorQuantity;
                        tempSave.LostQuantity = temp.LostQuantity;
                        tempSave.UnconfirmQuantity = temp.UnconfirmQuantity;
                        tempSave.DamageQuantity = temp.DamageQuantity;
                        tempSave.TempSave = 1;
                        DepartmentStockTempDAO.Update(tempSave);
                    }
                }
            }
        }
    }
}