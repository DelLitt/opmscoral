using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ManufacturerLogicImpl : IManufacturerLogic
    {
        public IManufacturerDAO ManufacturerDAO { get; set; }

        /// <summary>
        /// Find Manufacturer object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Manufacturer</param>
        /// <returns></returns>
        public Manufacturer FindById(object id)
        {
            return ManufacturerDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Manufacturer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Manufacturer Add(Manufacturer data)
        {
            var maxId = ManufacturerDAO.SelectSpecificType(null, Projections.Max("ManufacturerId"));

            data.ManufacturerId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);

            ManufacturerDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Manufacturer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Manufacturer data)
        {
            ManufacturerDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Manufacturer from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Manufacturer data)
        {
            ManufacturerDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Manufacturer from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ManufacturerDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Manufacturer from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ManufacturerDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Manufacturer from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ManufacturerDAO.FindPaging(criteria);
        }
    }
}