using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15.KristelAndresen
{
    class Insurance : Standard
    {
        public double _insurancePayment;
        public int _insurancePercent;
        public double _totalPayment;
        public Insurance()
        {
            _maxLoanAge = 75;
            _maxMonthlyLoanPercent = 45;
            _insurancePercent = 4;
            _loanName = "Insurance";
        }
        public void FindIncurancePayment()
        {
            _insurancePayment = _maxLoanAmount * _insurancePercent / 100;
            _maxLoanAmount -= _insurancePayment;
            _totalPayment = _maxLoanAmount + _insurancePayment;
        }
        public override void LoanSteps()
        {
            base.LoanSteps();
            FindIncurancePayment();
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Insurance is : {0} and total payment {1} ", _insurancePayment, _totalPayment);
        }
    }
}
