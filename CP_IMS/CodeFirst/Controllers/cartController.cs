using CodeFirst.Models;
using CodeFirst.repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CodeFirst.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class cartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Irepo _repo;

        public cartController(IConfiguration configuration, Irepo repo)
        {
            _configuration = configuration;
            _repo = repo;
        }

        [HttpGet]
        [Route("username")]
        public IEnumerable<cart> getcartlist(string username)
        {
            return _repo.getcartlist(username);

        }

        [HttpGet]
        [Route("getcart")]
        public IEnumerable<cart> getcart()
        {
            return _repo.getcarts();
        }

        [HttpPost]
        [Route("addtocart")]
        public IActionResult Create([FromBody] cart c)
            {

                var status = _repo.addcartlist(c);

                if (status == "Ok")
                {
                    return Ok(new { message = "product added to cart successfully!" });
                }
                else
                {
                    return StatusCode(429, status);
                }
            }
        }



    /*
    [HttpDelete("{productID}")]
        public JsonResult Delete(int productID)
        {
            string query = @"delete from dbo.Cart where productID=@productID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("registerConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@productID", productID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Product");
        }
    */
}
