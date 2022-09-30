using CodeFirst.Models;
using CodeFirst.repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        [Route("addtocart")]
        public IEnumerable<cart> getcartlist()
        {
            return _repo.getcartlist();
        }


        [HttpPost]
        [Route("addtocart")]
        public IActionResult Create([FromBody] cart Cart)
        {

            var status = _repo.addcartlist(Cart);

            if (status == "OK")
            {
                return Ok(new { message = "product added to successfully!" });
            }
            else
            {
                return StatusCode(429, status);
            }
        }




        [HttpDelete("{product_id}")]
        public JsonResult Delete(int product_id)
        {
            string query = @"delete from dbo.Cart where product_id=@product_id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("registerConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@product_id", product_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Product");
        }
    }
}
