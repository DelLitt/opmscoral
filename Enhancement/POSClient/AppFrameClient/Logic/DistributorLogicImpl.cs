using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DistributorLogicImpl : IDistributorLogic
    {
        public IDistributorDAO DistributorDAO { get; set; }

        /// <summary>
        /// Find Distributor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Distributor</param>
        /// <returns></returns>
        public Distributor FindById(object id)
        {
            return DistributorDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Distributor Add(Distributor data)
        {
            var maxId = DistributorDAO.SelectSpecificType(null, Projections.Max("DistributorId"));

            data.DistributorId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);
            DistributorDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Distributor data)
        {
            DistributorDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Distributor data)
        {
            DistributorDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DistributorDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Distributor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DistributorDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Distributor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DistributorDAO.FindPaging(criteria);
        }
    }
}