using CodeFirst.Models;
using CodeFirst.repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Irepo _repo;

        public ProductsController(IConfiguration configuration, Irepo repo)
        {
            _configuration = configuration;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Product> getproducts()
        {
            return _repo.getproducts();
        }
        [HttpPost]
        [Route("createproduct")]
        public IActionResult Create([FromBody] Product c)
        {

            var status = _repo.createproduct(c);

            if (status == "OK")
            {
                return Ok(new { message = "product added successfully!" });
            }
            else
            {
                return StatusCode(429, status);
            }
        }
    }
}
