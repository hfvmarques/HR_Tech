using HR_Tech.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public class MongoDBTechnologiesRepository : ITechnologiesRepository
    {
        private const string databaseName = "database";

        private const string collectionName = "technologies";

        private readonly IMongoCollection<Technology> technologiesCollection;

        private readonly FilterDefinitionBuilder<Technology> filterBuilder = Builders<Technology>.Filter;

        public MongoDBTechnologiesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            technologiesCollection = db.GetCollection<Technology>(collectionName);
        }

        public void CreateTechnology(Technology technology)
        {
            technologiesCollection.InsertOne(technology);
        }

        public void DeleteTechnology(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id, id);
            technologiesCollection.DeleteOne(filter);
        }

        public IEnumerable<Technology> GetTechnologies()
        {
            return technologiesCollection.Find(new BsonDocument()).ToList();
        }

        public Technology GetTechnology(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id, id);
            return technologiesCollection.Find(filter).SingleOrDefault();
        }

        public void UpdateTechnology(Technology technology)
        {
            var filter = filterBuilder.Eq(existingTechnology => existingTechnology.Id, technology.Id);
            technologiesCollection.ReplaceOne(filter, technology);
        }
    }
}
