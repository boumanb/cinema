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
using BioscoopB3Web.Models;

namespace BioscoopB3Web.Controllers.Tests
{
    [TestClass()]
    public class MovieControllerTests
    {

        [TestMethod()]
        public void ListTest()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

            MovieController target = new MovieController(mock1.Object, mock2.Object);

            var result = target.List() as ViewResult;

            result.ViewName.Equals("~/Views/MovieList/MovieList.cshtml");
        }

        [TestMethod()]
        public void HallListTest()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

            MovieController target = new MovieController(mock1.Object, mock2.Object);

            mock2.Setup(m => m.GetAllHallMovies()).Returns(new List<HallMovie>{ });

            var result = target.List() as ViewResult;

            result.ViewName.Equals("Halls");
        }

        [TestMethod()]
        public void Descriptionid0Test()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

            MovieController target = new MovieController(mock1.Object, mock2.Object);           

            var result = target.Description(0) as ViewResult;

            result.ViewName.Equals("Description");
        }

        [TestMethod()]
        public void DescriptionId3Test()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

            MovieController target = new MovieController(mock1.Object, mock2.Object);

            mock1.Setup(m => m.GetOneMovie(1)).Returns(new Movie { });

            var result = target.Description(0) as ViewResult;

            result.ViewName.Equals("Description");
        }

        [TestMethod()]
        public void DescriptionId23Test()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

            MovieController target = new MovieController(mock1.Object, mock2.Object);

            mock1.Setup(m => m.GetOneMovie(1)).Returns(new Movie { });

            MovieViewModel hm = new MovieViewModel() { };

            var result = target.Description(hm) as ViewResult;
           
            result.ViewName.Equals("Overview");
        }
    }
}