using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ASMFINAL.Form7;

namespace ASMFINAL
{
    public partial class Form8 : Form
    {
        private string currentCustomerId; // Biến lưu customerId

        // Constructor nhận thông tin hóa đơn từ Form7
        public Form8(string name, string phone, string address, List<PurchasedProduct> purchasedProducts)
        {
            InitializeComponent();

            // Gán thông tin khách hàng
            txtname.Text = name;
            txtphone.Text = phone;
            txtaddress.Text = address;

            // Khởi tạo chuỗi để chứa tên sản phẩm và các giá trị tổng
            string productNames = "";
            decimal totalAmount = 0; // Biến để cộng tổng tiền
            int totalQuantity = 0; // Biến để cộng tổng số lượng

            // Duyệt qua tất cả các sản phẩm đã mua
            foreach (var product in purchasedProducts)
            {
                // Thêm tên sản phẩm vào chuỗi productNames, ngăn cách bằng dấu phẩy
                productNames += $"{product.ProductName}, ";

                // Cộng dồn tổng số lượng
                totalQuantity += product.Quantity;

                // Cộng dồn tổng tiền
                totalAmount += product.TotalAmount;
            }

            // Cắt bỏ dấu phẩy thừa ở cuối danh sách tên sản phẩm
            productNames = productNames.TrimEnd(',', ' ');

            // Gán các chuỗi vào các TextBox tương ứng
            txtproduct.Text = productNames; // Tên sản phẩm vào TextBox txtproduct
            txtquantity.Text = totalQuantity.ToString();  // Tổng số lượng vào TextBox txtquantity
            txtcost.Text = totalAmount.ToString("$#,0.00"); // Tổng tiền vào TextBox txtcost

            // Hiển thị ngày giờ hiện tại vào txtdate
            txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); // Định dạng ngày giờ
        }

        // Xử lý sự kiện nút Return
        private void btnreturn_Click(object sender, EventArgs e)
        {
            // Tạo instance của Form7 và truyền customerId
            Form7 form7 = new Form7(currentCustomerId);

            // Hiển thị Form7
            form7.Show();

            // Đóng Form8
            this.Close();
        }
    }
}
