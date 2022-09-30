using Ecommerces.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ecommerces.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;

        private static IHttpContextAccessor _hca { get; set; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        //private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration,IWebHostEnvironment webHostEnvironment, IHttpContextAccessor hpc)
        {
            _hca = hpc;
            _configuration = configuration;
            _authService = new AuthService(_hca);
            _authService.baseaddress = _configuration.GetSection("AppSettings").GetSection("BaseAddress").Value;

           // _logger = logger;
        }

        [HttpGet]
        [Route("fetchdata")]
       
        public string  fetchdata()//[FromBody] Customer u)
        {
            string s= HttpContext.Session.GetString("cccc");
            //Asynchronous programming is very popular with the help of the async and await keywords in C#.*/
            //bool rVal = await _authService.RegisterUserAsync(u);
            // return rVal;

            return "hhhhhhhhhhhhhhhhhh";
        }


        [Route("register")]
        [HttpPost]

        public async Task<bool> register([FromBody] Customer c)
        {
            bool status = await _authService.RegisterUserAsync(c);
            return status;
        }

        [Route("login")]
        [HttpPost]
        public async Task<string> login
            ([FromBody] Ecommerces.Models.Customer u)
        {
            string[] rVal = await _authService.LoginAsync(u.username, u.password);
            if (rVal != null)
            {
                HttpContext.Session.SetString("username", u.username);
                HttpContext.Session.SetString("AccessToken", rVal[0]);
                HttpContext.Session.SetString("AccessTokenExpirationDate", rVal[1]);
                return JsonConvert.SerializeObject(rVal);
            }
            else
            {
                return null;
            }
        }

    }

}

