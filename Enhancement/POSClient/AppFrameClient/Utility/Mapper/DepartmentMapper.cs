using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Model;
using AppFrame.Utility.Mapper;
using AppFrameClient.View.SalePoints;

namespace AppFrameClient.Utility.Mapper
{
    public class DepartmentMapper : BaseMapper<Department, SalePointForm>
    {

        public Department Convert(SalePointForm source)
        {
            Department department = new Department();
            return null;
        }
    }
}
