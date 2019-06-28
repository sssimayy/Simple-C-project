using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _312Proje
{
    class Book
    {
        public int bookID { get; set; }
        public string name { get; set; }
        public string Author { get; set; }

      
        public double price { get; set; }
        public int publishID { get; set; }
        public int currentStock { get; set; }
        public string type { get; set; }

        public Book()
        {
        }
    }
}
