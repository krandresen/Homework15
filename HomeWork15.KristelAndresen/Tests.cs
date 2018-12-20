using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace HomeWork15.KristelAndresen
{
    [TestFixture]
    class Tests
    {
        private Customer firstCustomer;
        private Customer secondCustomer;
        private Customer thirdCustomer;
        private Customer fourthCustomer;

        private Standard standardLoan;
        private Insurance insuranceLoan;
        //private UnfixedInterest unfixedInterestLoan; 

        [SetUp]
        public void SetUp()
        {
            firstCustomer = new Customer("Ab Bcde");
            firstCustomer._age = 40;
            firstCustomer._monthlyIncome = 1000;

            secondCustomer = new Customer("Juss Juurik");
            secondCustomer._age = 70;
            secondCustomer._monthlyIncome = 5000;
            secondCustomer._monthlyObligations = 2000;
            secondCustomer._assets = 10000;
            
            thirdCustomer = new Customer("Ats Aavik");
            thirdCustomer._age = 50;
            thirdCustomer._monthlyIncome = 11000;
            thirdCustomer._monthlyObligations = 3000;
            thirdCustomer._assets = 9000;
            
            fourthCustomer = new Customer("Aime Tamm");
            fourthCustomer._age = 90;
            fourthCustomer._monthlyIncome = 600;
            fourthCustomer._monthlyObligations = 200;
            fourthCustomer._assets = 5000;
            
            standardLoan = new Standard();
            insuranceLoan = new Insurance();
           // unfixedInterestLoan = new UnfixedInterest();
        }

        [Test]
        public void Customer_GetLetterAsNumber_A_1()
        {
            int expected = 1;
            int actual = firstCustomer.LetterToNumber('A');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Customer_GetLetterAsNumber_M_13()
        {
            int expected = 13;
            int actual = secondCustomer.LetterToNumber('M');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Customer_GenerateCode_ABcde_12345()
        {
            string expected = "12345";
            Assert.AreEqual(firstCustomer.CreateCustomerCode(), expected);
        }

        [Test]
        public void StandardLoan_Duration_firstCustomer1_25()
        {
            int expected = 25;
            standardLoan.GetLoan(firstCustomer);
            int actual = standardLoan.FindLoanDuration();
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void InsuranceLoan_Duration_thirdCustomer_25()
        {
            int expected = 25;
            insuranceLoan.GetLoan(thirdCustomer);
            int actual = insuranceLoan.FindLoanDuration();
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StandardLoan_IsValid_firstCustomer1_true()
        {
            bool expected = true;
            standardLoan.GetLoan(firstCustomer);
            Assert.AreEqual(expected, standardLoan.CheckIfValidForLoan());
        }

        [Test]
        public void StandardLoan_IsValid_secondCustomer_false()
        {
            bool expected = false;
            standardLoan.GetLoan(secondCustomer);
            Assert.AreEqual(expected, standardLoan.CheckIfValidForLoan());
        }
        [Test]
        public void InsuranceLoan_IsValid_fourthCustomer_false()
        {
            bool expected = false;
            insuranceLoan.GetLoan(fourthCustomer);
            Assert.AreEqual(expected, insuranceLoan.CheckIfValidForLoan());
        }
        [Test]
        public void InsuranceLoan_IsValid_secondCustomer_true()
        {
            bool expected = true;
            insuranceLoan.GetLoan(secondCustomer);
            Assert.AreEqual(expected, insuranceLoan.CheckIfValidForLoan());
        }
       /* [Test]
        public void UnfixedInterestLoan_isValid_secondCustomer_true()
        {
            bool expected = true;
            unfixedInterestLoan.GetLoan(secondCustomer);
            Assert.AreEqual(expected, unfixedInterestLoan.CheckIfValidForLoan());
        }*/
    }
}
