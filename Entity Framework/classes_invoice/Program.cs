using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace VKEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // SUPPLIER
            ProductContext productContext = new ProductContext();
            Console.WriteLine("Enter company name of the supplier: ");
            string compName = Console.ReadLine();
            Supplier supplier = productContext.Suppliers.FirstOrDefault(s => s.CompanyName == compName);
            if (supplier is null)
            {
                supplier = new Supplier { CompanyName = compName };
                productContext.Suppliers.Add(supplier);
            }
            // ---------------------------------------------------------------- //

            // PRODUCT
            Console.WriteLine("Enter name of the product: ");
            string prodName = Console.ReadLine();
            Product product = new Product { ProductName = prodName };
            productContext.Products.Add(product);
            // ---------------------------------------------------------------- //

            // INVOICE
            Console.WriteLine("Enter invoice number: ");
            int invoiceNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter quantity of the product: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Invoice invoice = productContext.Invoices.FirstOrDefault(i => i.InvoiceNumber == invoiceNumber);
            if (invoice is null) 
            {
                invoice = new Invoice { InvoiceNumber = invoiceNumber, Quantity = quantity };
                productContext.Invoices.Add(invoice);
            }
            // ---------------------------------------------------------------- //

            // Connecting tables with each other
            product.Supplier = supplier;
            supplier.Products.Add(product);

            InvoiceProduct invoiceProduct = new InvoiceProduct();
            invoiceProduct.Invoice = invoice;
            invoiceProduct.Product = product;

            invoice.InvoiceProducts.Add(invoiceProduct);
            product.InvoiceProducts.Add(invoiceProduct);

            productContext.InvoiceProducts.Add(invoiceProduct);
            productContext.SaveChanges();
            // ---------------------------------------------------------------- //

            Console.WriteLine("Products included into invoice number " + invoiceNumber);

            var products = productContext.InvoiceProducts
                .Include(ip => ip.Product)
                .Where(ip => ip.Invoice.InvoiceNumber == invoiceNumber)
                .Select(ip => ip.Product.ProductName).ToList();

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Invoices that include product with name " + prodName);

            var invoices = productContext.InvoiceProducts
                .Include(ip => ip.Invoice)
                .Where(ip => ip.Product.ProductName == prodName)
                .Select(ip => ip.Invoice.InvoiceNumber).ToList();

            foreach (var i in invoices)
            {
                Console.WriteLine(i);
            }
        }
    }
}
