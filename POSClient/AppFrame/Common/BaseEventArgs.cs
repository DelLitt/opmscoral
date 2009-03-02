using System;
using System.Collections;

namespace AppFrame.Common
{
    [Serializable]
    public class BaseEventArgs : EventArgs
    {
        private object eventResult;
        private string errorCode;
        private IList errorCodes;
        private string messageCode;

        public object EventResult
        {
            get { return eventResult; }
            set { eventResult = value; }
        }

        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        public string MessageCode
        {
            get { return messageCode; }
            set { messageCode = value; }
        }

        public IList ErrorCodes
        {
            get { return errorCodes; }
            set { errorCodes = value; }
        }
        public void AddErrorCode(string errCode)
        {
            ErrorCodes.Add(errCode);
        }
    }
}