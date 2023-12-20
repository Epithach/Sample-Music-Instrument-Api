using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sample_Music_Instrument.Models
{
    public class InstrumentType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
