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
        public int _minInterestRate;
        public int _maxInterestRate;
        public double _customerAssets;
        public double _increasingAssetsPercent;
        public UnfixedInterest()
        {

           _increasingAssetsPercent = 0.3;
           if(_counter % 3 == 0)
           {
                FindInterest();
           }
        }
        public double FindInterest()
        {
            /*_minInterestRate = 0;
            _maxInterestRate = 3;
            _interestRate = rdn.Next(_minInterestRate, _maxInterestRate) + rdn.NextDouble();
            if (_interestRate < 0.5 || _interestRate > 3)
            {
                FindInterest();
            }*/
            _interestRate = rdn.NextDouble() * (3 - 0.5);
            _loanMonthlyPayment = customer._monthlyIncome * _interestRate;

            return _interestRate;
        }
        public void CustomerAssets()
        {
            double increasingMaxLoanAmount = _customerAssets * _increasingAssetsPercent;
            _maxLoanAmount += increasingMaxLoanAmount;
            if(_customerAssets > 10000)
            {
                _minForLoan = 0;
            }
        }
        public override bool CheckIfValidForLoan()
        {
            if (customer._age > _maxLoanAge)
            {
                _maxLoanDuration = 2;
                _maxLoanAmount = _customerAssets / 2;
            }
            
            return true;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("For interest is payed {0} euros.", _interestRate ); // how much is payed for interest
        }
    }
}
