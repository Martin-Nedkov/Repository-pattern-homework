using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Data.Models;

namespace Products.Business
{
    public class ProductTypeLogic
    {
        private ProductContext typeContext = new ProductContext();

        public List<ProductType> GetAllProductTypes()
        {
            return typeContext.ProductsTypes.ToList();
        }
        public string GetTypeById(int id)
        {
            return typeContext.ProductsTypes.Find(id).ProductTypeName;
        }
    }
}
