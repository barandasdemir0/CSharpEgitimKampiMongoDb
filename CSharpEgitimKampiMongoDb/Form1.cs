using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpEgitimKampiMongoDb.Entities;
using CSharpEgitimKampiMongoDb.Services;

namespace CSharpEgitimKampiMongoDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customer = new CustomerOperations(); // CustomerOperations sınıfından örnek oluşturuyoruz yani customer kullanarak verilerine erişebileceğiz
        private void btnadd_Click(object sender, EventArgs e)
        {
            var Customer = new Customer() // Customer sınıfından bir nesne oluşturuyoruz
            {
                CustomerName = txtad.Text, // txtCustomerName textbox'ındaki veriyi CustomerName özelliğine atıyoruz
                CustomerSurname = txtsoyad.Text, // txtCustomerSurname textbox'ındaki veriyi CustomerSurname özelliğine atıyoruz
                CustomerCity = txtsehir.Text, // txtCustomerCity textbox'ındaki veriyi CustomerCity özelliğine atıyoruz
                CustomerBalance = decimal.Parse(txtbakiye.Text), // txtCustomerBalance textbox'ındaki veriyi CustomerBalance özelliğine atıyoruz
                CustomerShoppingCount = int.Parse(txtalisveristutar.Text) // txtCustomerShoppingCount textbox'ındaki veriyi CustomerShoppingCount özelliğine atıyoruz
            };

            customer.AddCustomer(Customer);// customer nesnesini CustomerOperations sınıfındaki AddCustomer metoduna gönderiyoruz
            MessageBox.Show("veriler eklendi");

        }
    }
}
