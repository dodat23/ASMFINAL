using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASMFINAL
{
    public partial class Form5 : Form
    {
        // Chuỗi kết nối đến SQL Server
        private string connectionString = "Server=DESKTOP-P8Q9SHV;Database=ASM2;Trusted_Connection=True;";

        public Form5()
        {
            InitializeComponent();
            // Gọi hàm để tải dữ liệu khi form được khởi tạo
            LoadCustomersAccounts();
        }

        // Hàm tải dữ liệu từ bảng CustomersAccounts và Customers
        private void LoadCustomersAccounts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng CustomersAccounts và Customers
                    string query = @"
                        SELECT 
                            ca.AccountcustomerID, 
                            ca.Username, 
                            ca.Password, 
                            c.CustomerID, 
                            c.Name, 
                            c.Address, 
                            c.PhoneNumber
                        FROM 
                            CustomersAccounts ca
                        INNER JOIN 
                            Customers c
                        ON 
                            ca.CustomerID = c.CustomerID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu lên DataGridView
                        dtgacc.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn hàng nào trong DataGridView chưa
            if (dtgacc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an account to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá trị AccountcustomerID và CustomerID từ hàng được chọn
            string accountId = dtgacc.SelectedRows[0].Cells["AccountcustomerID"].Value?.ToString();
            string customerId = dtgacc.SelectedRows[0].Cells["CustomerID"].Value?.ToString();

            if (string.IsNullOrEmpty(accountId) || string.IsNullOrEmpty(customerId))
            {
                MessageBox.Show("Account ID or Customer ID is invalid or not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận lại với người dùng trước khi xóa
            DialogResult result = MessageBox.Show("Are you sure you want to delete this account and its related customer information?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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
                                // Lệnh xóa trong bảng CustomersAccounts
                                string deleteAccountQuery = "DELETE FROM CustomersAccounts WHERE AccountcustomerID = @AccountcustomerID";
                                using (SqlCommand command = new SqlCommand(deleteAccountQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@AccountcustomerID", accountId);
                                    command.ExecuteNonQuery();
                                }

                                // Lệnh xóa trong bảng Customers
                                string deleteCustomerQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                                using (SqlCommand command = new SqlCommand(deleteCustomerQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@CustomerID", customerId);
                                    command.ExecuteNonQuery();
                                }

                                // Commit giao dịch nếu cả hai lệnh xóa thành công
                                transaction.Commit();

                                // Xóa hàng khỏi DataGridView
                                dtgacc.Rows.RemoveAt(dtgacc.SelectedRows[0].Index);

                                MessageBox.Show("Account and customer information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                // Rollback giao dịch nếu có lỗi
                                transaction.Rollback();
                                throw new Exception("Transaction failed: " + ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị lỗi nếu xảy ra trong quá trình thực thi SQL
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void dtgacc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể xử lý sự kiện này nếu cần
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            // Open Form1 and close Form2
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }
    }
}
