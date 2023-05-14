using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01LibraryManagement
{
    internal class Borrower
    {
        public int BorrowerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public int  Phone { get; set; }
        public int TotalBorrowedBooks { get; set; }
    }
}
