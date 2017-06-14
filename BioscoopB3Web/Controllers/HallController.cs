using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioscoopB3Web.Controllers
{
    public class HallController : Controller
    {

        IMovieRepository MovieRepo;
        IHallMovieRepository HallMovieRepo;

        public HallController(IMovieRepository MovieRepo, IHallMovieRepository HallMovieRepo)
        {
            this.MovieRepo = MovieRepo;
            this.HallMovieRepo = HallMovieRepo;
        }

        public ActionResult MovieListHall(int id)
        {
            ViewBag.MovieList = "Films in zaal " + id;
            return View("MovieList", HallMovieRepo.GetAllHallMovies().Where(hm => hm.HallID == id && hm.DateTime > DateTime.Now).OrderBy(d => d.DateTime).ToList());
        }

        public ActionResult List()
        {
            ViewBag.List = "Zalen";

            IEnumerable<HallMovie> hallmovies = HallMovieRepo.GetAllHallMovies();
            IEnumerable<int> halls = hallmovies.Select(h => h.HallID).Distinct().OrderBy(x => x);
            return View("Halls", halls);
        }
    }
}