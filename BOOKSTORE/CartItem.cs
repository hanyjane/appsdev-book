using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTORE
{
    internal class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
