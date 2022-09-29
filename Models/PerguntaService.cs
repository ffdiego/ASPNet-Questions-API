using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace WebApplication1.Models
{
    public class PerguntaService
    {
        private readonly IMongoCollection<Pergunta> _perguntaCollection;
        public PerguntaService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            try
            {
                MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
                IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
                _perguntaCollection = database.GetCollection<Pergunta>(mongoDBSettings.Value.CollectionPerguntas);
            } catch (Exception e)
            {
                throw new Exception("Erro ao Conectar ao Banco");
            }
        }
        public List<Pergunta> GetAll()
        {
            return _perguntaCollection.Find<Pergunta>(o => (o.N < 10)).ToList();
        }
        public Pergunta GetQuestion(int? materia, int? nivel)
        {
            return GetRandomQuestions(1, materia, nivel).First();
        }
        public List<Pergunta> GetRandomQuestions(int? count, int? materia, int? nivel)
        {
            List<BsonDocument> customAggregation = new List<BsonDocument>();

            if (materia != null) 
                customAggregation.Add(new BsonDocument("$match", new BsonDocument("Materia", materia)));
            if (nivel != null)
                customAggregation.Add(new BsonDocument("$match", new BsonDocument("Dificuldade", nivel)));
            customAggregation.Add(new BsonDocument("$sample", new BsonDocument("size", count ?? 1)));

            var pipeline = PipelineDefinition<Pergunta, Pergunta>.Create(customAggregation);
            var results = _perguntaCollection.Aggregate(pipeline);
            return results.ToList();
        }
        public string GetSchema()
        {

            var materias = Enum.GetValues(typeof(Pergunta.Materias))
               .Cast<Pergunta.Materias>()
               .Select(t => t.ToString())
               .ToList();
            var niveis = Enum.GetValues(typeof(Pergunta.Niveis))
               .Cast<Pergunta.Niveis>()
               .Select(t => t.ToString())
               .ToList();

            Schema resposta = new Schema
            {
                Materias = materias,
                Niveis = niveis,
            };
            
            return JsonSerializer.Serialize(resposta);
        }

        private class Schema
        {
            public List<string>? Materias { get; set; }
            public List<string>? Niveis { get; set; }
        }
    }
}


