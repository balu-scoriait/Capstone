using CodeFirst.Models;

namespace CodeFirst.repo
{
    public interface Irepo
    {
        
        public IEnumerable<Product> getproducts();

        public string createproduct(Product p);

        public IEnumerable<cart> getcartlist();

        public string addcartlist(cart cart);
       
    
    }
}
