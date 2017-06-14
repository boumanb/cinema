using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Abstract;
using Moq;
using System.Web.Mvc;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Controllers.Tests
{
    [TestClass()]
    public class NewsmailControllerTests
    {
        [TestMethod()]
        public void SubscribeTest()
        {
            Mock<IAccountRepository> mock1 = new Mock<IAccountRepository>();

            NewsmailController target = new NewsmailController(mock1.Object);

            var result = target.Subscribe() as ViewResult;

            result.Equals("Subscribe");
        }

        //[TestMethod()]
        //public void SubscribeTestPostStateNotValid()
        //{
        //    Mock<IAccountRepository> mock1 = new Mock<IAccountRepository>();

        //    NewsmailController target = new NewsmailController(mock1.Object);

        //    Account customer = new Account() { Email = "test@test.com", WantsNewsletter = true };

        //    var result = target.Subscribe(customer) as ViewResult;

        //    result.Equals("Subscribe");
        //}

        //[TestMethod()]
        //public void SubscribeTestPostStateValidEmailUsed()
        //{
        //    Mock<IAccountRepository> mock1 = new Mock<IAccountRepository>();

        //    NewsmailController target = new NewsmailController(mock1.Object);

        //    Account customer = new Account() { Email = "test@test.com", WantsNewsletter = true , Name = "test"};

        //    mock1.Setup(m => m.AddCustomer(new Account { Email = "test@test.com", WantsNewsletter = true, Name = "test" })).Returns(false);

        //    var result = target.Subscribe(customer) as ViewResult;

        //    result.Equals("AlreadyRegistered");
        //}

        //[TestMethod()]
        //public void SubscribeTestPostStateValidEmailNotUsed()
        //{
        //    Mock<IAccountRepository> mock1 = new Mock<IAccountRepository>();

        //    NewsmailController target = new NewsmailController(mock1.Object);

        //    Account customer = new Account() { Email = "test@test.com", WantsNewsletter = true, Name = "test" };

        //    mock1.Setup(m => m.AddCustomer(new Account { Email = "test@test.com", WantsNewsletter = true, Name = "test" })).Returns(true);

        //    var result = target.Subscribe(customer) as ViewResult;

        //    result.Equals("Thanks");
        //}
    }
}