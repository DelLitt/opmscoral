namespace CoralPOS.Models
{
    public class CaliburnLoginModel
    {
        /*public static readonly IPropertyDefinition<string> UsernameProperty =
            Property<CaliburnLoginModel, string>(x => x.Username);
                //.MustNotBeBlank("Phai nhap ten nguoi dung.");

        public string Username
        {
            get { return GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static readonly IPropertyDefinition<string> PasswordProperty =
            Property<CaliburnLoginModel, string>(x => x.Password);
                //.("Phai nhap mat khau.");

        public string Password
        {
            get { return GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }*/

        public string Username
        {
            get;set;
        }

        public string Password { get; set; }
    }
}