using Microsoft.AspNetCore.Mvc;

namespace Ecommerces.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class myownhandlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [Route("fetchdata")]
        public string fetchdata()
        {
            return "MOCcccccccccccccccccccc";
        }
    }
}
