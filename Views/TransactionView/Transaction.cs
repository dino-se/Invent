﻿using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryApp.InventoryApp.dlg
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
            DisplayTransaction();
        }

        //FETCH DATA FROM TRANSACTION TABLE
        private void DisplayTransaction()
        {
            using (SqlConnection con = ConnectionManager.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Date, Subtotal, [Percent], Amount, Total, Change, Uid FROM [Transaction] ", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        //CELL CLICK EVENT FOR OPENING DETAILS
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = (string)dataGridView1.SelectedRows[0].Cells["Uid"].Value;
                Details dlg = new Details(id);
                dlg.ShowDialog();
            }
        }
    }
}
