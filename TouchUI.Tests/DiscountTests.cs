//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using BioscoopB3Web.Domain.Entities;

//namespace TouchUI.Tests
//{
//    [TestClass]
//    public class DiscountTests
//    {
//        [TestMethod]
//        public void TestChildDiscount()
//        {
//            //Language set to "Nederlands" and time set to be before 16:00

//            //Arrange
//            Movie movie = new Movie { Length = 119, ThreeD = false, Language = "Nederlands" };
//            HallMovie hallmovie = new HallMovie { DateTime = new DateTime(2017, 05, 05, 14, 0, 0) };
//            Order order = new Order { ChildTickets = 1, Movie = movie, HallMovie = hallmovie, StandardPrice = 0m };
//            var expected = -1.50m;
//            //Act
//            var value = order.calcChildPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestNoChildDiscount()
//        {
//            //Language set to "Engels", so no discount

//            //Arrange
//            Movie movie = new Movie { Length = 119, ThreeD = false, Language = "Engels" };
//            HallMovie hallmovie = new HallMovie { DateTime = new DateTime(2017, 05, 05, 14, 0, 0) };
//            Order order = new Order { ChildTickets = 1, Movie = movie, HallMovie = hallmovie, StandardPrice = 0m };
//            var expected = 0m;
//            //Act
//            var value = order.calcChildPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestStudentDiscount()
//        {
//            //Date set to a Wednesday

//            //Arrange
//            Movie movie = new Movie { Length = 119, ThreeD = false, Language = "Nederlands" };
//            HallMovie hallmovie = new HallMovie { DateTime = new DateTime(2017, 2, 22, 14, 0, 0) };
//            Order order = new Order { StudentTickets = 1, Movie = movie, HallMovie = hallmovie, StandardPrice = 0m };
//            var expected = -1.50m;
//            //Act
//            var value = order.calcStudentPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestNoStudentDiscount()
//        {
//            //Date set to a Friday, so no discount

//            //Arrange
//            Movie movie = new Movie { Length = 119, ThreeD = false, Language = "Nederlands" };
//            HallMovie hallmovie = new HallMovie { DateTime = new DateTime(2017, 2, 25, 14, 0, 0) };
//            Order order = new Order { StudentTickets = 1, Movie = movie, HallMovie = hallmovie, StandardPrice = 0m };
//            var expected = 0m;
//            //Act
//            var value = order.calcStudentPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestElderlyDiscount()
//        {
//            //Date set to a Wednesday

//            //Arrange
//            Movie movie = new Movie { Length = 119, ThreeD = false, Language = "Nederlands" };
//            HallMovie hallmovie = new HallMovie { DateTime = new DateTime(2017, 2, 22, 14, 0, 0) };
//            Order order = new Order { ElderlyTickets = 1, Movie = movie, HallMovie = hallmovie, StandardPrice = 0m };
//            var expected = -1.50m;
//            //Act
//            var value = order.calcElderyPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }

//        [TestMethod]
//        public void TestNoElderlyDiscount()
//        {
//            //Date set to holiday, so no discount

//            //Arrange
//            Movie movie = new Movie { Length = 119, ThreeD = false, Language = "Nederlands" };
//            HallMovie hallmovie = new HallMovie { DateTime = new DateTime(2017, 12, 25, 14, 0, 0) };
//            Order order = new Order { ElderlyTickets = 1, Movie = movie, HallMovie = hallmovie, StandardPrice = 0m };
//            var expected = 0m;
//            //Act
//            var value = order.calcElderyPrice();
//            //Assert
//            Assert.AreEqual(expected, value);
//        }
//    }
//}
