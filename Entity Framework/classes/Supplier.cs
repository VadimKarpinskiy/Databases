using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEntityFramework
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<Product>();
        }

        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}

