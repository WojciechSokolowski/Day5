﻿// See https://aka.ms/new-console-template for more information
using HW01LibraryManagement;


Console.WriteLine("Enter your username:");
string username = Console.ReadLine();

Console.WriteLine("Enter your password:");
string password = Console.ReadLine();

bool isLoggedIn = UserRepository.Login(username, password);

if (isLoggedIn)
{



    BookRepository bookRepository = new BookRepository();
    Book[] books = bookRepository.GetBook();


    Book newBook = new Book()
    {
        BookID = 4,
        Title = "Hobbit",
        Author = "J.R.R. Tolkien",
        ISBN = "999000",
        Avalibility = false
    };
    Book newBook2 = new Book()
    {
        BookID = 4,
        Title = "T",
        Author = "Tester",
        ISBN = "999-99",
        Avalibility = false
    };



    foreach (var book in books)
    {
        Console.WriteLine(book.BookID + "\t" + book.Title + "\t" + book.Author + "\t" + book.Avalibility);
    }

    //bookRepository.AddBook(newBook);

    bookRepository.EditBook(newBook);

    //bookRepository.DeleteBook(2);

    Borrower borrower = new Borrower()
    {
        Name = "John Black",
        Email = @"jb@gmail.com",
        Phone = "999111333",
        TotalBorrowedBooks = 0
    };
    Borrower borrower2 = new Borrower()
    {
        BorrowerID = 2,
        Name = "Grzegorz Brzeczyszczykiewicz",
        Email = @"gb@gmail.com",
        Phone = "6662137666",
        TotalBorrowedBooks = 1
    };

    DateTime dateTime = new DateTime(2022, 10, 15, 14, 30, 0);
    DateTime dateTime2 = new DateTime(2022, 10, 30, 14, 30, 0);
    AdditionalFunctionalities.ReturnWithFee(newBook, borrower2,dateTime2,dateTime);

    BorrowersRepository borrowersRepository = new BorrowersRepository();
    //borrowersRepository.AddBorrower(borrower);

    Borrower[] borrowers = borrowersRepository.GetBorrower();

    foreach (var b in borrowers)
    {
        Console.WriteLine(b.BorrowerID + "\t" + b.Name + "\t" + b.Email + "\t" + b.Phone + "\t" + b.TotalBorrowedBooks);
    }

    //   borrowersRepository.EditBorrower(borrower2);
    //    borrowersRepository.DeleteBorrower(3);

    //   Borrower[] borrowers2 = borrowersRepository.GetBorrower();

    //foreach (var b in borrowers2)
    //{
    //    Console.WriteLine(b.BorrowerID + "\t" + b.Name + "\t" + b.Email + "\t" + b.Phone + "\t" + b.TotalBorrowedBooks);
    //}


}
else 
    Environment.Exit(0);
