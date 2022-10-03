using CodeFirst.Models;

namespace CodeFirst.repo
{
public interface Irepo
{
public string createproduct(Product p);
public IEnumerable<Product> getproducts();
public string addcartlist(cart cart);
public IEnumerable<cart> getcartlist(string username);
        public IEnumerable<cart> getcarts();
}
}