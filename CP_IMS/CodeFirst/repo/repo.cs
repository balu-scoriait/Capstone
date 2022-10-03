using CodeFirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.repo
{
public class repo : Irepo
{
private readonly ProductDBContext _productdbcontext;
public repo(ProductDBContext productdbcontext)
{
_productdbcontext = productdbcontext;
}
public IEnumerable<Product> getproducts()
{
return _productdbcontext.Products;
}
public string createproduct(Product p)
{
_productdbcontext.Products.Add(p);
_productdbcontext.SaveChanges();
return "OK";
}

        public IEnumerable<cart> getcarts()
        {
            return _productdbcontext.Cart;
        }

        public IEnumerable<cart> getcartlist(string username)
{
var param = new SqlParameter[]
{
new SqlParameter() { ParameterName = "@username", SqlDbType=System.Data.SqlDbType.NVarChar,Direction=System.Data.ParameterDirection.Input,Value=username}
};
return _productdbcontext.getCartListbyUserName.FromSqlRaw("[dbo].[getCartListbyUserName] @username", param).AsEnumerable().ToList();
}

public string addcartlist(cart cart)
{
var param = new SqlParameter[]
{
                new SqlParameter()
                {
                ParameterName = "@productid",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = cart.productID

                },

                new SqlParameter()
                {
                    ParameterName = "@productname",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = cart.productName
                },

                new SqlParameter()
                {
                    ParameterName = "@productprice",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value =cart.productPrice
                },
                 new SqlParameter()
                {
                    ParameterName = "@imageurl",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value =cart.imageUrl
                },

                 new SqlParameter()
                {
                    ParameterName = "@productqty",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value =cart.productQty
                },
                 new SqlParameter()
                {
                    ParameterName = "@totalprice",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value =cart.totalPrice
                },
                 new SqlParameter()
                {
                    ParameterName = "@username",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value =cart.username
                },
             };

            _productdbcontext.SaveChanges();

            int intitem = _productdbcontext.Database.ExecuteSqlRaw("[dbo].[createcartListforUser] @productid,@productname,@productprice,@imageurl,@productqty, @totalprice,@username", param);


            return "Ok";
        }

    
}
}
