using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Commands.ProductMaster
{
    public interface IProductTypeCommand
    {
        ProductTypeLogic ProductTypeLogic { get; set; }
    }
}
