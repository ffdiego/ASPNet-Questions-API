using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespostasController : Controller
    {
        private readonly RespostaService _respostaService;
        [HttpPost]
        public string Index(int n, int escolha, string guid)
        {
            return "aooo";
        }
    }
}
