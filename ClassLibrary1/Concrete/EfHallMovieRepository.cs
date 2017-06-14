using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Concrete
{   
    public class EfHallMovieRepository : IHallMovieRepository
    {
        private BioscoopModel BioscoopModel;

        public EfHallMovieRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public HallMovie AddOneHallMovie(HallMovie Hallmovie)
        {
            IEnumerable<HallMovie> hallmovies = BioscoopModel.HallMovies.Where(hm => hm.DateTime <= Hallmovie.DateTimeEnd && hm.DateTimeEnd >= Hallmovie.DateTime && hm.HallID == Hallmovie.HallID).ToList();
            if (hallmovies.Count() != 0)
            {
                return hallmovies.FirstOrDefault();
            }
            else
            {
                BioscoopModel.HallMovies.Add(Hallmovie);
                BioscoopModel.SaveChanges();
                return Hallmovie;
            }
        }

        public IEnumerable<HallMovie> GetAllHallMovies()
        {
            return BioscoopModel.HallMovies;
        }

        public HallMovie GetOneHallMovie(int HallMovieID)
        {
            return BioscoopModel.HallMovies.Find(HallMovieID);
        }

    }
}