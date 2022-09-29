using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerguntasController : Controller
    {
        private readonly PerguntaService _perguntaService;
        public PerguntasController(PerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }
        public Pergunta Index(int? materia, int? nivel)
        {
            //todo: e se eu quisesser retornar 400 Bad Request se materia ou nivel forem nulos?
            return _perguntaService.GetQuestion(materia, nivel);
        }
        [HttpGet("random")]
        public List<Pergunta> Random([FromQuery] int count, [FromQuery] int materia, [FromQuery] int nivel)
        {
            return _perguntaService.GetRandomQuestions(count, materia, nivel);
        }
        [HttpGet("schema")]
        public string Schema()
        {
            return _perguntaService.GetSchema();
        }

    }
}
