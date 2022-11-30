using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Data.Models;

namespace Products.Business
{
    public class ProductLogic
    {
        private ProductContext productContext = new ProductContext();

        public List<Product> GetAll()
        {
            return productContext.Products.ToList();
        }

        public Product Get(int id)
        {
            Product findedProduct = productContext.Products.Find(id);
            return findedProduct;
        }

        public void Add(Product product)
        {
            productContext.Products.Add(product);
            productContext.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            Product findedProduct = productContext.Products.Find(id);
            findedProduct.Name = product.Name;
            findedProduct.Description = product.Description;
            findedProduct.Price = product.Price;
            findedProduct.TypeId = product.TypeId;
            productContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Product findedProduct = productContext.Products.Find(id);
            productContext.Products.Remove(findedProduct);
            productContext.SaveChanges();
        }
    }
}
