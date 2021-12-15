using HR_Tech.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public class MongoDBCandidatesRepository : ICandidatesRepository
    {
        private const string databaseName = "database";

        private const string collectionName = "candidates";

        private readonly IMongoCollection<Candidate> candidatesCollection;

        private readonly FilterDefinitionBuilder<Candidate> filterBuilder = Builders<Candidate>.Filter;

        public MongoDBCandidatesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            candidatesCollection = db.GetCollection<Candidate>(collectionName);
        }

        public void CreateCandidate(Candidate candidate)
        {
            candidatesCollection.InsertOne(candidate);
        }

        public void DeleteCandidate(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id, id);
            candidatesCollection.DeleteOne(filter);
        }

        public Candidate GetCandidate(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id, id);
            return candidatesCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return candidatesCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateCandidate(Candidate candidate)
        {
            var filter = filterBuilder.Eq(existingCandidate => existingCandidate.Id, candidate.Id);
            candidatesCollection.ReplaceOne(filter, candidate);
        }
    }
}
