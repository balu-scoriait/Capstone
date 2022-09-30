using CodeFirst.Models;

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
        public IEnumerable<cart> getcartlist()
        {
            return _productdbcontext.Cart;

        }
        public string addcartlist(cart cart)
        {
            _productdbcontext.Cart.Add(cart);
            _productdbcontext.SaveChanges();
            return "OK";
        }

    
}
}
