using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.AspNetCore.Mvc;

namespace Ecommerces.Models
{
    public class AuthService
    {
        //public string baseAddress;
        private readonly IHttpContextAccessor _contextAccessor;

        public string baseaddress { get; set; }

        private readonly IWebHostEnvironment _webHostEnvironment;
       // private readonly IHttpContextAccessor _hca; 


        public AuthService(IHttpContextAccessor h)
        {
            //_webHostEnvironment = e;
            _contextAccessor = h;

        }

        public async Task<bool> RegisterUserAsync(
            Customer e)
        {
           
            var model = new Customer

            {
                name = e.name,
                email = e.email,
                username=e.username,
                password=e.password,
                appcode = "registerConn",

               

            };

            //***********************************************---------*********************************************************************
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseaddress);     //APIGateway_BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                string serializedObject = JsonConvert.SerializeObject(model);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Auth/register", contentPost);
                //****************************************************************************************************************************** 

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

     
        public async Task<string[]> LoginAsync(string username, string password)
        {

            try
            {
                HttpClient client = new HttpClient();
                var model = new Customer
                {
                    username = username,
                    password = password,

                    appcode = "registerConn"
                };

                    client.BaseAddress = new Uri(baseaddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    string serializedObject = JsonConvert.SerializeObject(model);
                    HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/Auth/login", contentPost);

                    //*****************************************************************************************************************888

                    // var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStringAsync();
                        var handler = new JwtSecurityTokenHandler();

                       
                        JToken jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);
                      

                        string[] accessToken = new string[] { "", ""};
                        accessToken[0] = jwtDynamic.Value<string>("auth_token");



                        var token = handler.ReadJwtToken(accessToken[0]);


                       

                        var accessTokenExpiration = TimeZoneInfo.ConvertTimeFromUtc(token.ValidTo, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                        accessToken[1] = accessTokenExpiration.ToString();
                       // _contextAccessor.HttpContext.Session.SetString("AccessTokenExpirationDate", accessTokenExpiration.ToString());

                      


                        return accessToken;
                    }
                    else
                { return null;}
                
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
    }
}