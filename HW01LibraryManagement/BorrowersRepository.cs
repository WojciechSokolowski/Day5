using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01LibraryManagement
{
    internal class BorrowersRepository
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=(localdb)\\mssqllocaldb;Integrated Security=True;";



        public Borrower[] GetBorrower()
        {
            List<Borrower> borrowers = new List<Borrower>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Borrowers", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Borrower borrower = new Borrower();

                                borrower.BorrowerID = reader.GetInt32(0);
                                borrower.Name = reader.GetString(1);
                                borrower.Email = reader.GetString(2);
                                borrower.Phone = reader.GetString(3);
                                borrower.TotalBorrowedBooks = reader.GetInt32(4);

                                borrowers.Add(borrower);
                            }
                        }
                    }
                }

            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error when connecting to get borrower " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when getting borrower " + ex.Message);
            }

            return borrowers.ToArray();

        }




        public void AddBorrower(Borrower borrower)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Borrowers (Name, Email, Phone, TotalBorrowedBooks) VALUES (@Name, @Email, @Phone, @TotalBorrowedBooks)", connection);
                    command.Parameters.AddWithValue("@Name", borrower.Name);
                    command.Parameters.AddWithValue("@Email", borrower.Email);
                    command.Parameters.AddWithValue("@Phone", borrower.Phone);
                    command.Parameters.AddWithValue("@TotalBorrowedBooks", borrower.TotalBorrowedBooks);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Borrower added successfully.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error adding the borrower: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void DeleteBorrower(int borrowerID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Borrowers WHERE BorrowerID = @BorrowerID", connection);
                    command.Parameters.AddWithValue("@BorrowerID", borrowerID);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Borrower deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Borrower not found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error deleting the borrower: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void EditBorrower(Borrower updatedBorrower)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Borrowers SET Name = @Name, Email = @Email, Phone = @Phone, TotalBorrowedBooks = @TotalBorrowedBooks WHERE BorrowerID = @BorrowerID", connection);
                    command.Parameters.AddWithValue("@BorrowerID", updatedBorrower.BorrowerID);
                    command.Parameters.AddWithValue("@Name", updatedBorrower.Name);
                    command.Parameters.AddWithValue("@Email", updatedBorrower.Email);
                    command.Parameters.AddWithValue("@Phone", updatedBorrower.Phone);
                    command.Parameters.AddWithValue("@TotalBorrowedBooks", updatedBorrower.TotalBorrowedBooks);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Borrower updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Borrower not found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error editing the borrower: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
