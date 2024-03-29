using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Utility;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentTimelineLogicImpl : IDepartmentTimelineLogic
    {
        private IDepartmentTimelineDAO _departmentCostDAO;

        public IDepartmentTimelineDAO DepartmentTimelineDAO
        {
            get 
            { 
                return _departmentCostDAO; 
            }
            set 
            { 
                _departmentCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentTimeline object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentTimeline</param>
        /// <returns></returns>
        public DepartmentTimeline FindById(object id)
        {
            return DepartmentTimelineDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentTimeline Add(DepartmentTimeline data)
        {
            DepartmentTimelineDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentTimeline data)
        {
            DepartmentTimelineDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentTimeline from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentTimeline data)
        {
            DepartmentTimelineDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentTimeline from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentTimelineDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentTimeline from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentTimelineDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentTimeline from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentTimelineDAO.FindPaging(criteria);
        }
        [Transaction(ReadOnly = false)]
        public void ProcessPeriod(bool isSubmitPeriod)
        {
            // Save the end of period
            // select 5 day nearest
            //IList departmentTimelineList = new ArrayList();
            ObjectCriteria crit = new ObjectCriteria();
            crit.AddOrder("EndTime", false);
            crit.MaxResult = 5;
            IList list = DepartmentTimelineDAO.FindAll(crit);
            DateTime startTime = DateUtility.ZeroTime(DateTime.Now);
            if (list != null && list.Count > 0)
            {
                // update end time of nearest 5 timeline for sure transparency
                DepartmentTimeline departmentTimeline = (DepartmentTimeline) list[0];
                DateTime lastSubmitEndTime = departmentTimeline.EndTime;

                // get days which customer do not submit period 
                TimeSpan timeSpan = DateUtility.ZeroTime(DateTime.Now).Subtract(DateUtility.ZeroTime(lastSubmitEndTime));
                // fix those days in order we can sync for today.

                startTime = lastSubmitEndTime.AddSeconds(1);
                for (int i = 0; i < timeSpan.Days - 1; i++)
                {
                    DateTime nextDateTime = lastSubmitEndTime.AddDays(i + 1);
                    DepartmentTimeline fixTimeline = new DepartmentTimeline();
                    fixTimeline.WorkingDay = DateUtility.ZeroTime(nextDateTime);
                    fixTimeline.CreateDate = DateUtility.MaxTime(nextDateTime);
                    fixTimeline.UpdateDate = DateUtility.MaxTime(nextDateTime);
                    fixTimeline.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    fixTimeline.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    fixTimeline.StartTime = startTime;
                    fixTimeline.EndTime = DateUtility.MaxTime(nextDateTime);
                    DepartmentTimelinePK fixTimelinePK = new DepartmentTimelinePK
                                                             {
                                                                 DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                                 Period = nextDateTime.DayOfYear
                                                             };

                    fixTimeline.DepartmentTimelinePK = fixTimelinePK;
                    DepartmentTimelineDAO.Add(fixTimeline);
                    startTime = fixTimeline.EndTime.AddSeconds(1);
                }

            }
            // If submit period ( ket so ) then we ' ket so '
            DepartmentTimeline timeline = null;
            if (isSubmitPeriod)
            {
                timeline = new DepartmentTimeline();
                timeline.WorkingDay = DateUtility.ZeroTime(DateTime.Now);
                timeline.CreateDate = DateTime.Now;
                timeline.UpdateDate = DateTime.Now;
                timeline.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                timeline.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                timeline.StartTime = startTime;
                timeline.EndTime = DateTime.Now;
                DepartmentTimelinePK timelinePK = new DepartmentTimelinePK
                                                  {
                                                      DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                      Period = DateTime.Now.DayOfYear
                                                  };
                var dbTimeline = DepartmentTimelineDAO.FindById(timelinePK);
                if (dbTimeline != null)
                {
                    throw new BusinessException("Ngày hôm nay đã kết sổ");
                }
                timeline.DepartmentTimelinePK = timelinePK;
                DepartmentTimelineDAO.Add(timeline);

                //departmentTimelineList.Add(timeline);
            }
        }
    }
}