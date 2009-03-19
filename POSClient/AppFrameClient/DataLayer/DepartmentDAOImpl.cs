using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public class DepartmentDAOImpl : IDepartmentDAO
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
        /// Find Department object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Department</param>
        /// <returns></returns>
        public Department FindById(object id)
        {
            return (Department)HibernateTemplate.Get(typeof(Department), id);
        }

        /// <summary>
        /// Add Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Department Add(Department data)
        {
            HibernateTemplate.Save(data);
            //HibernateTemplate.Flush();
            return data;
        }

        /// <summary>
        /// Update Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(Department data)
        {
            HibernateTemplate.Execute(
                delegate (ISession session)
                    {
                        session.Replicate(data,ReplicationMode.Overwrite);
                        return data;
                    }
                );
            //HibernateTemplate.Update(data);
            //HibernateTemplate.Flush();
        }

        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Delete(Department data)
        {
            HibernateTemplate.Delete(data);
        }

        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(object id)
        {
            Department obj = (Department)HibernateTemplate.Get(typeof(Department), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }

        /// <summary>
        /// Find all Department from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return (IList)HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    try
                    {
                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(Department));
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
                       
                    }
                }   
            );


            

            
        }

        /// <summary>
        /// Find all Department from database. Has pagination.
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

                ICriteria hibernateCriteria = session.CreateCriteria(typeof(Department));

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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(Department)).SetProjection(Projections.RowCount()); ;
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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(Department)).SetProjection(type); ;
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

        #region IDepartmentDAO Members

        /// <summary>
        /// Load exist department and all of employees
        /// </summary>
        /// <param name="department">Department</param>
        /// <returns></returns>
        public Department LoadDepartment(Department department)
        {
            return (Department)
            HibernateTemplate.Execute(
                  delegate(ISession session)
                      {
                            session.Lock(department, LockMode.Read);
                            IList employeesInfo = department.Employees;
                            foreach(EmployeeInfo employeeInfo in employeesInfo)
                            {
                                //Int64 empID = employeeInfo.EmployeeId;
                                Employee employee = employeeInfo.Employee;
                                EmployeePK employeePK = employeeInfo.EmployeePK;
                                //employeeInfo.EmployeeId = employeePK.EmployeeId;
                                employee.EmployeePK = employeePK;
                                employee.EmployeeInfo = employeeInfo;
                                employee.Department = department;
                                
                            }
                        return department;
                      }
                );
            
        }

        #endregion

        #region IDepartmentDAO Members


        public void SetInActiveAll()
        {
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Active",1);
            IList activeDepartments = FindAll(objectCriteria);
            foreach (Department department in activeDepartments)
            {
                department.Active = 0;                                
                Update(department);
            }
            /*HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        ITransaction tx = session.BeginTransaction();
                        string hqlUpdate = "UPDATE Department d SET d.Active = 0";
                        // or String hqlUpdate = "update Customer set name = :newName where name = :oldName";
                        int updatedEntities = session.CreateQuery(hqlUpdate)
                            .ExecuteUpdate();

                        tx.Commit();
                        return updatedEntities;
                    }
                );*/
        }

        #endregion
    }
}