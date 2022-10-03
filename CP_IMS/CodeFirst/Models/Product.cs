using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Product
    {
        [Column("productID")] public int productID { get; set; }
        [Column("productName")] public string? productName { get; set; }
        [Column("productPrice")] public int productPrice { get; set; }
        [Column("imageUrl")] public string? imageUrl { get; set; }
    }
}


/* ************productID,productName,productPrice,imageUrl**************** */