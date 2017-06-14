using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using System.Web.Mvc;
using BioscoopB3Web.Models;

namespace BioscoopB3Web.Controllers.Tests
{
    [TestClass()]
    public class HallMovieControllerTests
    {

        [TestMethod()]
        public void DescriptionGetReturnsNoModel()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();

            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            //mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false });

            var result = target.Description(0) as ViewResult;
            result.Equals("Description");
        }

        [TestMethod()]
        public void DescriptionGetReturnsModel()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();

            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false, Hall = new Hall { HallID = 1, Capacity = 50 , HallLayoutID = 1, HallLayout = new HallLayout { HallLayoutID= 1, Rows = 10, SeatsPerRow = 10 } } });
            mock4.Setup(m => m.GetAllTickets(1)).Returns(new List<Ticket> { new Ticket { TicketID= 1, HallMovieID = 1, }, new Ticket { TicketID = 1, HallMovieID = 1, } });


            var result = target.Description(1) as ViewResult;

            result.Equals(new HallMovieViewModel { HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false } });
            result.Equals("Description");
        }

        [TestMethod()]
        public void DescriptionPostTickets0()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();

            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            mock3.Setup(m => m.GetOneHallLayout(1)).Returns(new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 });
            mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false, Hall = new Hall { HallID = 1, Capacity = 50, HallLayoutID = 1 } });
           
            mock4.Setup(m => m.GetAllTickets(1)).Returns(new List<Ticket> { new Ticket { TicketID = 1, HallMovieID = 1, }, new Ticket { TicketID = 1, HallMovieID = 1, } });


            HallMovieViewModel model = new HallMovieViewModel() { HallMovieID = 1, HallMovie = new HallMovie { HallID = 1 }, MovieID = 1, hallLayout = new HallLayout { }, order = new Order { } };

            var result = target.Description(model) as ViewResult;

            result.Equals(new HallMovieViewModel { MovieID = 1 , hallLayout = new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 }, HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false } });
            result.Equals("Description");
        }

        [TestMethod()]
        public void DescriptionPostTickets2()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();

            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            mock3.Setup(m => m.GetOneHallLayout(1)).Returns(new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 });
            mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false, Hall = new Hall { HallID = 1, Capacity = 50, HallLayoutID = 1 } });

            mock4.Setup(m => m.GetAllTickets(1)).Returns(new List<Ticket> { });


            HallMovieViewModel model = new HallMovieViewModel() { HallMovieID = 1, HallMovie = new HallMovie { HallID = 1 }, MovieID = 1, hallLayout = new HallLayout { }, order = new Order { } };

            var result = target.Description(model) as ViewResult;

            result.Equals(new HallMovieViewModel { MovieID = 1, hallLayout = new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 }, HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false } });
            result.Equals("Selection");
        }

        [TestMethod()]
        public void SelectionIncorrectAmountSelected()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();

            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            HallMovieViewModel model = new HallMovieViewModel() { order = new Order { TotalTickets = 2 } };
            target.TempData["hallMovieViewModel"] = model;
          

            var result = target.Selection(new int[] {1},new int[] {1, 2, 3}) as ViewResult;

            result.Equals(new HallMovieViewModel { MovieID = 1, hallLayout = new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 }, HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false } });
            result.Equals("Selection");
        }

        [TestMethod()]
        public void SelectionIncorrectAmountSelectedSeats0()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();

            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            HallMovieViewModel model = new HallMovieViewModel() { order = new Order { TotalTickets = 2 } };
            target.TempData["hallMovieViewModel"] = model;


            var result = target.Selection(null, null) as ViewResult;

            result.Equals(new HallMovieViewModel { MovieID = 1, hallLayout = new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 }, HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false } });
            result.Equals("Selection");
        }

        [TestMethod()]
        public void SelectionCorrectAmountSelected2Normal()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();


            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            HallMovieViewModel model = new HallMovieViewModel() { MovieID = 2, TempTickets = new List<Ticket> { }, order = new Order {NormalTickets = 2, TotalTickets = 2 } };
            target.TempData["hallMovieViewModel"] = model;

            var result = target.Selection(new int[] {20}, new int[] {2}) as ViewResult;

            mock3.Setup(m => m.GetOneHallLayout(1)).Returns(new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 });
            mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false, Hall = new Hall { HallID = 1, Capacity = 50, HallLayoutID = 1 } });
            mock2.Setup(m => m.GetOneMovie(1)).Returns(new Movie { MovieID = 1 });

            HallMovieViewModel model2 = new HallMovieViewModel() { MovieID = 1, hallLayout = new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 }, HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = false } };          
            
            result.Equals("Overview");
        }

        [TestMethod()]
        public void SelectionCorrectAmountSelected2LadiesNight()
        {
            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
            Mock<IHallLayoutRepository> mock3 = new Mock<IHallLayoutRepository>();
            Mock<ITicketRepository> mock4 = new Mock<ITicketRepository>();


            HallMovieController target = new HallMovieController(mock1.Object, mock2.Object, mock3.Object, mock4.Object);

            HallMovieViewModel model = new HallMovieViewModel() { MovieID = 2, TempTickets = new List<Ticket> { }, order = new Order { NormalTickets = 2, TotalTickets = 2 } };
            target.TempData["hallMovieViewModel"] = model;

            var result = target.Selection(new int[] { 20 }, new int[] { 2 }) as ViewResult;

            mock3.Setup(m => m.GetOneHallLayout(1)).Returns(new HallLayout { HallLayoutID = 1, Rows = 10, SeatsPerRow = 10 });
            mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, LadiesNight = true, Hall = new Hall { HallID = 1, Capacity = 50, HallLayoutID = 1 } });
            mock2.Setup(m => m.GetOneMovie(1)).Returns(new Movie { MovieID = 1 });

            HallMovieViewModel model2 = new HallMovieViewModel {  MovieID = 2, order = new Order{ NormalTickets = 2, TotalTickets = 2 } } ;

            result.Equals("Overview");
        }

    }
}