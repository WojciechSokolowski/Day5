using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01LibraryManagement
{
    internal class AdditionalFunctionalities
    {
        public static void Borrow(Book book, Borrower borrower)
        {
            BookRepository bookRepository = new BookRepository();
            BorrowersRepository borrowersRepository = new BorrowersRepository();
            try
            {
                if (book.Avalibility)
                {
                    borrower.TotalBorrowedBooks += 1;
                    book.Avalibility = false;
                    bookRepository.EditBook(book);
                    borrowersRepository.EditBorrower(borrower);

                }
                else
                    throw new Exception("Book Unavalible");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when borrowing " + ex.Message);
            }
        }

        public static void Return(Book book, Borrower borrower)
        {
            BookRepository bookRepository = new BookRepository();
            BorrowersRepository borrowersRepository = new BorrowersRepository();
            try
            {
                if (!book.Avalibility)
                {
                    if (borrower.TotalBorrowedBooks > 0)
                        borrower.TotalBorrowedBooks -= 1;
                    else
                        throw new Exception("Borrower dont have borrowed books");
                    book.Avalibility = true;
                    bookRepository.EditBook(book);
                    borrowersRepository.EditBorrower(borrower);
                }
                else
                    throw new Exception("This book was not borrowed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when returning book " + ex.Message);
            }

        }

        private static int CalculateFee(DateTime actualReturn, DateTime expectedReturn)
        {
            int fee = 0;
            if(actualReturn > expectedReturn)
            {
               TimeSpan timeSpan = actualReturn - expectedReturn;
                fee = 10 * (int)timeSpan.TotalDays;
            }
            return fee;

        }

        public static void ReturnWithFee(Book book, Borrower borrower, DateTime actualReturn, DateTime expectedReturn)
        {
            Return(book, borrower);
            int fee = CalculateFee(actualReturn, expectedReturn);
            Console.WriteLine($"Borrower must pay {fee} dolars");

        }




    }
}
