using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BioscoopB3Web.Domain.Concrete;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Controllers
{
    public class SearchController : Controller
    {
        //create DBcontext object
        BioscoopModel db = new BioscoopModel();

        // GET: Search
        public ActionResult Search()
        {
            //get all movies
            List<Movie> MovieList = db.Movies.ToList();
            //pass to view
            return View(MovieList);
        }

        public ActionResult SearchMovie(string search)
        {
            return View("Search", db.Movies.Where(m => m.Title.Contains(search) || search == null).ToList());
        }

        public ActionResult ShowMovie(Movie movie)
        {
            return View("Movie", movie);
        }
    }
}