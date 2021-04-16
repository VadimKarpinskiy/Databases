using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace VKEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductContext productContext = new ProductContext();
            Console.WriteLine("Enter company name of the supplier: ");
            string compName = Console.ReadLine();
            Supplier supplier = productContext.Suppliers.FirstOrDefault(s => s.CompanyName == compName);
            if (supplier is null)
            {
                supplier = new Supplier { CompanyName = compName };
                productContext.Suppliers.Add(supplier);
            }

            Console.WriteLine("Enter name of the product: ");
            string prodName = Console.ReadLine();
            Product product = new Product { ProductName = prodName };
            productContext.Products.Add(product);
            supplier.Products.Add(product);
            productContext.SaveChanges();

            Console.WriteLine("Currently registered suppliers and their products: ");

            var data = productContext.Suppliers.Include(s => s.Products).ToList();
            foreach (var item in data)
            {
                Console.WriteLine("Supplier: " + item.CompanyName);
                Console.WriteLine("------------");
                foreach (Product p in item.Products)
                {
                    Console.WriteLine(p.ProductName);
                }
                Console.WriteLine("------------");
            }
          }
    }
}
