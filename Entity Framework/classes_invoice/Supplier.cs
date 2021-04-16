using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEntityFramework
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        public Supplier()
        {
            Products = new Collection<Product>();
            InvoiceProducts = new Collection<InvoiceProduct>();
        }

    }
}

