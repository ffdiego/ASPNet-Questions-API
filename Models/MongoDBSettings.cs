namespace WebApplication1.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionPerguntas { get; set; } = null!;
        public string CollectionRespostas { get; set; } = null!;
    }
}
