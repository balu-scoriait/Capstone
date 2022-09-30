using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class cart
    {
        
            [Column("product_id")] public int product_id { get; set; }
            [Column("product_name")] public string? product_name { get; set; }
            [Column("product_price")] public int product_price { get; set; }
            [Column("image_url")] public string? image_url { get; set; }
            [Column("product_quantity")] public int product_quantity { get; set; }
            [Column("total_price")] public int? total_price { get; set; }
        [Column("username")] public string? username { get; set; }


    }
}
