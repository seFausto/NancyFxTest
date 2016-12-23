using System.Collections.Generic;

namespace NancyFxTest.DataAccess
{
    public interface IMovieService
    {
        void Add(Movie newMovie);
        void DeleteAll();
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
    }
}