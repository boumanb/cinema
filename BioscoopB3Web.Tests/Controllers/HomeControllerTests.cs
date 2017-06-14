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
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            HomeController target = new HomeController();

            var result = target.Index() as ViewResult;

            result.ViewName.Equals("Index");
        }
    }
}