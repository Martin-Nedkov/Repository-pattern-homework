using System;
using System.Collections.Generic;
using Products.Business;
using Products.Data.Models;

namespace Products
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductObjects product = new ProductObjects();
            product.AddItem();
            product.ListPrint();
            product.FindWithId();
            product.UpdateList();
            product.DeleteSelectedItem();
            product.DuplicateAllItems();
        }
    }
}
