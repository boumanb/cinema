using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Domain.Abstract;
using Moq;
using BioscoopB3Web.Controllers;
using BioscoopB3Web.Domain.Concrete;
using System.Web.Mvc;
using BioscoopB3Web.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BioscoopB3Web.Tests.Newsmail
{
    [TestClass]
    public class NewsMailTest
    {
        [TestMethod]
        public void CanSubscribe()
        {
            var test = new Account()
            {
                Email = "Test@test.nl",
                Name = "Test",
                WantsNewsletter = true
            };
            Assert.IsTrue(ValidateModel(test).Count == 0);
        }

        [TestMethod]
        public void WrongMail()
        {
            var test = new Account()
            {
                Email = "Test@test",
                Name = "Bill",
                WantsNewsletter = true
            };
            Assert.IsTrue(ValidateModel(test).Count == 1);
        }

        [TestMethod]
        public void NoName()
        {
            var test = new Account()
            {
                Email = "Test@test.nl",
                Name = "",
                WantsNewsletter = true
            };
            Assert.IsTrue(ValidateModel(test).Count == 1);
        }

        [TestMethod]
        public void NoMail()
        {
            var test = new Account()
            {
                Email = "",
                Name = "Test",
                WantsNewsletter = true
            };
            Assert.IsTrue(ValidateModel(test).Count == 1);
        }

        [TestMethod]
        public void EmptyForm()
        {
            var test = new Account()
            {
                Email = "",
                Name = "",
            };
            Assert.IsTrue(ValidateModel(test).Count == 2);
        }

        [TestMethod]
        public void NameWithNumbers()
        {
            var test = new Account()
            {
                Email = "Test@test.nl",
                Name = "Test1",
                WantsNewsletter = true
            };
            Assert.IsTrue(ValidateModel(test).Count == 1);
        }

        [TestMethod]
        public void WrongMail2()
        {
            var test = new Account()
            {
                Email = "Testtest.nl",
                Name = "Test",
                WantsNewsletter = true
            };
            Assert.IsTrue(ValidateModel(test).Count == 1);
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
