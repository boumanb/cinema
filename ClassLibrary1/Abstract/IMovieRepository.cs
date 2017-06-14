using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetOneMovie(int MovieID);
        Movie AddMovie(Movie Movie);
        Movie GetOneMovieByName(string MovieName);
        bool CheckIfMovieExist(string MovieTitle);
    }
}