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
public HomeController(IConfiguration configuration,IWebHostEnvironment webHostEnvironment, IHttpContextAccessor hpc)
{
_hca = hpc;
_configuration = configuration;
_authService = new AuthService(_hca);
_authService.baseaddress = _configuration.GetSection("AppSettings").GetSection("BaseAddress").Value;
}

[HttpGet]
[Route("fetchdata")]
public string  fetchdata()
{
string s= HttpContext.Session.GetString("cccc");
return "Hello World";
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
public async Task<string> login([FromBody] Customer u)
{
string[] rVal = await _authService.LoginAsync(u.username, u.password);
if (rVal != null)
{
HttpContext.Session.SetString("username", u.username);
HttpContext.Session.SetString("AccessToken", rVal[0]);
HttpContext.Session.SetString("AccessTokenExpirationDate", rVal[1]);
return JsonConvert.SerializeObject(rVal);
}
else { return null; }
}


[HttpGet]
[Route("getcartitemcount")]
public Task<int> getcartitemcount()
{
string un = "";
if (HttpContext.Session.GetString("username") != null)
{
un = HttpContext.Session.GetString("username");
}
else
{
un = "test";
}
return _authService.getcartitemcount(un);
}











    } // Closing controller class
} // Closing namespace

