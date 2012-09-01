using System.ComponentModel.DataAnnotations;

namespace AppFrame.WPF.ValidationAttributes
{
    public class MinAttribute : ValidationAttribute
    {
        public MinAttribute(int MinValue) :base()
        {
            this.MinValue = MinValue;
        }

        public MinAttribute(string MinValue) : base()
        {
            this.MinValue = int.Parse(MinValue);
        }

        public override bool IsValid(object value)
        {
            int val;
            bool isNumber = int.TryParse(value.ToString(), out val);
            if(!isNumber) return false;
            return (val >= MinValue);
        }

        public int MinValue { get; set; }
    }
}
