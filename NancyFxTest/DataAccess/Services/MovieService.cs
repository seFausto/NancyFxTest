using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NancyFxTest.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest.DataAccess.Services
{
    public class MovieService : EntityService<Movie>
    {
        public IEnumerable<Movie> GetMovies(int limit, int skip)
        {
            var result = this.MongoConnectionHandler.MongoCollection.FindAllAs<Movie>()
                .SetSortOrder(SortBy<Movie>.Descending(m => m.ReleaseDate))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<Movie>.Include(m => m.Id, m => m.Name, m => m.ReleaseDate));

            return result;

        }

        public bool AddMovie(Movie newMovie)
        {
            var e = new EntityService<Movie>();
            e.Create(newMovie);

            return true;
        }
    }
}
