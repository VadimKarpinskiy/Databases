using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEntityFramework
{
    public class InvoiceProduct
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }
    }
}
