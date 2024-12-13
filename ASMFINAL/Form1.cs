using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASMFINAL
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-P8Q9SHV;Initial Catalog=ASM2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void cbbas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbas.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            string selectedRole = cbbas.SelectedItem.ToString();
            cbbposition.Enabled = selectedRole == "Employee";
            btnregist.Enabled = selectedRole != "Manager" && selectedRole != "Employee";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult checkExit = MessageBox.Show("Do you want to exit?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (checkExit == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnregist_Click(object sender, EventArgs e)
        {
            Form2new form2new = new Form2new();
            form2new.Show();
            this.Hide();
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string username = txtuser.Text.Trim();
                string password = txtpass.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbas.SelectedItem == null)
                {
                    MessageBox.Show("Please select a role.", "Role Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedRole = cbbas.SelectedItem.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Xử lý đăng nhập theo từng vai trò
                    if (selectedRole == "Manager")
                    {
                        HandleManagerLogin(connection, username, password);
                    }
                    else if (selectedRole == "Employee")
                    {
                        HandleEmployeeLogin(connection, username, password);
                    }
                    else if (selectedRole == "Customer")
                    {
                        HandleCustomerLogin(connection, username, password);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleManagerLogin(SqlConnection connection, string username, string password)
        {
            string query = "SELECT * FROM ManagerView WHERE UseName = @Username AND Passwords = @Password";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string managerID = reader["ManagerID"].ToString();
                        MessageBox.Show($"Welcome, Manager {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password for Manager. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void HandleEmployeeLogin(SqlConnection connection, string username, string password)
        {
            string query = @"
                SELECT e.Position 
                FROM Employees e
                INNER JOIN EmployeeAccounts ea ON e.EmployeeID = ea.EmployeeID
                WHERE ea.UserName = @Username AND ea.Password = @Password";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string position = reader["Position"]?.ToString();

                        if (string.IsNullOrEmpty(position))
                        {
                            MessageBox.Show("Unable to retrieve the position of the employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Kiểm tra vị trí và mở form tương ứng
                        if (position.Equals("Warehouse management", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"Welcome, {position} employee {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form9 form9 = new Form9(); // Mở Form9 cho Warehouse management
                            form9.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Welcome, {position} employee {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form4 form4 = new Form4(); // Mở form khác cho các Employee khác
                            form4.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password for Employee. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void HandleCustomerLogin(SqlConnection connection, string username, string password)
        {
            string query = "SELECT * FROM CustomersAccounts WHERE UserName = @Username AND Password = @Password";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string customerID = reader["CustomerID"]?.ToString() ?? "N/A";
                        MessageBox.Show($"Welcome, Customer {username} (ID: {customerID})!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Pass CustomerID to Form7
                        Form7 form7 = new Form7(customerID);
                        form7.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password for Customer. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void cbbposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị được chọn trong ComboBox
                string selectedPosition = cbbposition.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedPosition))
                {
                    MessageBox.Show("Please select a position.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn kiểm tra số lượng nhân viên có vị trí được chọn
                    string query = "SELECT COUNT(*) FROM Employees WHERE Position = @Position";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Position", selectedPosition);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Hiển thị thông tin dựa trên số lượng nhân viên tìm được
                        if (count > 0)
                        {
                            MessageBox.Show($"There are {count} employees in the position '{selectedPosition}'.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"No employees found for the position '{selectedPosition}'.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
