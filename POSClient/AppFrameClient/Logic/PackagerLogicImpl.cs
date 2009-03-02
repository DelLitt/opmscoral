using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PackagerLogicImpl : IPackagerLogic
    {
        public IPackagerDAO PackagerDAO { get; set; }

        /// <summary>
        /// Find Packager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Packager</param>
        /// <returns></returns>
        public Packager FindById(object id)
        {
            return PackagerDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Packager Add(Packager data)
        {
            var maxId = PackagerDAO.SelectSpecificType(null, Projections.Max("PackagerId"));

            data.PackagerId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);

            PackagerDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Packager data)
        {
            PackagerDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Packager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Packager data)
        {
            PackagerDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Packager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PackagerDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Packager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PackagerDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Packager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PackagerDAO.FindPaging(criteria);
        }
    }
}