using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Commands.ProductMaster
{

    public class ProductTypeCommand : IProductTypeCommand
    {
        public ProductTypeLogic ProductTypeLogic
        {
            get; set;
        }

        public void LoadDefinition(IFlowSession session)
        {
            ProductTypeLogic.LoadDefinition(session);
        }
    }
}
