			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
using NHibernate.Linq;
using Spring.Dao;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
	public class MainStockLogic : IMainStockLogic
	{
		private IMainStockDao _innerDao;
		public IMainStockDao MainStockDao
		{
			get 
			{ 
				return _innerDao; 
			}
			set 
			{ 
				_innerDao = value; 
			}
		}
		
		/// <summary>
		/// Find MainStock object by id. Return null if nothing is found
		/// </summary>
		/// <param name="id">Id of MainStock</param>
		/// <returns></returns>
		public MainStock FindById(object id)
		{
			return MainStockDao.FindById(id);
		}
		
		/// <summary>
		/// Add MainStock to database.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public MainStock Add(MainStock data)
		{
			MainStockDao.Add(data);
			return data;
		}
		
		/// <summary>
		/// Update MainStock to database.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public void Update(MainStock data)
		{
			MainStockDao.Update(data);
		}
		
		/// <summary>
		/// Delete MainStock from database.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public void Delete(MainStock data)
		{
			MainStockDao.Delete(data);
		}
		
		/// <summary>
		/// Delete MainStock from database.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public void DeleteById(object id)
		{
			MainStockDao.DeleteById(id);
		}
		
		/// <summary>
		/// Find all MainStock from database. No pagination.
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
		public IList<MainStock> FindAll(ObjectCriteria<MainStock> criteria)
		{
			return MainStockDao.FindAll(criteria);
		}
		
		/// <summary>
		/// Find all MainStock from database. Has pagination.
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
		public QueryResult FindPaging(ObjectCriteria<MainStock> criteria)
		{
			return MainStockDao.FindPaging(criteria);
		}

		public IList FindProductMasterAvailInStock(string name)
		{
			return (IList)MainStockDao.ExecuteExposedSession(delegate(ISession session)
																 {
																	 var query =
																		 from stock in
																			 session.Query<MainStock>()
																			 .Fetch(stk => stk.ProductMaster)
																		 where
																			 stock.Quantity > 0 &&
																			 stock.ProductMaster.ProductName.Contains(
																				 name)
																		 select stock;
																		 ;


				/*LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
			crit.AddCriteria(stk =>stk.Quantity > 0);
			crit.AddCriteria(stk =>stk.ProductMaster.ProductName.Contains(name));
			crit.MaxResult = 20;
			IList<ProductMaster> list = MainStockDao.FindAllSubProperty(crit, stk => stk.ProductMaster);*/
			IList<ProductMaster> list = query.ToList().Select(x =>x.ProductMaster).ToList();
			IList reslist = new ArrayList();
			ObjectUtility.AddToList(reslist,list,"ProductName");
			return reslist;    
			});
			
		}

		public IList GetColorsFromAvailProductInStock(string productName)
		{
			LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
			crit.AddCriteria(stk => stk.Quantity > 0);
			crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
			IList<ExProductColor> list = MainStockDao.FindAllSubProperty(crit, stk => stk.Product.ProductColor);
			return ObjectConverter.ConvertFrom(list);
		}

		public IList GetSizesFromAvailProductInStock(string productName)
		{
			LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
			crit.AddCriteria(stk => stk.Quantity > 0);
			crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
			IList<ExProductSize> list = MainStockDao.FindAllSubProperty(crit, stk => stk.Product.ProductSize);
			return ObjectConverter.ConvertFrom(list);
		}

		public IList GetProductFromAvailProductInStock(string productName)
		{
			LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
			crit.AddCriteria(stk => stk.Quantity > 0);
			crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
			IList<Product> list = MainStockDao.FindAllSubProperty(crit, stk => stk.Product);
			return ObjectConverter.ConvertFrom(list);
		}

		public IList FindAll(LinqCriteria<MainStock> crit)
		{
			return ObjectConverter.ConvertFrom(MainStockDao.FindAll(crit));
		}

		public MainStock FindByProductId(string productId)
		{
			ObjectCriteria<MainStock> objectCriteria = new ObjectCriteria<MainStock>();
			objectCriteria.Add(mstk => mstk.Product.ProductId == productId);
			return (MainStock)MainStockDao.FindFirst(objectCriteria);
		}

		/// <summary>
		/// Useless method
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
		public IList<MainStock> FetchAll(LinqCriteria<MainStock> criteria)
		{
			return (IList<MainStock>)MainStockDao.ExecuteExposedSession(delegate(ISession session)
												   {
													   var query = from item in session.Query<MainStock>()
																   select item;

													   //Tack on  query Criteria parameter
													   foreach (var criterion in criteria.Where)
													   {
														   query = query.Where<MainStock>(criterion);
													   }

													   foreach (var criterion in criteria.Order)
													   {
														   query = query.OrderBy(criterion);

													   }
													   /*//query = query.Where(stk => stk.ProductMaster.ProductName == productName);
													   query = query.Where(stk => stk.Quantity > 0);
													   crit.Fetch(i => i.Product);
													   crit.Fetch(i => i.ProductMaster);
													   crit.Fetch(i => i.ProductMaster.ProductType);*/
													   query = query.Fetch(i => i.Product).
														   ThenFetch(i=>i.ProductSize);
													   query = query.Fetch(i => i.ProductMaster);
													   query = query.Fetch(i => i.ProductMaster).
														   ThenFetch(i => i.ProductType);
													   query = query.Fetch(i => i.Product).
														   ThenFetch(i => i.ProductColor);

													   if (criteria.MaxResult > 0)
													   {

													   }
													   return query.ToList();
												   });

		}

		[Transaction]
		public void Update(StockOut data)
		{
			long definitionStatusId = data.DefinitionStatus.DefectStatusId;
			if (definitionStatusId == DefinitionStatus.TEMP_STOCKOUT
				   || definitionStatusId == DefinitionStatus.PROTOTYPE) return;
			foreach (StockOutDetail outDetail in data.StockOutDetails)
			{
				string productId = outDetail.Product.ProductId;
				ObjectCriteria<MainStock> findStock = new ObjectCriteria<MainStock>();
				findStock.Add(stk => stk.Product.ProductId == productId);
				MainStock currentStock = MainStockDao.FindFirst(findStock) as MainStock;
				/*MainStock currentStock = (MainStock)MainStockDao.ExecuteExposedSession(delegate(ISession session)
																						   {
																							   var query =
																								   session.QueryOver<MainStock>()
																									   .Where(
																										   stk =>
																										   stk.Product.ProductId ==
																										   productId);
																							   return query.SingleOrDefault();
																						   });*/
				if (currentStock == null) // create new stock
				{
					throw new DataIntegrityViolationException("Could not find the product id in stock");
				}
				else // update current stock
				{
					// * ---- CHUA CO PHAN XUAT HANG HU LOI HONG MAT O DAY --------
					currentStock.Quantity -= outDetail.Quantity;
					currentStock.GoodQuantity -= outDetail.Quantity;
					currentStock.ExclusiveKey += 1;
					if (currentStock.Quantity < 0 || currentStock.GoodQuantity < 0)
						throw new DataIntegrityViolationException("Stock quantity of " + currentStock.Product.ProductId + " is zero.");
					MainStockDao.Update(currentStock);
				}
			}
		}

	    public void UpdateStockQuantity(IList<StockOutDetail> details)
	    {
	        var productIds = (from detail in details
	                         select detail.Product.ProductId).ToList();

	        var stocks = (IList<MainStock>)MainStockDao.ExecuteExposedSession(
                session => session.QueryOver<MainStock>().Where(a=>a.Product.ProductId.IsIn(productIds)).List());
            foreach (StockOutDetail detail in details)
            {
                foreach (MainStock stock in stocks)
                {
                    if (stock.Product.ProductId.Equals(detail.Product.ProductId))
                    {
                        detail.StockQuantity = stock.Quantity;
                        break;
                    }
                }
            }
	    }
	}
}