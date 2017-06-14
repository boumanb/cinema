using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class AddHallMovieModel
    {
        public IEnumerable<Hall> AllHalls { get; set; }
        public IEnumerable<Movie> AllMovies { get; set; }
        public IEnumerable<HallMovie> AllHallMovies { get; set; }
        public bool LadiesNight { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime { get; set; }
    }
}