using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Abstract
{
    public interface IHallMovieRepository
    {
        IEnumerable<HallMovie> GetAllHallMovies();
        HallMovie GetOneHallMovie(int HallMovieID);
        HallMovie AddOneHallMovie (HallMovie Hallmovie);
    }
}
