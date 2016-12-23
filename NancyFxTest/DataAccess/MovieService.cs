using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest.DataAccess
{
    public class MovieService : IMovieService
    {
        public void Add(Movie newMovie)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var movies = db.GetCollection<Movie>("movies");

                movies.Insert(newMovie);
            }
        }

        public Movie GetById(int id)
        {
            var result = new Movie();

            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var movies = db.GetCollection<Movie>("movies");
                result = movies.Find(x => x.Id == id).FirstOrDefault();
            }

            return result;
        }

        public IEnumerable<Movie> GetAll()
        {
            IEnumerable<Movie> result;

            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var movies = db.GetCollection<Movie>("movies");
                result = movies.FindAll();
            }

            return result;
        }

        public void DeleteAll()
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var movies = db.GetCollection<Movie>("movies");
                movies.Delete(x => x.Id > 0);
            }
        }

    }
}
