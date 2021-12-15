using HR_Tech.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public class MongoDBJobOpeningsRepository : IJobOpeningsRepository
    {
        private const string databaseName = "database";

        private const string collectionName = "jobOpenings";

        private readonly IMongoCollection<JobOpening> jobOpeningsCollection;

        private readonly FilterDefinitionBuilder<JobOpening> filterBuilder = Builders<JobOpening>.Filter;

        public MongoDBJobOpeningsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            jobOpeningsCollection = db.GetCollection<JobOpening>(collectionName);
        }

        public void CreateJobOpening(JobOpening jobOpening)
        {
            jobOpeningsCollection.InsertOne(jobOpening);
        }

        public void DeleteJobOpening(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id, id);
            jobOpeningsCollection.DeleteOne(filter);
        }

        public JobOpening GetJobOpening(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id, id);
            return jobOpeningsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<JobOpening> GetJobOpenings()
        {
            return jobOpeningsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateJobOpening(JobOpening jobOpening)
        {
            var filter = filterBuilder.Eq(existingJobOpening => existingJobOpening.Id, jobOpening.Id);
            jobOpeningsCollection.ReplaceOne(filter, jobOpening);
        }
    }
}
