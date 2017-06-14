using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BioscoopB3Web.Tests.Payment
{
    [TestClass]
    public class CreditCardTest
    {
        [TestMethod]
        public void CreditCardCorrect()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 5,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count == 0);
        }

        [TestMethod]
        public void CardNumberRequired()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "",
                ExpiryMonth = 5,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void CardNumberWrong()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "8383847362291",
                ExpiryMonth = 5,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void CardNumberWrong2()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "abcdefghijklmnop",
                ExpiryMonth = 5,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiryMonthRequired()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 0,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiryMonthWrong()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 13,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiryMonthWrong2()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 111,
                ExpiryYear = 3000,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiryYearRequired()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 0,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiryYearWrong()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 1,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiryYearWrong2()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 999999,
                SecurityNumber = "777"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void SecurityNumberRequired()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 3000,
                SecurityNumber = ""
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void SecurityNumberWrong()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 3000,
                SecurityNumber = "1"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void SecurityNumberWrong2()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 3000,
                SecurityNumber = "abc"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void ExpiredTest()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 2000,
                SecurityNumber = "123"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.AreEqual(test.Expired, true);
        }

        [TestMethod]
        public void ExpiredTest2()
        {
            var test = new CardPaymentViewModel()
            {
                CardNumber = "4921816602935113",
                ExpiryMonth = 1,
                ExpiryYear = 3000,
                SecurityNumber = "123"
            };
            test.checkExpired(test.ExpiryMonth, test.ExpiryYear);
            Assert.AreEqual(test.Expired, false);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
