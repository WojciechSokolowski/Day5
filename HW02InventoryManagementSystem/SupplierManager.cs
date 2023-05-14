using HW02InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HW02InventoryManagementSystem
{
    internal class SupplierManager
    {
        private LocaldbMssqllocaldbContext db;

        public SupplierManager() 
        {
            db = new LocaldbMssqllocaldbContext();
        }

        public void AddSupplier(Supplier supplier)
        {
            try
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void RemoveSupplier(Supplier supplier)
        {
            try
            {
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void EditSupplier(Supplier supplier)
        {
            try
            {
                db.Suppliers.Update(supplier);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string LoadSuppliers()
        {
            var suppliers = db.Suppliers;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("ID \t\t Name \t\t Contact Person \t\t Email \t\t Phone \t\t Address\n");

            foreach (var supplier in suppliers)
            {
                stringBuilder.Append(supplier.SupplierId + "\t\t");
                stringBuilder.Append(supplier.Name + "\t\t");
                stringBuilder.Append(supplier.ContactPerson + "\t\t");
                stringBuilder.Append(supplier.Email + "\t\t");
                stringBuilder.Append(supplier.Phone + "\t\t");
                stringBuilder.Append(supplier.Address + "\n");
            }
            return stringBuilder.ToString();
        }


    }
}
