using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15.KristelAndresen
{
    class Standard : ILoan
    {
        internal Customer customer;
        internal int _maxLoanAge;
        internal int _maxLoanDuration;
        internal int _maxMonthlyLoanPercent;
        protected string _loanName;
        protected double _minForLoan;
        public int _loanDuration;
        public double _loanMonthlyPayment;
        public double _maxLoanAmount;
        public int _counter = 0;
        public List<Customer> customerList = new List<Customer>();

        public Standard()
        {
            _maxLoanAge = 65;
            _maxLoanDuration = 30;
            _maxMonthlyLoanPercent = 27;
            _loanName = "Standard";
            _minForLoan = 300;
        }
        public void GetLoan(Customer customer)
        {
            this.customer = customer;
            customer.PrintCustomerData();
            if(CheckIfValidForLoan())
            {

                customerList.Add(customer);
                LoanSteps();
                PrintInfo();
            }
        }
        public virtual void LoanSteps()
        {
            FindLoanDuration();
            CalculateMaximumMonthlyPayment();
            CalculateMaximumMonthlyLoan();
        }
        public virtual bool CheckIfValidForLoan()
        {
            if(customer._age > _maxLoanAge)
            {
                Console.WriteLine("Too old for a loan!");
                return false;
            }
            if(customer._monthlyIncome - customer._monthlyObligations <= _minForLoan)
            {
                Console.WriteLine("Income too small for a loan!");
                return false;
            }
            return true;
        }
        public int FindLoanDuration()
        {
            _loanDuration = _maxLoanAge - customer._age;
            if(_loanDuration > _maxLoanDuration)
            {
                _loanDuration = _maxLoanDuration;
                return _loanDuration;
            }
            return _loanDuration;
        }
        public double CalculateMaximumMonthlyPayment()
        {
            _loanMonthlyPayment = (customer._monthlyIncome - customer._monthlyObligations) * _maxMonthlyLoanPercent / 100;
            return _loanMonthlyPayment;
        }
        public double CalculateMaximumMonthlyLoan()
        {
            _maxLoanAmount = _maxLoanDuration * _loanMonthlyPayment;
            return _maxLoanAmount;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine("Finding rates for loan : " + _loanName);
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("Your maximum loan duration is : " + _loanDuration);
            Console.WriteLine("Your maximum monthly payment is : " + _loanMonthlyPayment);
            Console.WriteLine("Your maximum loan amount is : " + _maxLoanAmount);
        }
    }
}
