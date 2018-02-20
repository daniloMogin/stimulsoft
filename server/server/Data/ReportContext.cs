using Microsoft.Extensions.Options;
using MongoDB.Driver;
using server.Model;

namespace server.Data
{
    public class ReportContext
    {
        private readonly IMongoDatabase _database = null;

        public ReportContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Reports> Reports
        {
            get
            {
                return _database.GetCollection<Reports>("Reports");
            }
        }
    }
}
