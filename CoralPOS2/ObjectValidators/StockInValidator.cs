using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Validation;
using CoralPOS.Models;

namespace CoralPOS.ObjectValidators
{
    public class StockInValidator : ObjectValidator<StockIn>
    {
        public override POSErrorResult Validate()
        {
            if(string.IsNullOrEmpty(Target.Description))
            {
                POSError error = ValidatorProvider.CreateError("Description must not be null or empty");
                ValidateResult.AddError(error);
            }
            if(Target.StockInDetails==null || Target.StockInDetails.Count == 0)
            {
                POSError error = ValidatorProvider.CreateError("Details must not be empty");
                ValidateResult.AddError(error);
            }
            else
            {
                foreach (StockInDetail inDetail in Target.StockInDetails)
                {
                    if(inDetail.Product == null)
                    {
                        POSError error = ValidatorProvider.CreateError("Product must not be null");
                        ValidateResult.AddError(error);
                    }
                    if(inDetail.Quantity <=0)
                    {
                        POSError error = ValidatorProvider.CreateError("Quantity of " + inDetail.ProductMaster.ProductName + " must greater than 0");
                        ValidateResult.AddError(error);
                    }
                    if (inDetail.Price <= 0)
                    {
                        POSError error = ValidatorProvider.CreateError("Price of " + inDetail.ProductMaster.ProductName + " must greater than 0");
                        ValidateResult.AddError(error);
                    }
                }
            }
            return ValidateResult;
        }
    }
}
