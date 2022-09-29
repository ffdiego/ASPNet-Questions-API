using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Resposta
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("GUID")]
        public string Guid { get; set; }
        [BsonElement("N")]
        public int N { get; set; }
        [BsonElement("Pergunta")]
        public Pergunta Pergunta { get; set; }
        [BsonElement("Escolha")]
        public int Escolha { get; set; }
        [BsonElement("Valor")]
        public double Valor { get; set; }
    }
}
