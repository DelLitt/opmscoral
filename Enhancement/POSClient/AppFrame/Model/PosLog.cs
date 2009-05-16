using System;
using System.Collections;

namespace AppFrame.Model
{
    #region PosLog
    /// <summary>
    /// PosLog object for NHibernate mapped table 'pos_log'.
    /// </summary>
    public class PosLog : System.IComparable
    {
    	#region Member Variables

        protected Int64 _id; 		
        protected DateTime _date;
        protected string _thread;
        protected string _level;
        protected string _logger;
        protected string _message;
        protected string _exception;
        protected string _posUser;
        protected string _posAction;

        #endregion

        #region Constructors

        public PosLog () 
        {
        }
        
        #endregion

        #region Public Properties

        public virtual Int64 Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public virtual DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        public virtual string Thread
        {
            get
            {
                return _thread;
            }
            set
            {
                _thread = value;
            }
        }
        public virtual string Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
        public virtual string Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }
        public virtual string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }
        public virtual string Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        }
        public virtual string PosUser
        {
            get
            {
                return _posUser;
            }
            set
            {
                _posUser = value;
            }
        }
        public virtual string PosAction
        {
            get
            {
                return _posAction;
            }
            set
            {
                _posAction = value;
            }
        }


        #endregion
        
        #region IComparable Methods
        
        public virtual int CompareTo(object obj)
        {
            return 0;
        }
        
        #endregion
        
        #region Equals and GetHashCode Methods
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);
            
        }

		// override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    #endregion
}