﻿using System;
using InventoryApp.Entity;
using InventoryApp.Managers;
using InventoryApp.Services;
using System.Windows.Forms;
using InventoryApp.Module;

namespace InventoryApp
{
    public partial class Checkout : Form
    {
        private readonly PointOfSale pointOfSale;
        public Checkout(decimal totalPrice)
        {
            InitializeComponent();

            pointOfSale = new PointOfSale();
            CartManager cartManager = new CartManager();

            label3.Text = totalPrice.ToString();

            pointOfSale.InitializeComboBox(comboBox1);
            pointOfSale.CalculateDiscount(label3.Text, comboBox1.SelectedItem, label7, label8);
            cartManager.LoadCartItems(listBox1);
        }

        // ON TEXT CHANGED
        public void ChangeEventHandler()
        {
            if (decimal.TryParse(textBox2.Text, out _))
            {
                pointOfSale.CalculateChange(label8, textBox2, label10);
            }
        }

        // COMBOBOX EVENT
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pointOfSale.CalculateDiscount(label3.Text, comboBox1.SelectedItem, label7, label8);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // TODO: not working
            pointOfSale.CalculateDiscount(label3.Text, comboBox1.SelectedItem, label7, label8);
        }

        // TEXTBOX EVENT
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ChangeEventHandler();
        }

        // LABEL8 EVENT
        private void label8_TextChanged(object sender, EventArgs e)
        {
            ChangeEventHandler();
        }

        // INSERT STOCK BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            TransactionManager transactionManager = new TransactionManager();
            TransactionIdGenerator transactionIdGenerator = new TransactionIdGenerator();

            string uid = transactionIdGenerator.GenerateTransactionId();

            transactionManager.InsertTransactionItems(uid);

            if (pointOfSale.ProcessTransaction(label3.Text, textBox2.Text, comboBox1.SelectedItem, uid))
            {
                DialogResult = DialogResult.OK;
            }
        }

        // 5
        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        // 10
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

        // 15
        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;
        }

        // 30
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 3;
        }
    }
}
