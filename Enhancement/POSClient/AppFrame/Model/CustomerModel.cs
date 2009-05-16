

using System;
using AppFrame.Common;

namespace AppFrame.Model
{
    [Serializable]
    public class CustomerModel 
    {
        private int id;
        private string address;
        private string contactPerson;
        private string customerName;
        private int telephone;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        
        
        public int Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        
        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }

        
    }
}