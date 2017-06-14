using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Domain.Abstract;
using Moq;
using BioscoopB3Web.Controllers;
using BioscoopB3Web.Domain.Entities;
using System.Web.Mvc;

namespace BioscoopB3Web.Tests.Controllers
{
    [TestClass]
    public class AddMovieTest
    {
        [TestMethod]
        public void AddMovieSuccess()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();
            Mock<IHallRepository> mock3 = new Mock<IHallRepository>();
            Mock<IAccountRepository> mock4 = new Mock<IAccountRepository>();

            BackOfficeAccountController target = new BackOfficeAccountController(mock4.Object, mock1.Object, mock3.Object, mock2.Object);

            Movie Movie = new Movie()
            {
                MovieID = 1,
                Title = "Deadpool",
                Description = "Deadpool is een Amerikaanse komische superheldenfilm uit 2016, gebaseerd op het Marvel Comics-personage Deadpool. Het is de achtste film in de X-Men filmserie. De hoofdrollen worden vertolkt door Ryan Reynolds, Morena Baccarin, Ed Skrein, T.J. Miller en Gina Carano. De film ging op 8 februari 2016 in première",
                Length = 118,
                Language = "Nederlands",
                Subtitles = true,
                Genre = "Action, Comedy",
                Age = "12",
                ThreeD = false,
                RunTime = new DateTime(2017, 8, 20),
                Director = "Steven Spielberg",
                Actor = "Jason Stattham, Sean Vissers",
                Imdb = "http://www.imdb.com/title/tt1431045/",
                Trailer = "https://www.youtube.com/watch?v=I4tFNfROlqk&t=74s",
                Site = "http://www.foxmovies.com/movies/deadpool",
                ImgUrl = "http://t1.gstatic.com/images?q=tbn:ANd9GcR-fLY3Z9Vn28UB-A3X_w0vjmkHcXG89HWwul5w6-sg3IonPXA_"
            };

            var result = target.AddMovie(Movie) as ViewResult;
            result.ViewName.Equals("Deadpool - BioscoopB3");

        }

        [TestMethod]
        public void AddMovieFailed()
        {
            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();
            Mock<IHallRepository> mock3 = new Mock<IHallRepository>();
            Mock<IAccountRepository> mock4 = new Mock<IAccountRepository>();

            BackOfficeAccountController target = new BackOfficeAccountController(mock4.Object, mock1.Object, mock3.Object, mock2.Object);

            Movie Movie = new Movie()
            {
                MovieID = 1,
                Title = "Deadpool",
                Description = "Deadpool is een Amerikaanse komische superheldenfilm uit 2016, gebaseerd op het Marvel Comics-personage Deadpool. Het is de achtste film in de X-Men filmserie. De hoofdrollen worden vertolkt door Ryan Reynolds, Morena Baccarin, Ed Skrein, T.J. Miller en Gina Carano. De film ging op 8 februari 2016 in première",
                Length = 118,
                Age = "12",
                ThreeD = false,
                RunTime = new DateTime(2017, 8, 20),
                Director = "Steven Spielberg",
                Actor = "Jason Stattham, Sean Vissers",
                Imdb = "http://www.imdb.com/title/tt1431045/",
                Trailer = "https://www.youtube.com/watch?v=I4tFNfROlqk&t=74s",
                Site = "http://www.foxmovies.com/movies/deadpool",
                ImgUrl = "http://t1.gstatic.com/images?q=tbn:ANd9GcR-fLY3Z9Vn28UB-A3X_w0vjmkHcXG89HWwul5w6-sg3IonPXA_"
            };

            var result = target.AddMovie(Movie) as ViewResult;
            result.ViewName.Equals("Film toevoegen - BioscoopB3");

        }
    }
}
