using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Models
{
    public class Cart
    {
        public int productID { get; set; }
        public string? productName { get; set; }
        public int productPrice { get; set; }
        public string? imageUrl { get; set; }
        public int productQty { get; set; }
        public int? totalPrice { get; set; }
        public string? username { get; set; }
    }
}
