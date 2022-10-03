using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
public class cart
{
[Column("productID")] public int productID { get; set; }
[Column("productName")] public string? productName { get; set; }
[Column("productPrice")] public int productPrice { get; set; }
[Column("imageUrl")] public string? imageUrl { get; set; }
[Column("productQty")] public int productQty { get; set; }
[Column("totalPrice")] public int? totalPrice { get; set; }
[Column("username")] public string? username { get; set; }
}
}
