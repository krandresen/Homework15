using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15.KristelAndresen
{
    class UnfixedInterest : Standard
    {
        Random rdn = new Random();
        public double _interestRate;
        public double _increasingAssetsPercent;
        public UnfixedInterest()
        {
            _increasingAssetsPercent = 0.3;
            _loanName = "Interest";
            _interestRate = rdn.NextDouble() * (3 - 0.5);

        }
        public override void LoanSteps()
        {
            base.LoanSteps();
            if (customerList.Count % 3 == 0)
            {
                FindInterest();
            }
        }
        public double FindInterest()
        {
            _interestRate = rdn.NextDouble() * (3 - 0.5);
            _loanMonthlyPayment = customer._monthlyIncome * _interestRate;

            return _interestRate;
        }
        public void CustomerAssets()
        {
            double increasingMaxLoanAmount = customer._assets * _increasingAssetsPercent;
            _maxLoanAmount += increasingMaxLoanAmount;
            if(customer._assets > 10000)
            {
                _minForLoan = 0;
            }
        }
        public override bool CheckIfValidForLoan()
        {
            if (customer._age > _maxLoanAge)
            {
                _maxLoanDuration = 2;
                _maxLoanAmount = customer._assets / 2;
            }
            return true;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("For interest is payed {0} euros.", _interestRate * _loanMonthlyPayment); // how much is payed for interest
        }
    }
}
