using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEntityFramework
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitsOnStock { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        public Product()
        {
            InvoiceProducts = new Collection<InvoiceProduct>();
        }
    }
}


