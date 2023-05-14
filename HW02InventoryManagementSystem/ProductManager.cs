
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();

        }
        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
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
