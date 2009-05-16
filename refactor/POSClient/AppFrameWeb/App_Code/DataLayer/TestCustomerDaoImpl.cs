using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AppFrame.DataLayer;
using AppFrame.Model;
using NHibernate;
using Spring.Data.NHibernate.Support;

/// <summary>
/// Summary description for CustomerDaoImpl
/// </summary>
namespace AppFrame.DataLayer
{
public class TestCustomerDaoImpl :HibernateDaoSupport,ITestCustomerDao
{

    #region ICustomerDao Members

    public bool saveCustomer(AppFrame.Model.CustomerModel customer)
    {
        HibernateTemplate.TemplateFlushMode = Spring.Data.NHibernate.TemplateFlushMode.Auto;
        
        HibernateTemplate.Save((customer));
        HibernateTemplate.Flush();
        return true;
    }

    public bool deleteCustomer(AppFrame.Model.CustomerModel customer)
    {
        HibernateTemplate.Delete(customer);
        return true;
    }

    public bool updateCustomer(AppFrame.Model.CustomerModel customer)
    {
        HibernateTemplate.Update(customer);
        HibernateTemplate.Flush();
        return true;
    }

    public IList searchCustomerByName(string name)
    {
        return HibernateTemplate.Find("FROM CustomerModel WHERE CustomerModel.CustomerName LIKE ? ", name);
    }

    public CustomerModel loadCustomer(int id)
    {
        return HibernateTemplate.Get(typeof (CustomerModel), id) as CustomerModel;
    }

    #endregion

    #region ICustomerDao Members


    public IList loadAllCustomers()
    {
        return HibernateTemplate.Find("FROM CustomerModel");
    }

    #endregion
}
}