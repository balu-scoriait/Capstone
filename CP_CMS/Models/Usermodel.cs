using System.ComponentModel.DataAnnotations;

namespace Ecommerces_MS.Models
{
    public class Usermodel
    {
        
        public string name { get; set; }
        public string email { get; set; }

        [Key]
        public string username { get; set; }
        public string password { get; set; }

        public int RoleId { get; set; }

        public int IsActive { get; set; }    

    }

}
