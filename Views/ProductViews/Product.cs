using System;
using System.Data;
using InventoryApp.Entity;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class Product : Form
    {
        private readonly ProductManager productManager;
        public Product()
        {
            InitializeComponent();
            productManager = new ProductManager();
            dataGridView1.DataSource = productManager.GetProducts();
        }

        //SEARCH AND DISPLAY RESULTS
        private void PerformSearch()
        {
            DataTable dt = productManager.SearchProducts(textBox1.Text);
            dataGridView1.DataSource = dt;
        }

        //IF USER PRESS ENTER KEY
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformSearch();
                e.Handled = true;
            }
        }

        //RESET DATAGRIDVIEW IF TEXTBOX IS EMPTY
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                PerformSearch();
            }
        }

        // ADD TO CART
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the values from the selected row
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string name = (string)row.Cells["Name"].Value;
                int price = (int)row.Cells["Price"].Value;
                int stock = (int)row.Cells["Stock"].Value;

                // Add item to the cart
                if (stock > 0)
                {
                    bool itemAdded = ProductManager.AddItemToCart(name, price);
                    if (itemAdded)
                    {
                        MessageBox.Show("Product added to cart.");
                    }
                }
                else
                {
                    MessageBox.Show("Product out of stock.");
                }
            }
        }
    }
}
