//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using BioscoopB3Web.Domain.Entities;

//namespace TouchUI.Tests
//{
//    [TestClass]
//    public class OrderTests
//    {

//        [TestMethod]
//        public void TestCalcTotalPrice()
//        {
//            //Arrange
//            Order order = new Order { StudentTickets = 2, ChildTickets = 1, ElderlyTickets = 3, StandardPrice = 9.00m, NoDiscountTickets = 4, HallMovie = new HallMovie { DateTime = new DateTime(2017, 05, 09) }, Movie = new Movie { Length = 121, ThreeD = true } };
//            decimal expected = 82.50m;
//            //Act
//            var value = order.calcTotalPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestCalcStudentPrice()
//        {
//            //Arrange
//            Order order = new Order { StudentTickets = 2, ChildTickets = 1, ElderlyTickets = 3, StandardPrice = 9.00m, NoDiscountTickets = 4, HallMovie = new HallMovie { DateTime = new DateTime(2017, 05, 09) }, Movie = new Movie { Length = 121, ThreeD = true } };
//            decimal expected = 15.00m;
//            //Act
//            var value = order.calcStudentPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestCalcChildPrice()
//        {
//            //Arrange
//            Order order = new Order { StudentTickets = 2, ChildTickets = 1, ElderlyTickets = 3, StandardPrice = 9.00m, NoDiscountTickets = 4, HallMovie = new HallMovie { DateTime = new DateTime(2017, 05, 09) }, Movie = new Movie { Length = 121, ThreeD = true } };
//            decimal expected = 9.00m;
//            //Act
//            var value = order.calcChildPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestCalcElderlyPrice()
//        {
//            //Arrange
//            Order order = new Order { StudentTickets = 2, ChildTickets = 1, ElderlyTickets = 3, StandardPrice = 9.00m, NoDiscountTickets = 4, HallMovie = new HallMovie { DateTime = new DateTime(2017, 05, 09) }, Movie = new Movie { Length = 121, ThreeD = true } };
//            decimal expected = 22.50m;
//            //Act
//            var value = order.calcElderyPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestCalcNoDiscountPrice()
//        {
//            //Arrange
//            Order order = new Order { StudentTickets = 2, ChildTickets = 1, ElderlyTickets = 3, StandardPrice = 9.00m, NoDiscountTickets = 4, HallMovie = new HallMovie { DateTime = new DateTime(2017, 05, 09) }, Movie = new Movie { Length = 121, ThreeD = true } };
//            decimal expected = 36.00m;
//            //Act
//            var value = order.calcNoDiscountPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestTotalTickets()
//        {
//            //Arrange
//            Order order = new Order { StudentTickets = 2, ChildTickets = 3, ElderlyTickets = 4, NoDiscountTickets = 1 };
//            var expected = 10;
//            //Act
//            var value = order.totalTickets();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }
//    }
//}
