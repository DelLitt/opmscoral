using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AppFrame.WPF.ValidationAttributes
{
    public class LengthAttribute : ValidationAttribute
    {
        public LengthAttribute(int MinLength,int MaxLength)
            : base()
        {
            this.MaxLength = MaxLength;
            this.MinLength = MinLength;
        }

        public LengthAttribute(int MaxLength)
            : base()
        {
            this.MaxLength = MaxLength;
            
        }
    
        public override bool IsValid(object value)
        {
            string val = value as string;
            if(string.IsNullOrEmpty(val)) return false;

            return val.Length <= MaxLength && val.Length >= MinLength;
        }
        
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
    }
}
