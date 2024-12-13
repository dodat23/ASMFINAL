using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ASMFINAL
{
    public partial class Form7 : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        private string connectionString = "Data Source=DESKTOP-P8Q9SHV;Initial Catalog=ASM2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private string currentCustomerId;
        public Form7(string customerId)
        {
            InitializeComponent(); // Phải gọi InitializeComponent() trước

            AddQuantityColumn();

            LoadProducts();        // Sau đó mới gọi LoadProducts()
            this.currentCustomerId = customerId;
        }

        // Phương thức để tải dữ liệu lên DataGridView
        private void LoadProducts()
        {
            // Câu lệnh truy vấn SQL
            string query = "SELECT ProductID, ProductName, InventoryQuantity, SellingPrice FROM Products";

            try
            {
                // Tạo kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối

                    // Khởi tạo SqlCommand và SqlDataAdapter
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable(); // Tạo DataTable để chứa dữ liệu
                        adapter.Fill(dataTable);              // Đổ dữ liệu vào DataTable

                        // Kiểm tra DataGridView trước khi gán
                        if (dtgProductsForm7 != null)
                        {
                            dtgProductsForm7.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("DataGridView is not initialized. Please check the design.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu xảy ra vấn đề
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            // Lấy ID từ txtsearch
            string productId = txtsearch.Text.Trim();

            if (string.IsNullOrEmpty(productId))
            {
                MessageBox.Show("Please enter a Product ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL để tìm kiếm sản phẩm theo ID
            string query = "SELECT ProductName, SellingPrice, InventoryQuantity, Descriptions, ProductImage FROM Products WHERE ProductID = @ProductID";

            try
            {
                // Tạo kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối

                    // Tạo SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@ProductID", productId);

                        // Thực thi câu lệnh
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Kiểm tra nếu có dữ liệu trả về
                            {
                                // Đổ dữ liệu vào các TextBox
                                txtname.Text = reader["ProductName"].ToString();
                                txtcost.Text = reader["SellingPrice"].ToString();
                                txtquantity.Text = reader["InventoryQuantity"].ToString();
                                txtdescr.Text = reader["Descriptions"].ToString();

                                // Đọc ảnh từ cơ sở dữ liệu và hiển thị trong PictureBox
                                if (reader["ProductImage"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["ProductImage"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        ptb.Image = Image.FromStream(ms); // Hiển thị ảnh
                                        ptb.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo ảnh vừa khung
                                    }
                                }
                                else
                                {
                                    ptb.Image = null; // Nếu không có ảnh, xóa ảnh hiện tại
                                    MessageBox.Show("No image found for this product.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Product not found. Please check the Product ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Xóa các TextBox và ảnh nếu không tìm thấy
                                txtname.Clear();
                                txtcost.Clear();
                                txtquantity.Clear();
                                txtdescr.Clear();
                                ptb.Image = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu xảy ra vấn đề
                MessageBox.Show($"Error searching for product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddQuantityColumn()
        {
            // Tạo một cột mới kiểu DataGridViewTextBoxColumn
            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "QuantityToBuy"; // Tên cột (dùng trong code)
            quantityColumn.HeaderText = "Quantity To Buy"; // Tiêu đề cột (hiển thị trên giao diện)
            quantityColumn.ValueType = typeof(int); // Kiểu dữ liệu trong cột là số nguyên
            quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa dữ liệu

            // Thêm cột vào cuối DataGridView
            dtgProductsForm7.Columns.Add(quantityColumn);
        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int customerId = int.Parse(currentCustomerId);
                    string customerName = "", customerPhone = "", customerAddress = "";

                    // Lấy thông tin khách hàng
                    string customerQuery = "SELECT Name, PhoneNumber, Address FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlCommand customerCommand = new SqlCommand(customerQuery, connection))
                    {
                        customerCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        using (SqlDataReader reader = customerCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerName = reader["Name"].ToString();
                                customerPhone = reader["PhoneNumber"].ToString();
                                customerAddress = reader["Address"].ToString();
                            }
                        }
                    }

                    // Danh sách các sản phẩm đã mua
                    List<PurchasedProduct> purchasedProducts = new List<PurchasedProduct>();

                    foreach (DataGridViewRow row in dtgProductsForm7.Rows)
                    {
                        if (row.Cells["QuantityToBuy"].Value != null &&
                            int.TryParse(row.Cells["QuantityToBuy"].Value.ToString(), out int quantityToBuy) &&
                            quantityToBuy > 0)
                        {
                            int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                            string productName = row.Cells["ProductName"].Value.ToString();
                            decimal sellingPrice = Convert.ToDecimal(row.Cells["SellingPrice"].Value);
                            int inventoryQuantity = Convert.ToInt32(row.Cells["InventoryQuantity"].Value);

                            if (quantityToBuy > inventoryQuantity)
                            {
                                MessageBox.Show($"Not enough stock for product {productName}.", "Warning");
                                continue;
                            }

                            // Cập nhật tồn kho
                            int newInventoryQuantity = inventoryQuantity - quantityToBuy;
                            decimal totalAmount = sellingPrice * quantityToBuy;

                            string updateQuery = "UPDATE Products SET InventoryQuantity = @NewInventoryQuantity WHERE ProductID = @ProductID";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@NewInventoryQuantity", newInventoryQuantity);
                                updateCommand.Parameters.AddWithValue("@ProductID", productId);
                                updateCommand.ExecuteNonQuery();
                            }

                            // Cập nhật lịch sử mua hàng
                            string insertQuery = "INSERT INTO CustomerPurchaseHistory (CustomerID, ProductID, PurchaseDate, Quantity, TotalAmount) " +
                                                 "VALUES (@CustomerID, @ProductID, @PurchaseDate, @Quantity, @TotalAmount)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CustomerID", customerId);
                                insertCommand.Parameters.AddWithValue("@ProductID", productId);
                                insertCommand.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                                insertCommand.Parameters.AddWithValue("@Quantity", quantityToBuy);
                                insertCommand.Parameters.AddWithValue("@TotalAmount", totalAmount);
                                insertCommand.ExecuteNonQuery();
                            }

                            // Thêm sản phẩm vào danh sách đã mua
                            purchasedProducts.Add(new PurchasedProduct
                            {
                                ProductName = productName,
                                Quantity = quantityToBuy,
                                TotalAmount = totalAmount
                            });
                        }
                    }

                    // Truyền danh sách sản phẩm đến Form8
                    Form8 form8 = new Form8(customerName, customerPhone, customerAddress, purchasedProducts);
                    form8.ShowDialog();
                    this.Close();

                    MessageBox.Show("Purchase completed successfully!", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }


        public class PurchasedProduct
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal TotalAmount { get; set; }
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
    }
}
