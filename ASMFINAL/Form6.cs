using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ASMFINAL
{
    public partial class Form6 : Form
    {
        private string connectionString = "Server=DESKTOP-P8Q9SHV;Database=ASM2;Trusted_Connection=True;";
        public Form6()
        {
            InitializeComponent();


            dtgemployee.CellClick += dtgemployee_CellClick; // Đăng ký sự kiện CellClick
            LoadEmployees();
        }

        private void dtgemployee_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy chỉ số dòng đã chọn
                int selectedRowIndex = e.RowIndex;

                // Lấy dữ liệu từ các ô của dòng được chọn
                txtID.Text = dtgemployee.Rows[selectedRowIndex].Cells["EmployeeID"].Value.ToString();
                txtname.Text = dtgemployee.Rows[selectedRowIndex].Cells["EmployeeName"].Value.ToString();
                txtposition.Text = dtgemployee.Rows[selectedRowIndex].Cells["Position"].Value.ToString();
                txtuser.Text = dtgemployee.Rows[selectedRowIndex].Cells["Username"].Value.ToString();
                txtpass.Text = dtgemployee.Rows[selectedRowIndex].Cells["Password"].Value.ToString();
            }
        }

        private void LoadEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Truy vấn dữ liệu từ hai bảng Employee và EmployeeAccount
                    string query = @"
                        SELECT 
                            e.EmployeeID, 
                            e.EmployeeName, 
                            e.Position, 
                            ea.AccountID,
                            ea.Username, 
                            ea.Password
                        FROM 
                            Employees e
                        INNER JOIN 
                            EmployeeAccounts ea
                        ON 
                            e.EmployeeID = ea.EmployeeID";

                    // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu lên DataGridView
                        dtgemployee.DataSource = dataTable;
                    }
                }
                catch (SqlException ex)
                {
                    // Hiển thị lỗi nếu kết nối SQL gặp vấn đề
                    MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi khác
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1Abtnadd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string employeeID = txtID.Text.Trim();
            string employeeName = txtname.Text.Trim();
            string position = txtposition.Text.Trim();
            string username = txtuser.Text.Trim();
            string password = txtpass.Text.Trim();

            // Kiểm tra xem các TextBox có trống hay không
            if (string.IsNullOrEmpty(employeeID) || string.IsNullOrEmpty(employeeName) ||
                string.IsNullOrEmpty(position) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Bắt đầu một giao dịch để đảm bảo tính toàn vẹn
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Lưu vào bảng Employee
                            string insertEmployeeQuery = @"
                                INSERT INTO Employees (EmployeeID, EmployeeName, Position)
                                VALUES (@EmployeeID, @EmployeeName, @Position)";
                            using (SqlCommand command = new SqlCommand(insertEmployeeQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                                command.Parameters.AddWithValue("@Position", position);
                                command.ExecuteNonQuery();
                            }

                            // Lưu vào bảng EmployeeAccount
                            string insertEmployeeAccountQuery = @"
                                INSERT INTO EmployeeAccounts (EmployeeID, Username, Password)
                                VALUES (@EmployeeID, @Username, @Password)";
                            using (SqlCommand command = new SqlCommand(insertEmployeeAccountQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                                command.Parameters.AddWithValue("@Username", username);
                                command.Parameters.AddWithValue("@Password", password);
                                command.ExecuteNonQuery();

                            }

                            // Commit giao dịch
                            transaction.Commit();

                            MessageBox.Show("Employee and account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Xóa dữ liệu trong TextBox sau khi thêm thành công
                            txtID.Clear();
                            txtname.Clear();
                            txtposition.Clear();
                            txtuser.Clear();
                            txtpass.Clear();
                        }
                        catch (Exception ex)
                        {
                            // Rollback giao dịch nếu xảy ra lỗi
                            transaction.Rollback();
                            MessageBox.Show("Error while adding data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu không kết nối được
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            // Sau khi lưu thành công, gọi lại LoadEmployees để cập nhật DataGridView
            LoadEmployees();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string employeeID = txtID.Text.Trim();
            string employeeName = txtname.Text.Trim();
            string position = txtposition.Text.Trim();
            string username = txtuser.Text.Trim();
            string password = txtpass.Text.Trim();

            // Kiểm tra xem các TextBox có trống hay không
            if (string.IsNullOrEmpty(employeeID) || string.IsNullOrEmpty(employeeName) ||
                string.IsNullOrEmpty(position) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Bắt đầu giao dịch
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Cập nhật thông tin nhân viên trong bảng Employees
                            string updateEmployeeQuery = @"
                        UPDATE Employees
                        SET EmployeeName = @EmployeeName, Position = @Position
                        WHERE EmployeeID = @EmployeeID";
                            using (SqlCommand command = new SqlCommand(updateEmployeeQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                                command.Parameters.AddWithValue("@Position", position);
                                command.ExecuteNonQuery();
                            }

                            // Cập nhật thông tin tài khoản trong bảng EmployeeAccounts
                            string updateEmployeeAccountQuery = @"
                        UPDATE EmployeeAccounts
                        SET Username = @Username, Password = @Password
                        WHERE EmployeeID = @EmployeeID";
                            using (SqlCommand command = new SqlCommand(updateEmployeeAccountQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                                command.Parameters.AddWithValue("@Username", username);
                                command.Parameters.AddWithValue("@Password", password);
                                command.ExecuteNonQuery();
                            }

                            // Commit giao dịch
                            transaction.Commit();

                            MessageBox.Show("Employee information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Gọi lại LoadEmployees để cập nhật DataGridView
                            LoadEmployees();
                        }
                        catch (Exception ex)
                        {
                            // Rollback nếu xảy ra lỗi
                            transaction.Rollback();
                            MessageBox.Show("Error while updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi kết nối
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgemployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Lấy EmployeeID từ DataGridView khi người dùng chọn dòng cần xóa
            int selectedRowIndex = dtgemployee.SelectedCells[0].RowIndex;
            if (selectedRowIndex >= 0)
            {
                string employeeID = dtgemployee.Rows[selectedRowIndex].Cells["EmployeeID"].Value.ToString();

                // Hỏi người dùng có chắc chắn muốn xóa không
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            // Mở kết nối
                            connection.Open();

                            // Bắt đầu giao dịch để đảm bảo tính toàn vẹn dữ liệu
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    // Xóa thông tin trong bảng EmployeeAccounts (có thể không cần xóa nếu FK là ON DELETE CASCADE)
                                    string deleteEmployeeAccountQuery = @"
                                DELETE FROM EmployeeAccounts
                                WHERE EmployeeID = @EmployeeID";
                                    using (SqlCommand command = new SqlCommand(deleteEmployeeAccountQuery, connection, transaction))
                                    {
                                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                                        command.ExecuteNonQuery();
                                    }

                                    // Xóa thông tin trong bảng Employees
                                    string deleteEmployeeQuery = @"
                                DELETE FROM Employees
                                WHERE EmployeeID = @EmployeeID";
                                    using (SqlCommand command = new SqlCommand(deleteEmployeeQuery, connection, transaction))
                                    {
                                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                                        command.ExecuteNonQuery();
                                    }

                                    // Commit giao dịch
                                    transaction.Commit();

                                    // Hiển thị thông báo thành công
                                    MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Cập nhật lại DataGridView
                                    LoadEmployees();
                                }
                                catch (Exception ex)
                                {
                                    // Rollback nếu có lỗi xảy ra
                                    transaction.Rollback();
                                    MessageBox.Show("Error while deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Hiển thị lỗi kết nối
                            MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        
    }
}
