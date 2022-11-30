using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Business;
using Products.Data.Models;

namespace Products
{
    public partial class ProductObjects
    {
        string id, name, description, price, weight, types;
        ProductType type = new ProductType();
        ProductLogic productLogic = new ProductLogic();
        ProductTypeLogic productTypeLogic = new ProductTypeLogic();

        public void LoadRecord(Product product)
        {
            Console.Write("Id = ");
            id = product.Id.ToString();

            Console.Write("Name: ");
            name = product.Name;

            Console.Write("Description: ");
            description = product.Description.ToString();

            Console.Write("Price = ");
            price = product.Price.ToString();

            Console.Write("Weight = ");
            weight = product.Weight.ToString();

            ProductType type = new ProductType();
            Console.Write("Types: ");
            types = type.ProductTypeName;
        }

        public void ClearScreen()
        {
            id = "";
            name = "";
            description = "";
            price = "";
            weight = "";
        }

        public void ListPrint()
        {
            List<ProductType> allProducts = productTypeLogic.GetAllProductTypes();
            string.Join(", ", allProducts);
        }

        public void AddItem()
        {
            if (name == null || name == "")
            {
                Console.WriteLine("Enter data first!");
                return;
            }
            Product newProduct = new Product();
            newProduct.Name = name;
            newProduct.Description = description;
            newProduct.Price = decimal.Parse(price);
            newProduct.Weight = decimal.Parse(weight);
            newProduct.TypeId = int.Parse(types);
            productLogic.Add(newProduct);
            Console.WriteLine("Successfully added!");
            ClearScreen();
        }

        public void DuplicateAllItems()
        {
            List<Product> allProducts = productLogic.GetAll();
            List<string> dupItems = new List<string>();
            foreach (var item in allProducts)
            {
                dupItems.Add($"{item.Id}. {item.Name}/ Description: {item.Description}/ Price: {item.Price}/ Weight: {item.Weight}/ Type: {productTypeLogic.GetTypeById(item.TypeId)}");
            }

        }

        public void FindWithId()
        {
            int findId = 0;
            while (id == null || id == "")
            {
                Console.WriteLine("No ID selected!");
                return;
            }
            findId = int.Parse(id);
            Product newProduct = productLogic.Get(int.Parse(id));


            if (newProduct == null)
            {
                Console.WriteLine("No available ID!");
                return;
            }
            LoadRecord(newProduct);
        }

        public void UpdateList()
        {
            int findId = 0;
            while (id == "" || id == null)
            {
                Console.WriteLine("Enter ID for search!");
                return;
            }
            findId = int.Parse(id);

            if (name == null || name == "")
            {
                Product findedProduct = productLogic.Get(findId);
                if (findedProduct == null)
                {
                    Console.WriteLine("THERE IS NO SUCH RECORD! \n Enter ID for search!");
                    return;
                }
                LoadRecord(findedProduct);
            }
            else
            {
                Product updatedProduct = new Product();
                updatedProduct.Name = name;
                updatedProduct.Description = description;
                updatedProduct.Price = decimal.Parse(price);
                updatedProduct.Weight = decimal.Parse(weight);
                updatedProduct.TypeId = int.Parse(types);
                productLogic.Update(findId, updatedProduct);
                DuplicateAllItems();
            }
        }

        public void DeleteSelectedItem()
        {
            while (id == null || id == "")
            {
                Console.WriteLine("No ID selected!");
                return;
            }

            int idVal = int.Parse(id);

            Product product = productLogic.Get(idVal);
            if (product == null)
            {
                Console.WriteLine("No available ID!");
                return;
            }
            LoadRecord(product);
            Console.WriteLine("Are you sure you want to delete number {0}?", id);
            Console.Write("Answer with yes or no: ");
            string answer = Console.ReadLine();
            if (answer == "Yes" || answer == "yes" || answer == "YES")
            {
                productLogic.Delete(idVal);
            }
            DuplicateAllItems();
        }
    }
}
