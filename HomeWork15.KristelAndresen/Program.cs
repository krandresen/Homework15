using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15.KristelAndresen
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer aAabel = new Customer("Anti Aabel");
            aAabel._age = 60;
            aAabel._monthlyIncome = 2000;

            Customer mMaasikas = new Customer("Mari Maarikas");
            mMaasikas._age = 25;
            mMaasikas._monthlyIncome = 4000;
            mMaasikas._monthlyObligations = 1000;

            Standard standardLoanSystem = new Standard();
            standardLoanSystem.GetLoan(aAabel);
            standardLoanSystem.GetLoan(mMaasikas);

            Insurance insuranceLoanSystem = new Insurance();
            insuranceLoanSystem.GetLoan(aAabel);
            insuranceLoanSystem.GetLoan(mMaasikas);

            UnfixedInterest unfixedInterestLoanSystem = new UnfixedInterest();
            unfixedInterestLoanSystem.GetLoan(mMaasikas);
            Console.ReadLine();
        }
    }
}
