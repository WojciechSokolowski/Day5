
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HW02InventoryManagementSystem.Models;


namespace HW02InventoryManagementSystem
{
    internal class ProductManager
    {
        private LocaldbMssqllocaldbContext db;

        public ProductManager() 
        { 
            db = new LocaldbMssqllocaldbContext();
        }

        public void AddProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        public void RemoveProduct(Product product)
        {
            try
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        public void UpdateProduct(Product product)
        {
            try
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string LoadProducts()
        {
            var products = db.Products;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("ID \t\t Name \t\t Description \t\t Category \t\t Quantity \t\t Price \t\t SupplierID\n");

            foreach (var product in products)
            {
                stringBuilder.Append(product.ProductId +"\t\t");
                stringBuilder.Append(product.Name + "\t\t");
                stringBuilder.Append(product.Description + "\t\t");
                stringBuilder.Append(product.Category + "\t\t");
                stringBuilder.Append(product.Quantity + "\t\t");
                stringBuilder.Append(product.Price + "\t\t");
                stringBuilder.Append(product.SupplierId + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
