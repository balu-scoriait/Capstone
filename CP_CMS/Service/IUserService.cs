using Ecommerces_MS.Models;

namespace Ecommerces_MS.Service
{
    public interface IUserService
    {
       /* string GetUserName();*/
        SecurityTokenModel GenerateToken(string username, string password,int RoleId=0);
    }
}
