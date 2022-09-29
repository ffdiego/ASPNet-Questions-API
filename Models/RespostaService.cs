using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApplication1.Models
{
    public class RespostaService
    {
        private readonly IMongoCollection<Pergunta> _respostaCollection;
        public RespostaService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            try
            {
                MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
                IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
                _respostaCollection = database.GetCollection<Pergunta>(mongoDBSettings.Value.CollectionRespostas);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Conectar ao Banco");
            }
        }
    }
}
