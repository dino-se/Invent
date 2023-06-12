using System;
using InventoryApp.Entity;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class Quantity : Form
    {
        private readonly CartManager cartManager;

        private readonly int productId;
        public Quantity(string name, int price, int quantity, int productId)
        {
            InitializeComponent();

            this.productId = productId;
            numericUpDown1.Value = quantity;

            label1.Text = name;
            label2.Text = price.ToString();
            label3.Text = productId.ToString();

            cartManager = new CartManager();
        }

        //SAVE BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateQuantityInCart();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateQuantityInCart()
        {
            string quantity = numericUpDown1.Value.ToString();
            cartManager.UpdateQuantityInCart(productId, quantity);
        }
    }
}
