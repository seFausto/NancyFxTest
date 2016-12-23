using MongoDB.Driver;
using NancyFxTest.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest.DataAccess
{
    public class MongoConnectionHandler<T> where T : IMongoEntity
    {
        public MongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler()
        {
            var connectionString = "mongodb://localhost";

            var mongoClient = new MongoClient(connectionString);

            var mongoServer = mongoClient.GetServer();

            var databaseName = "moviecollection";
            var db = mongoServer.GetDatabase(databaseName);

            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");

        }

    }
}
