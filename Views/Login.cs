using InventoryApp.InventoryApp;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryApp.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Check username and password against the database
            if (ValidateUserCredentials(username, password))
            {
                // Navigate to another form or perform any desired actions on successful login
                MainView anotherForm = new MainView();
                anotherForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUserCredentials(string username, string password)
        {
            string connectionString = ConnectionManager.GetConnection().ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                return (count > 0);
            }
        }
    }
}
