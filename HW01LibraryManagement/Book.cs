using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01LibraryManagement
{
    internal class Book
    {
        public int BookID{ get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Avalibility { get; set; }  
    }
}
