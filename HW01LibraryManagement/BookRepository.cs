using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01LibraryManagement
{
    internal class BookRepository
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=(localdb)\\mssqllocaldb;Integrated Security=True;";


        public Book[] GetBook()
        {
            List<Book> books = new List<Book>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Books", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book();

                                book.BookID = reader.GetInt32(0);
                                book.Title = reader.GetString(1);
                                book.Author = reader.GetString(2);
                                book.ISBN = reader.GetString(3);
                                book.Avalibility = reader.GetBoolean(4);

                                books.Add(book);
                            }
                        }
                    }
                }

            } 
            
            catch(SqlException ex  ) 
            {
                Console.WriteLine("Error when connecting to get book" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error when getting book" + ex.Message);
            }

            return books.ToArray();

        }


        protected internal void AddBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Books (Title, Author, ISBN, Availability) VALUES(@Title, @Author, @ISBN, @Availability)", connection))
                    {
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN);
                        command.Parameters.AddWithValue("@Availability", book.Avalibility);
                        int rowsAffected = command.ExecuteNonQuery();

                    }


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when connecting to add book" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding book" + ex.Message);
            }
        }



        public void EditBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE Books SET Title =@Title, Author =@Author, ISBN =@ISBN, Availability =@Availability WHERE BookId=@BookId", connection))
                    {
                        command.Parameters.AddWithValue("@BookId", book.BookID);
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN);
                        command.Parameters.AddWithValue("@Availability", book.Avalibility);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when connecting to edit book" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when editing book" + ex.Message);
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM Books WHERE BookId = @BookId", connection))
                    {
                        command.Parameters.AddWithValue("@BookId", id);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when connecting to delete book" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when deleting book" + ex.Message);
            }
        }


    }
}



