using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.ModelFramework;
using Caliburn.WPF.ApplicationFramework.Interrogators;

namespace POSClient.DataLayer.Models
{
    public class CaliburnLoginModel : ModelBase
    {
        public static readonly IPropertyDefinition<string> UsernameProperty =
            Property<CaliburnLoginModel, string>(x => x.Username)
                .MustNotBeBlank("Phai nhap ten nguoi dung.");

        public string Username
        {
            get { return GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static readonly IPropertyDefinition<string> PasswordProperty =
            Property<CaliburnLoginModel, string>(x => x.Password)
                .MustNotBeBlank("Phai nhap mat khau.");

        public string Password
        {
            get { return GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
    }
}
