using HW02InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }
        public void RemoveSupplier(Supplier supplier)
        {
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }

        public void EditSupplier(Supplier supplier)
        {
            db.Suppliers.Update(supplier);
            db.SaveChanges();
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
