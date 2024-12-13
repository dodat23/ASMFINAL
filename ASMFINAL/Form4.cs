using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASMFINAL
{
    public partial class Form4 : Form
    {
        // Chuỗi kết nối đến SQL Server
        private string connectionString = "Server=DESKTOP-P8Q9SHV;Database=ASM2;Trusted_Connection=True;";
        private object selectedRow;

        public Form4()
        {
            InitializeComponent();

            // Thiết lập các cột cho DataGridView
            dtgproduct.ColumnCount = 5;
            dtgproduct.Columns[0].Name = "ProductID";
            dtgproduct.Columns[1].Name = "ProductName";
            dtgproduct.Columns[2].Name = "SellingPrice";
            dtgproduct.Columns[3].Name = "InventoryQuantity";
            dtgproduct.Columns[4].Name = "Descriptions";

            // Thêm cột ảnh vào DataGridView
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ProductImage";
            imageColumn.HeaderText = "Product Image";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Hiển thị ảnh với chế độ zoom vừa khung
            dtgproduct.Columns.Add(imageColumn);

            // Thiết lập PictureBox để hiển thị ảnh từ trung tâm
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string name = txtname.Text;
            string cost = txtcost.Text;
            string quantity = txtquantity.Text;
            string description = txtdescr.Text;

            // Kiểm tra xem ảnh đã được chọn chưa
            if (pictureBox1.Image == null || pictureBox1.Tag == null)
            {
                MessageBox.Show("Please select an image!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu ảnh dưới dạng byte[]
            byte[] image = File.ReadAllBytes(pictureBox1.Tag.ToString());

            // Kiểm tra xem tất cả các ô có được điền không
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cost) ||
                string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO Products (ProductName, SellingPrice, InventoryQuantity, Descriptions, ProductImage) 
                             VALUES (@ProductName, @SellingPrice, @InventoryQuantity, @Descriptions, @ProductImage);
                             SELECT SCOPE_IDENTITY();"; // Lấy ProductID vừa được tạo

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", name);
                        cmd.Parameters.AddWithValue("@SellingPrice", cost);
                        cmd.Parameters.AddWithValue("@InventoryQuantity", quantity);
                        cmd.Parameters.AddWithValue("@Descriptions", description);
                        cmd.Parameters.AddWithValue("@ProductImage", image);

                        // Lấy ProductID mới được tạo
                        int newProductId = Convert.ToInt32(cmd.ExecuteScalar());

                        MessageBox.Show("Product added successfully to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Thêm hàng mới vào DataGridView
                        string[] row = new string[] { newProductId.ToString(), name, cost, quantity, description };
                        dtgproduct.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Xóa trắng các TextBox và PictureBox sau khi thêm xong
            txtname.Clear();
            txtcost.Clear();
            txtquantity.Clear();
            txtdescr.Clear();
            pictureBox1.Image = null;
            pictureBox1.Tag = null;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dtgproduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dtgproduct.SelectedRows[0].Cells["ProductID"].Value.ToString(), out int productId))
            {
                MessageBox.Show("Invalid ProductID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtcost.Text, out decimal cost))
            {
                MessageBox.Show("Please enter a valid selling price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtquantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = txtname.Text;
            string description = txtdescr.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imageData = null;
            if (pictureBox1.Image != null && pictureBox1.Tag != null)
            {
                imageData = File.ReadAllBytes(pictureBox1.Tag.ToString());
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = imageData != null ?
                        @"UPDATE Products 
                  SET ProductName = @ProductName, SellingPrice = @SellingPrice, 
                      InventoryQuantity = @InventoryQuantity, Descriptions = @Descriptions, 
                      ProductImage = @ProductImage
                  WHERE ProductID = @ProductID" :
                        @"UPDATE Products 
                  SET ProductName = @ProductName, SellingPrice = @SellingPrice, 
                      InventoryQuantity = @InventoryQuantity, Descriptions = @Descriptions
                  WHERE ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@ProductName", name);
                        cmd.Parameters.AddWithValue("@SellingPrice", cost);
                        cmd.Parameters.AddWithValue("@InventoryQuantity", quantity);
                        cmd.Parameters.AddWithValue("@Descriptions", description);

                        if (imageData != null)
                        {
                            cmd.Parameters.AddWithValue("@ProductImage", imageData);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DataGridViewRow selectedRow = dtgproduct.SelectedRows[0];
                            selectedRow.Cells["ProductName"].Value = name;
                            selectedRow.Cells["SellingPrice"].Value = cost;
                            selectedRow.Cells["InventoryQuantity"].Value = quantity;
                            selectedRow.Cells["Descriptions"].Value = description;

                            if (imageData != null)
                            {
                                selectedRow.Cells["ProductImage"].Value = Image.FromStream(new MemoryStream(imageData));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please check the ProductID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            txtname.Clear();
            txtcost.Clear();
            txtquantity.Clear();
            txtdescr.Clear();
            pictureBox1.Image = null;
            pictureBox1.Tag = null;
        }


        private void dtgproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng click vào hàng hợp lệ
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dtgproduct.Rows[e.RowIndex];

                dtgproduct.SelectedRows[0].Cells["ProductID"].Value.ToString();

                // Gán giá trị từ DataGridView vào các TextBox
                txtname.Text = row.Cells["ProductName"].Value?.ToString();
                txtcost.Text = row.Cells["SellingPrice"].Value?.ToString();
                txtquantity.Text = row.Cells["InventoryQuantity"].Value?.ToString();
                txtdescr.Text = row.Cells["Descriptions"].Value?.ToString();

                // Lấy ảnh từ DataGridView và hiển thị lên PictureBox
                if (row.Cells["ProductImage"].Value != null && row.Cells["ProductImage"].Value is byte[] imageData)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms); // Hiển thị ảnh lên PictureBox
                    }
                }
                else
                {
                    pictureBox1.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (dtgproduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ProductID từ dòng được chọn
            string productId = dtgproduct.SelectedRows[0].Cells["ProductID"].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa trong SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM Products WHERE ProductID = @ProductID";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", productId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Xóa dòng trong DataGridView
                                dtgproduct.Rows.RemoveAt(dtgproduct.SelectedRows[0].Index);
                            }
                            else
                            {
                                MessageBox.Show("Delete failed. Please check the ProductID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnchoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.Tag = openFileDialog.FileName; // Lưu đường dẫn ảnh để xử lý sau
            }

        }

        private void btnup_Click(object sender, EventArgs e)
        {
            // Xóa các hàng cũ trong DataGridView để tránh bị lặp dữ liệu
            dtgproduct.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ProductID, ProductName, SellingPrice, InventoryQuantity, Descriptions, ProductImage FROM Products";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Lấy dữ liệu từng cột
                                string productId = reader["ProductID"].ToString();
                                string name = reader["ProductName"].ToString();
                                string cost = reader["SellingPrice"].ToString();
                                string quantity = reader["InventoryQuantity"].ToString();
                                string description = reader["Descriptions"].ToString();

                                // Lấy dữ liệu ảnh (nếu có)
                                Image productImage = null;
                                if (reader["ProductImage"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["ProductImage"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        productImage = Image.FromStream(ms);
                                    }
                                }

                                // Thêm dữ liệu vào DataGridView
                                int rowIndex = dtgproduct.Rows.Add(); // Thêm hàng mới và lấy chỉ số
                                DataGridViewRow row = dtgproduct.Rows[rowIndex];

                                row.Cells["ProductID"].Value = productId;
                                row.Cells["ProductName"].Value = name;
                                row.Cells["SellingPrice"].Value = cost;
                                row.Cells["InventoryQuantity"].Value = quantity;
                                row.Cells["Descriptions"].Value = description;

                                if (productImage != null)
                                {
                                    row.Cells["ProductImage"].Value = productImage; // Gán ảnh vào cột ProductImage
                                }
                            }
                        }
                    }

                    MessageBox.Show("Data loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dtgproduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}