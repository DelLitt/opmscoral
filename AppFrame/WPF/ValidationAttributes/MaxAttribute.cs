using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AppFrame.WPF.ValidationAttributes
{
    public class MaxAttribute : ValidationAttribute
    {
        public MaxAttribute(int MaxValue)
            : base()
        {
            this.MaxValue = MaxValue;
        }

        public MaxAttribute(string MaxValue)
            : base()
        {
            this.MaxValue = int.Parse(MaxValue);
        }
        public override bool IsValid(object value)
        {
            int val;
            bool isNumber = int.TryParse(value.ToString(), out val);
            if (!isNumber) return false;
            return (val <= MaxValue);
        }

        public int MaxValue { get; set; }
    }
}
