using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string connectionString = "Server=(localdb)\\mssqllocaldb;Database=(localdb)\\mssqllocaldb;Integrated Security=True;";


using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    //using (SqlCommand command = new SqlCommand("INSERT INTO Persons (FirstName,LastName) VALUES(@FirstName, @LastName)", connection))
    //{
    //    command.Parameters.AddWithValue("@FirstName", "John");
    //    command.Parameters.AddWithValue("@LastName", "Doe");
    //    int rowsAffected = command.ExecuteNonQuery();
    //    Console.WriteLine($"{rowsAffected} rows affected.");
    //}


    //using (SqlCommand command = new SqlCommand("SELECT ID, FirstName, LastName FROM Persons", connection))
    //{
    //    using (SqlDataReader reader = command.ExecuteReader())
    //    {
    //        while (reader.Read())
    //        {
    //            Console.WriteLine($"Id: {reader.GetInt32(0)}," +
    //                $" FirstName: {reader.GetString(1)}," +
    //                $" LastName: {reader.GetString(2)}");
    //        }
    //    }
    //}


    //using (SqlCommand command = new SqlCommand("UPDATE Persons SET FirstName = @FirstName WHERE Id = @Id", connection))
    //{
    //    command.Parameters.AddWithValue("@Id", 10);
    //    command.Parameters.AddWithValue("@FirstName", "UpdatedFirstName");
    //    int rowsAffected = command.ExecuteNonQuery();
    //    Console.WriteLine($"{rowsAffected} rows affected.");
    //}


    //using (SqlCommand command = new SqlCommand("DELETE FROM Persons WHERE Id = @Id", connection))
    //{
    //    command.Parameters.AddWithValue("@Id", 10);
    //    int rowsAffected = command.ExecuteNonQuery();
    //    Console.WriteLine($"{rowsAffected} rows affected.");
    //}
    try
    {
        using (SqlCommand command = new SqlCommand("DELETE FROM Persons WHERE Id = @Id", connection))
        {
            //shows regular exeption divide by zero
            //int a = 5;
            //int b = 0;
            //int c = a / b;

            command.Parameters.AddWithValue("@Id", 10);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows affected.");
        }
    }
    catch (SqlException ex)
    {
        Console.WriteLine("An error occurred while connecting to the database or executing the command: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("An unexpected error occurred: " + ex.Message);
    }


    connection.Close();
}