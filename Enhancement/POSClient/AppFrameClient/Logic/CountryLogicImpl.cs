using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class CountryLogicImpl : ICountryLogic
    {
        public ICountryDAO CountryDAO { get; set; }

        /// <summary>
        /// Find Country object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Country</param>
        /// <returns></returns>
        public Country FindById(object id)
        {
            return CountryDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Country to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Country Add(Country data)
        {
            var maxId = CountryDAO.SelectSpecificType(null, Projections.Max("CountryId"));

            data.CountryId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);
            CountryDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Country to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Country data)
        {
            CountryDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Country from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Country data)
        {
            CountryDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Country from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CountryDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Country from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return CountryDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Country from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CountryDAO.FindPaging(criteria);
        }
    }
}