using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Validation
{
    public class ObjectValidator<T> : IObjectValidator<T>
    {
        private IList rules = new ArrayList();
        private POSErrorResult errorResult = new POSErrorResult();

        public POSErrorResult ValidateResult
        {
            get
            {
                return errorResult;   
            }
        }
        public ObjectValidator()
        {
        
        }
        public ObjectValidator(T target)
        {
            Target = target;
        }
        public T Target
        {
            get; set;
        }
        public virtual void RegisterRules() {}

        public virtual POSErrorResult Validate()
        {
            return  new POSErrorResult();
        }

        public void AddRule()
        {
            throw new NotImplementedException();
        }
        public void AddError(POSError error)
        {
            errorResult.AddError(error);
        }
    }
}
