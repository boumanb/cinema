using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BioscoopB3Web.Tests.Payment
{
    [TestClass]
    public class IDealTest
    {
        [TestMethod]
        public void IDealCorrect()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "NL20RABO0142505234",
                Card = "1234"
            };
            Assert.IsTrue(ValidateModel(test).Count == 0);
        }

        [TestMethod]
        public void IBANRequired()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "",
                Card = "1234"
            };
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void IBANWrong()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "1234",
                Card = "1234"
            };
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void IBANWrong2()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "NL20RAB142505234",
                Card = "1234"
            };
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void CardRequired()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "NL20RABO0142505234",
                Card = ""
            };
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void CardWrong()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "NL20RABO0142505234",
                Card = "123"
            };
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        [TestMethod]
        public void CardWrong2()
        {
            var test = new IDealPaymentViewModel()
            {
                IBAN = "NL20RABO0142505234",
                Card = "abcd"
            };
            Assert.IsTrue(ValidateModel(test).Count > 0);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        [TestMethod]
        public void CardNumberTest()
        {

        }
    }
}
