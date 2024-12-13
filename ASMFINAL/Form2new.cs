using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASMFINAL
{
    public partial class Form2new : Form
    {
        public Form2new()
        {
            InitializeComponent();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            // Open Form1 and close Form2
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnregist_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string username = txtuser.Text.Trim();
            string password = txtpass.Text.Trim();
            string customerId = txtID.Text.Trim();
            string name = txtname.Text.Trim();
            string phone = txtphone.Text.Trim();
            string address = txtaddress.Text.Trim();

            // Kiểm tra xem có trường nào trống không
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Connection string to the database
            string connectionString = "Data Source=DESKTOP-P8Q9SHV;Initial Catalog=ASM2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // Các truy vấn SQL để chèn dữ liệu vào cả hai bảng
            string insertCustomerQuery = "INSERT INTO Customers (CustomerID, Name, PhoneNumber, Address) VALUES (@CustomerID, @Name, @Phone, @Address)";
            string insertAccountQuery = "INSERT INTO CustomersAccounts (CustomerID, Username, Password) VALUES (@CustomerID, @Username, @Password)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Open connection

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insert into Customers table first
                            using (SqlCommand command1 = new SqlCommand(insertCustomerQuery, connection, transaction))
                            {
                                // Add parameters for the Customers table
                                command1.Parameters.AddWithValue("@CustomerID", customerId);
                                command1.Parameters.AddWithValue("@Name", name);
                                command1.Parameters.AddWithValue("@Phone", phone);
                                command1.Parameters.AddWithValue("@Address", address);

                                // Execute the command
                                command1.ExecuteNonQuery();
                            }

                            // Insert into CustomersAccounts table
                            using (SqlCommand command2 = new SqlCommand(insertAccountQuery, connection, transaction))
                            {
                                // Add parameters for the CustomersAccounts table
                                command2.Parameters.AddWithValue("@CustomerID", customerId);
                                command2.Parameters.AddWithValue("@Username", username);
                                command2.Parameters.AddWithValue("@Password", password);

                                // Execute the command
                                command2.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Close();
                        }
                        catch
                        {
                            // Hoàn tác giao dịch nếu có lỗi xảy ra
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any other errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
