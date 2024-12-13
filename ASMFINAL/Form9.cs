using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ASMFINAL
{
    public partial class Form9 : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        private string connectionString = "Data Source=DESKTOP-P8Q9SHV;Initial Catalog=ASM2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải dữ liệu lên DataGridView khi form load
            LoadCustomerPurchaseHistory();
        }

        private void LoadCustomerPurchaseHistory()
        {
            string query = "SELECT * FROM CustomerPurchaseHistory"; // Lấy tất cả các cột trong bảng

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Gán dữ liệu vào DataGridView
                        dtgpurchase.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncal_Click(object sender, EventArgs e)
        {
            // Đặt lại giá trị ban đầu cho các TextBox
            txttotal.Clear();
            txtprofit.Clear();
            txtprin.Clear();
            txttotalrevenue.Clear();

            // Xác định tập các dòng cần tính toán
            var rowsToCalculate = dtgpurchase.SelectedRows.Count > 0
                ? dtgpurchase.SelectedRows.Cast<DataGridViewRow>() // Nếu có dòng được chọn, chỉ lấy các dòng được chọn
                : dtgpurchase.Rows.Cast<DataGridViewRow>(); // Nếu không có dòng nào được chọn, lấy tất cả các dòng

            int totalQuantity = 0; // Tổng số sản phẩm đã bán
            decimal totalRevenue = 0; // Tổng doanh thu
            decimal totalAmount = 0; // Tổng tiền sản phẩm đã bán ra

            // Duyệt qua các dòng trong tập đã xác định
            foreach (DataGridViewRow row in rowsToCalculate)
            {
                if (row.Cells["Quantity"].Value != null && row.Cells["TotalAmount"].Value != null)
                {
                    try
                    {
                        // Lấy số lượng sản phẩm và tổng tiền
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal rowTotalAmount = Convert.ToDecimal(row.Cells["TotalAmount"].Value);

                        // Cộng dồn số lượng sản phẩm đã bán
                        totalQuantity += quantity;

                        // Cộng dồn tổng tiền sản phẩm
                        totalAmount += rowTotalAmount;

                        // Tính tổng doanh thu (số lượng nhân giá trị)
                        totalRevenue += rowTotalAmount;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Tính lợi nhuận (35% của tổng doanh thu)
            decimal profit = totalRevenue * 0.35m;

            // Tính tiền gốc (tổng tiền sau khi trừ lợi nhuận)
            decimal principal = totalRevenue - profit;

            // Hiển thị kết quả
            txttotal.Text = totalQuantity.ToString(); // Tổng số sản phẩm đã bán
            txttotalrevenue.Text = totalAmount.ToString("C", new System.Globalization.CultureInfo("en-US")); // Tổng tiền sản phẩm đã bán ra
            txtprofit.Text = profit.ToString("C", new System.Globalization.CultureInfo("en-US")); // Lợi nhuận dưới dạng USD
            txtprin.Text = principal.ToString("C", new System.Globalization.CultureInfo("en-US")); // Tiền gốc dưới dạng USD
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
