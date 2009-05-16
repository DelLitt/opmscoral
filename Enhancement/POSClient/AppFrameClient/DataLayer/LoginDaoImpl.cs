using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.DataLayer;
using AppFrame.Model;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;

namespace AppFrameClient.DataLayer
{
    public class LoginDaoImpl : HibernateDaoSupport, ILoginDao
    {


        public global::AppFrame.Model.LoginModel getInfo(string Username, string Password)
        {
            LoginModel model = null;
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("Suspended", 0);
            criteria.AddEqCriteria("Deleted", 0);
            criteria.AddEqCriteria("Username", Username);
            criteria.AddEqCriteria("Password", Password);
            IList modelList = FindAll(criteria);

            if (modelList != null && modelList.Count > 0)
            {
                return modelList[0] as LoginModel;                
            }
            return null;
        }


        public LoginModel getUser(string Username)
        {
            return HibernateTemplate.Get(typeof(LoginModel), Username) as LoginModel;
        }



        #region ILoginDao Members


        public LoginModel FindById(object id)
        {
            return (LoginModel)HibernateTemplate.Get(typeof(LoginModel), id);
        }

        public LoginModel Add(LoginModel data)
        {
            HibernateTemplate.Save(data);
            return data;
        }

        public void Update(LoginModel data)
        {
            HibernateTemplate.Update(data);
        }

        public void Delete(LoginModel data)
        {
            HibernateTemplate.Delete(data);
        }

        public void DeleteById(object id)
        {
            LoginModel obj = (LoginModel)HibernateTemplate.Get(typeof(LoginModel), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }

        public System.Collections.IList FindAll(AppFrame.ObjectCriteria criteria)
        {
            return (IList)HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    try
                    {
                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(LoginModel));
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
                    catch (Exception)
                    {
                        return null;
                    }

                }
                );
        }
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
        #endregion
    }
}
