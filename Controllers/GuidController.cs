using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuidController : Controller
    {
        public string Index()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
