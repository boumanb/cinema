using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BioscoopB3Web.Controllers.Tests
{
    [TestClass()]
    public class ContactControllerTests
    {
        [TestMethod()]
        public void ContactTest()
        {
            ContactController target = new ContactController();

            var result = target.Contact() as ViewResult;
            result.Equals("Contact");
        }
    }
}