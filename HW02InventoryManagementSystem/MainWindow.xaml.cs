using HW02InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW02InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Product JoinProduct(bool a)
        {

            Product product = new Product();
            try
            {
                if (a)
                    product.ProductId = Convert.ToInt32(ProductID.Text);
                product.Name = PName.Text;
                product.Description = Desc.Text;
                product.Category = Category.Text;
                int quantity;
                if (!int.TryParse(Quantity.Text, out quantity))
                {
                    throw new Exception("Invalid quantity. Please enter a valid number.");
                }
                product.Quantity = quantity;
                decimal price;
                if (!decimal.TryParse(Price.Text, out price))
                {
                    throw new Exception("Invalid price. Please enter a valid number.");
                }
                product.Price = price;
                product.SupplierId = Convert.ToInt32(RefSupplierID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: "+ex.Message, "Error ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return product;


        }

        private Supplier JoinSupplier(bool a)
        {
            Supplier supplier = new Supplier();
            try
            {
                if (a)
                    supplier.SupplierId = Convert.ToInt32(SupplierID.Text);
                supplier.Name = SName.Text;
                supplier.ContactPerson = Contact.Text;
                supplier.Email = Email.Text;
                supplier.Phone = Phone.Text;
                supplier.Address = Address.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("We cannot process your data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return supplier;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductManager pm = new ProductManager();
            pm.AddProduct(JoinProduct(false));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductManager pm = new ProductManager();
            pm.RemoveProduct(JoinProduct(true));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProductManager pm = new ProductManager();
            pm.UpdateProduct(JoinProduct(true));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SupplierManager sm = new SupplierManager();
            sm.AddSupplier(JoinSupplier(false));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SupplierManager sm = new SupplierManager();
            sm.RemoveSupplier(JoinSupplier(true));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SupplierManager sm = new SupplierManager();
            sm.EditSupplier(JoinSupplier(true));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ProductManager pm = new ProductManager();
            Readings.Text = pm.LoadProducts();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SupplierManager sm = new SupplierManager();
            Readings.Text = sm.LoadSuppliers();
        }
    }
}
