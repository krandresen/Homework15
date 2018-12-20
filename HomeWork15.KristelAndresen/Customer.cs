using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15.KristelAndresen
{
    class Customer
    {
        public int _age { get; set; }
        public double _monthlyIncome { get; set; }
        public double _monthlyObligations { get; set; }
        public int _assets { get; set; }
        protected string _customerNumber;
        protected string _name;

        public Customer(string customerName)
        {
            SetCustomerName(customerName);
            _customerNumber = CreateCustomerCode();
        }
        public string CreateCustomerCode()
        {
            string nameInUpper = _name.ToUpperInvariant();
            string[] customerNames = nameInUpper.Split(' ');
            char firstNameFirstLetter = customerNames[0][0];
            string lastName = customerNames[customerNames.Length - 1];

            string customerCode = LetterToNumber(firstNameFirstLetter).ToString();

            foreach (char toNumber in lastName)
            {
                if (toNumber != ' ')
                {
                    customerCode += LetterToNumber(toNumber);
                }
            }
            return customerCode;
        }
        public int LetterToNumber(char characters)
        {
            int number = 0;
            try
            {
                number = (int)characters - 64;
            }
            catch(Exception e)
            {
                Console.WriteLine("Invali character");
            }
            return number;
        }
        public void SetCustomerName(string nameToSet)
        {
            if(nameToSet.Length > 5 && nameToSet.Contains(" "))
            {
                _name = nameToSet;
            }
            else
            {
                Console.WriteLine("Invalid value");
                _name = "Jhon Doe";
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine("Customer name is {0} and code {1}.", _name, _customerNumber);
        }
    }
}
