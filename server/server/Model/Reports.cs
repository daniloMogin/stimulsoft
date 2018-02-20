using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Model
{
    public class Reports
    {
        [Key]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }

        // For the Reports object type:
        [BsonIgnore] //ignore this value in MongoDB
        public Dictionary<string, object> Data { get; set; }

        [JsonIgnore] //ignore this value in the response on Get requests
        [BsonElement(elementName: "Reports")]
        public BsonDocument DataBson { get; set; }
    }
}
