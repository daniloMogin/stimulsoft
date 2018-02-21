using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using server.Interfaces;
using server.Model;
using System;
using System.Threading.Tasks;

namespace server.Data
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportContext _context = null;

        public ReportRepository(IOptions<Settings> settings)
        {
            _context = new ReportContext(settings);
        }

        public Task SaveReport(Reports data)
        {
            try
            {
                var jsonDoc = JsonConvert.SerializeObject(data.Data);
                data.DataBson = BsonSerializer.Deserialize<BsonDocument>(jsonDoc);
                
                return _context.Reports.InsertOneAsync(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void UpdateReport(Reports data)
        {
            try
            {
                var jsonDoc = JsonConvert.SerializeObject(data.Data);
                data.DataBson = BsonSerializer.Deserialize<BsonDocument>(jsonDoc);

                //var filter = Builders<TempAgenda>.Filter.Where(x => x.AgendaId == agendaId && x.Items.Any(i => i.Id == itemId));
                //var update = Builders<TempAgenda>.Update.Set(x => x.Items[-1].Title, title);
                //var result = _collection.UpdateOneAsync(filter, update).Result;


                var filter = Builders<Reports>.Filter.Where(x => x.Name == data.Name);
                var update = Builders<Reports>.Update.Set(x => x.Name, data.Name);
                var result =  _context.Reports.UpdateOneAsync(filter, update).Result;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Reports> GetReportByName(string name)
        {
            var filter = Builders<Reports>.Filter.Eq("Name", name);
            try
            {
                return await _context.Reports.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
