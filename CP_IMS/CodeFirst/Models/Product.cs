using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Product
    {
        [Column("product_id")] public int product_id { get; set; }
        [Column("product_name")] public string? product_name { get; set; }
        [Column("product_price")] public int product_price { get; set; }
        [Column("image_url")] public string? image_url { get; set; }
    }
}


/* ************productID,productName,productPrice,imageUrl**************** */