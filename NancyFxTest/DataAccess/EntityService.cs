using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NancyFxTest.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest.DataAccess
{
    public class EntityService<T> : IEntityService<T> where T : IMongoEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler;

        public EntityService()
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>();
        }

        public void Create(T entity)
        {                     
            var result = this.MongoConnectionHandler.MongoCollection.Save(entity, new MongoInsertOptions
            {
                WriteConcern = WriteConcern.Acknowledged
            });

        }

        public void Delete(string id)
        {
            var result = this.MongoConnectionHandler.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id,
                new ObjectId(id)),
                RemoveFlags.None,
                WriteConcern.Acknowledged);
        }

        public T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
