using System;
using System.Data;
using InventoryApp.Entity;
using System.Windows.Forms;
using InventoryApp.InventoryApp.dlg;

namespace InventoryApp
{
    public partial class Inventory : Form
    {
        private readonly ProductManager productManager;
        public Inventory()
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

        // ADD
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductDialog dlg = new ProductDialog(productManager);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = productManager.GetProducts();
            }
        }

        // EDIT
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the data from the selected row
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;
                string name = row.Cells["name"].Value.ToString();
                int price = (int)row.Cells["price"].Value;
                int stock = (int)row.Cells["stock"].Value;
                int unit = (int)row.Cells["unit"].Value;
                string category = row.Cells["category"].Value.ToString();

                // Pass the data to EditDialog
                ProductDialog dlg = new ProductDialog(productManager, id, name, price, stock, unit, category);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.DataSource = productManager.GetProducts();
                }
            }
            else
            {
                MessageBox.Show("No product is available for editing.", "Empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // REMOVE
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

                if (MessageBox.Show("Are you sure want to delete this item?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    productManager.DeleteProduct(id);
                    dataGridView1.DataSource = productManager.GetProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // STOCK
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string name = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
                AddStock dlg = new AddStock(name);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.DataSource = productManager.GetProducts();
                }
            }
            else
            {
                MessageBox.Show("No products are available for adding stock.", "Empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // HISTORY
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                History historyForm = new History(id);
                historyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No product history is available.", "Empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
