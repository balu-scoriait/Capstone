using Ecommerces_MS.Models;
using Ecommerces_MS.Repository;
using Ecommerces_MS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Ecommerces_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static UserRegister user = new UserRegister();
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserdbContext _dbContext;
        private readonly IRepo _repo;
        

        public AuthController(IConfiguration configuration , IUserService userService, UserdbContext db , IRepo r,IPasswordHasher passwordHasher
           )
        {
            _configuration = configuration;
            _userService = userService;
            _dbContext = db;

            _passwordHasher = passwordHasher;
            _repo = r;
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Signup([FromBody] UserRegister reg)
        {
            _dbContext.BuildConnectionString(_configuration.GetConnectionString("registerConn"));
            var status = _repo.createCustomers(reg);

            if (status == "OK")
            {
                return Ok(new { message = "customer created successfully!" });
            }
            else
            {
                return StatusCode(429, status);
            }
        }
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult LoginCheck([FromBody] Loginmodel value)
        {
            _dbContext.BuildConnectionString(_configuration.GetConnectionString("registerConn"));
            var user = _dbContext.Users.SingleOrDefault(u => u.username == value.username);
            if (user == null || !_passwordHasher.VerifyIdentityV3Hash(value.password, user.password))
            { 
                return BadRequest(new { message = "Invalid - username or password" }); 
            
            }
              


            var jwtToken = _userService.GenerateToken(user.username, user.password, user.RoleId=0);



            if (jwtToken == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(jwtToken);
        }


    }
}


