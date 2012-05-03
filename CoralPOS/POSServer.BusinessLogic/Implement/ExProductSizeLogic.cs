			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using NHibernate.Criterion;
using POSServer.BusinessLogic.Common;
using Spring.Transaction.Interceptor;
using CoralPOS.Models;
using  POSServer.DataLayer.Implement;
using AppFrame.DataLayer;

namespace POSServer.BusinessLogic.Implement
{
	public class ExProductSizeLogic : IExProductSizeLogic
	{
		private IExProductSizeDao _innerDao;
		public IExProductSizeDao ExProductSizeDao
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
		/// Find ExProductSize object by id. Return null if nothing is found
		/// </summary>
		/// <param name="id">Id of ExProductSize</param>
		/// <returns></returns>
		public ExProductSize FindById(object id)
		{
			return ExProductSizeDao.FindById(id);
		}
		
		/// <summary>
		/// Add ExProductSize to database.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public ExProductSize Add(ExProductSize data)
		{
			ExProductSizeDao.Add(data);
			return data;
		}
		
		/// <summary>
		/// Update ExProductSize to database.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public void Update(ExProductSize data)
		{
			ExProductSizeDao.Update(data);
		}
		
		/// <summary>
		/// Delete ExProductSize from database.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public void Delete(ExProductSize data)
		{
			ExProductSizeDao.Delete(data);
		}
		
		/// <summary>
		/// Delete ExProductSize from database.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Transaction(ReadOnly=false)]
		public void DeleteById(object id)
		{
			ExProductSizeDao.DeleteById(id);
		}
		
		/// <summary>
		/// Find all ExProductSize from database. No pagination.
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
		public IList<ExProductSize> FindAll(ObjectCriteria<ExProductSize> criteria)
		{
			return ExProductSizeDao.FindAll(criteria);
		}
		
		/// <summary>
		/// Find all ExProductSize from database. Has pagination.
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
		public QueryResult FindPaging(ObjectCriteria<ExProductSize> criteria)
		{
			return ExProductSizeDao.FindPaging(criteria);
		}

		public void LoadDefinition(IFlowSession session)
		{
			IList<ExProductSize> productSizes = ExProductSizeDao.FindAll(new ObjectCriteria<ExProductSize>());
			session.Put(FlowConstants.PRODUCT_SIZE_LIST, productSizes);
		}

		public void Update(IList productSizeList)
		{
			var maxIdResult = ExProductSizeDao.SelectSpecificType(null, Projections.Max("SizeId"));
			long maxColorId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;
			foreach (ExProductSize productSize in productSizeList)
			{
				if (productSize.SizeId > 0)
				{
					ExProductSize current = ExProductSizeDao.FindById(productSize.SizeId);
					current.SizeName = productSize.SizeName;
					current.UpdateDate = DateTime.Now;
					ExProductSizeDao.Update(current);
				}
				else
				{
					productSize.SizeId = maxColorId++;
					productSize.CreateDate = DateTime.Now;
					productSize.UpdateDate = DateTime.Now;
					ExProductSizeDao.Add(productSize);
				}
			}

		}
	}
}