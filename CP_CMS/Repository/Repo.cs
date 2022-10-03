using Ecommerces_MS.Models;
using Ecommerces_MS.Service;

namespace Ecommerces_MS.Repository
{
    public class Repo:IRepo
    {
        private readonly UserdbContext _dbcontext;
        private readonly IPasswordHasher _passwordHasher;

        public Repo(UserdbContext x ,IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _dbcontext = x;
        }

        public string createCustomers(UserRegister c)
        {
            _dbcontext.Users.Add (new Usermodel
            {
                
                username = c.username,
                email = c.email,
                name = c.name,
                password = _passwordHasher.GenerateIdentityV3Hash( c.password)
            
            });
            _dbcontext.SaveChanges();
            return "OK";
        }


    }
}
