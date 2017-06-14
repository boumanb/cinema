using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Entities.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void getTotalTicketsTest()
        {
            Order order = new Order() { StudentTickets = 2, ElderlyTickets = 3, ChildTickets = 1, NormalTickets = 4 };
            int result = order.getTotalTickets();
            Assert.AreEqual(10, result);
        }
    }
}