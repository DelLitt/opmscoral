using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Common;
using AppFrame.Utility;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public class ProductMasterDAOImpl : IProductMasterDAO
    {
        private HibernateTemplate _hibernateTemplate;

        public HibernateTemplate HibernateTemplate
        {
            get
            {
                return _hibernateTemplate;
            }
            set
            {
                _hibernateTemplate = value;
            }
        }

        /// <summary>
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        public ProductMaster FindById(object id)
        {
            ISession session = DbUtility.getSession(HibernateTemplate);
            try
            {
                return (ProductMaster)session.Get(typeof(ProductMaster), id);
            }
                finally
            {
                session.Close();
            }
            
        }

        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductMaster Add(ProductMaster data)
        {
            HibernateTemplate.Save(data);
            return data;
        }

        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(ProductMaster data)
        {
            HibernateTemplate.Update(data);
        }

        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Delete(ProductMaster data)
        {
            HibernateTemplate.Delete(data);
        }

        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(object id)
        {
            ProductMaster obj = (ProductMaster)HibernateTemplate.Get(typeof(ProductMaster), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }

        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            ISession session = DbUtility.getSession(HibernateTemplate);
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster));
                if (criteria != null)
                {
                    IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                    if (map.Count > 0)
                    {
                        foreach (string key in map.Keys)
                        {
                            hibernateCriteria.CreateAlias(key, key);
                        }
                        AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());

                        foreach (string key in map.Keys)
                        {
                            SubObjectCriteria subCriteria = null;
                            map.TryGetValue(key, out subCriteria);
                            AddCriteriaAndOrder(hibernateCriteria, subCriteria.GetWhere(), subCriteria.GetOrder());
                        }
                    }
                    else
                    {
                        AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());
                    }
                }
                return hibernateCriteria.List();
            }
            finally
            {
                if (session != null)
                {
                    session.Close();
                }
            }
        }

        /// <summary>
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            QueryResult queryResult = new QueryResult();
            if (criteria == null)
            {
                return null;
            }

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                int page = criteria.PageIndex;
                int pageSize = criteria.PageSize;
                queryResult.Page = page;

                int count = Count(criteria);
                if (count == 0)
                {
                    return null;
                }
                queryResult.TotalPage = (((count % pageSize == 0) ? (count / pageSize) : (count / pageSize + 1)));

                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster));

                IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                if (map.Count > 0)
                {
                    foreach (string key in map.Keys)
                    {
                        hibernateCriteria.CreateAlias(key, key);
                    }
                    AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());

                    SubObjectCriteria subCriteria = null;
                    foreach (string key in map.Keys)
                    {
                        map.TryGetValue(key, out subCriteria);
                        AddCriteriaAndOrder(hibernateCriteria, subCriteria.GetWhere(), subCriteria.GetOrder());
                    }
                }
                else
                {
                    AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());
                }
                hibernateCriteria.SetFirstResult((page - 1) * pageSize);
                hibernateCriteria.SetMaxResults(pageSize);
                IList list = hibernateCriteria.List();
                if (list.Count == 0)
                {
                    return null;
                }
                else
                {
                    queryResult.Result = list;
                }
            }
            finally
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }

            return queryResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        private int Count(ObjectCriteria criteria)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster)).SetProjection(Projections.RowCount()); ;
                if (criteria != null)
                {
                    IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                    if (map.Count > 0)
                    {
                        foreach (string key in map.Keys)
                        {
                            hibernateCriteria.CreateAlias(key, key);
                        }
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }

                        SubObjectCriteria subCriteria;
                        foreach (string key in map.Keys)
                        {
                            map.TryGetValue(key, out subCriteria);
                            foreach (ICriterion criterion in subCriteria.GetWhere())
                            {
                                hibernateCriteria.Add(criterion);
                            }
                        }
                    }
                    else
                    {
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }
                    }
                }
                return ((int)hibernateCriteria.List()[0]);
            }
            finally
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }
        }

        public object SelectSpecificType(ObjectCriteria criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster)).SetProjection(type); ;
                if (criteria != null)
                {
                    IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                    if (map.Count > 0)
                    {
                        foreach (string key in map.Keys)
                        {
                            hibernateCriteria.CreateAlias(key, key);
                        }
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }

                        SubObjectCriteria subCriteria;
                        foreach (string key in map.Keys)
                        {
                            map.TryGetValue(key, out subCriteria);
                            foreach (ICriterion criterion in subCriteria.GetWhere())
                            {
                                hibernateCriteria.Add(criterion);
                            }
                        }
                    }
                    else
                    {
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }
                    }
                }
                return (hibernateCriteria.List()[0]);
            }
            finally
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hibernateCriteria"></param>
        /// <param name="where"></param>
        /// <param name="orders"></param>
        private void AddCriteriaAndOrder(ICriteria hibernateCriteria, IEnumerable<ICriterion> where, IEnumerable<Order> orders)
        {
            foreach (ICriterion criterion in where)
            {
                hibernateCriteria.Add(criterion);
            }

            foreach (Order order in orders)
            {
                hibernateCriteria.AddOrder(order);
            }
        }

        public IList FindLikeId(object id, int limit, bool allDepartment)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   try
                                   {
                                       string queryString = "SELECT DISTINCT pm FROM ProductMaster pm ";
                                       if (!allDepartment)
                                       {
                                           queryString += ", DepartmentPrice dp ";
                                       }
                                       queryString += " WHERE pm.DelFlg = 0 ";
                                       if (!string.IsNullOrEmpty((string)id))
                                       {
                                           queryString += " AND pm.ProductMasterId LIKE '%" + (string) id + "%' " ;
                                       }
                                       

                                       if (!allDepartment) // if not search all so search by current department
                                       {
                                           queryString += " AND pm.ProductMasterId = dp.DepartmentPricePK.ProductMasterId ";
                                           queryString += " AND dp.DepartmentPricePK.DepartmentId = " + CurrentDepartment.Get().DepartmentId;
                                       }
                                                            
                                       IList productMasters = session.CreateQuery(queryString)
                                           .SetMaxResults(limit)
                                           .List();
                                       return productMasters;
                                   }
                                   catch (Exception e)
                                   {
                                       return null;
                                   }
                               }
                               );
        }

        public IList FindLikeName(object name, int limit, bool allDepartment)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   try
                                   {
                                       string queryString = "SELECT DISTINCT pm FROM ProductMaster pm ";
                                       if(!allDepartment)
                                       {
                                           queryString += ", DepartmentPrice dp ";
                                       }
                                       queryString+=" WHERE pm.DelFlg = 0 ";

                                       if (!string.IsNullOrEmpty((string)name))
                                       {
                                           queryString+= " AND pm.ProductName LIKE '%" + (string) name + "%' "; 
                                       }
                                       if (!allDepartment) // if not search all so search by current department
                                       {
                                           queryString += " AND pm.ProductMasterId = dp.DepartmentPricePK.ProductMasterId ";
                                           queryString += " AND dp.DepartmentPricePK.DepartmentId = " + CurrentDepartment.Get().DepartmentId;
                                       } 
                                       IList productMasters = session.CreateQuery(queryString)
                                           .List();
                                       return productMasters;
                                   }
                                   catch (Exception)
                                   {
                                       return null;
                                   }
                               }
                               );

        }

        #region IProductMasterDAO Members


        public IList FindProductColorsByName(string name)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   try
                                   {

                                       IList productColors =
                                           session.CreateQuery("SELECT DISTINCT pm.ProductColor FROM ProductMaster pm " +
                                                               " WHERE pm.ProductName = '" + (string)name + "' " +
                                                               " AND pm.DelFlg = 0 ")
                                                               .List();
                                       return productColors;
                                   }
                                   catch (Exception)
                                   {
                                       return null;
                                   }
                               }
                               );            
        }

        #endregion

        #region IProductMasterDAO Members


        public IList FindProductSizesByName(string name)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   try
                                   {

                                       IList productSizes =
                                           session.CreateQuery("SELECT DISTINCT pm.ProductSize FROM ProductMaster pm " +
                                                               " WHERE pm.ProductName = '" + (string)name + "' " +
                                                               " AND pm.DelFlg = 0 ")
                                                               .List();
                                       return productSizes;
                                   }
                                   catch (Exception)
                                   {
                                       return null;
                                   }
                               }
                               ); 
        }

        #endregion

        #region IProductMasterDAO Members


        public IList FindAllInDepartment(ProductMaster master, bool allDepartment)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   try
                                   {

                                       string queryString =
                                           "SELECT DISTINCT p.ProductMaster FROM ProductMaster pm, Product p ";
                                       if(!allDepartment)
                                       {
                                           queryString += ",DepartmentStockIn dsi,DepartmentStockInDetail dsid ";
                                       }
                                       queryString += " WHERE pm.ProductMasterId = p.ProductMaster.ProductMasterId " +
                                           " AND p.ProductMaster.ProductName LIKE '%" + (string)master.ProductName + "%' " +
                                                            " AND pm.DelFlg = 0 AND p.DelFlg = 0 ";

                                       if (master.ProductType != null && master.ProductType.TypeId > 0)
                                       {
                                           queryString += " AND pm.ProductType.TypeId = " + master.ProductType.TypeId;
                                       }
                                       
                                       if (master.ProductSize != null && master.ProductSize.SizeId > 0)
                                       {
                                           queryString += " AND pm.ProductSize.SizeId = " + master.ProductSize.SizeId; 
                                       }
                                       
                                       if (master.ProductColor != null && master.ProductColor.ColorId > 0)
                                       {
                                           queryString += " AND pm.ProductColor.ColorId = " + master.ProductColor.ColorId;
                                       }
                                       

                                       if (master.Country != null && master.Country.CountryId > 0)
                                       {
                                           queryString += " AND pm.Country.CountryId = " + master.Country.CountryId; 
                                       }


                                       if (!allDepartment) // if not search all so search by current department
                                       {
                                           //queryString += " AND pm.ProductMasterId = dsi.DepartmentStockInPK.DepartmentId ";
                                           queryString += " AND dsid.DepartmentStockInDetailPK.DepartmentId = " + CurrentDepartment.Get().DepartmentId;
                                           //queryString += " AND dsid.DepartmentStockInDetailPK.StockInId = dsi.DepartmentStockInPK.StockInId ";
                                           //queryString += " AND dsid.DepartmentStockInDetailPK.DepartmentId = dsi.DepartmentStockInPK.DepartmentId ";
                                           queryString += " AND p.ProductId = dsid.DepartmentStockInDetailPK.ProductId ";
                                       }

                                       // ORDER BY ProductName
                                       /*queryString +=
                                           " ORDER BY pm.ProductMasterName,pm.ProductColor.ColorId,pm.ProductSize.SizeId ";*/
                                       IList productMasters = session.CreateQuery(queryString)
                                           .SetMaxResults(500)
                                           .List();
                                       return productMasters;
                                   }
                                   catch (Exception e)
                                   {
                                       return null;
                                   }
                               }
                               );
        }

        #endregion
    }
}