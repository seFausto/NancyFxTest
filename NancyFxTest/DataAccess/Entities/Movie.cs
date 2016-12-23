using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest.DataAccess.Entities
{
    public class Movie : MongoEntity
    {

        public string Name { get; set; }

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime ReleaseDate { get; set; }

        public bool Watched { get; set; }
    }
}
