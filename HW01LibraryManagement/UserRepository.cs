using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01LibraryManagement
{
    internal class UserRepository
    {
        private static List<User> users = new List<User> {
        new User { Name = "Admin", Password="123"},
        new User { Name = "Alice", Password = "password" },
        new User { Name = "Bob", Password = "qwerty" }
    };


        public static bool Login(string username, string password)
        {
            User user = users.Find(u => u.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user != null && user.Password == password)
            {
                Console.WriteLine("Logged in successfully");
                return true;
            }

            Console.WriteLine("Invalid username or password, try again");
            return false;
        }
    }
}
