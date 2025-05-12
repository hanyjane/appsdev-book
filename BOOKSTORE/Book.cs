using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTORE
{
    public class Book
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public byte[] BookCover { get; set; } // image from DB
    }


}


