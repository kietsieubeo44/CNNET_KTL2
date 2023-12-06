using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNNET_KTL2
{
    public partial class Form1 : Form
    {
        public static string chuoikn = "Data Source = PC01; Initial Catalog = QLCHS; Integrated Security = True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataGri();
            loadCBMHD();
            loadCBMS();
        }

        private void loadDataGri()
        {
            data dt = new data();
            string sql = "select * from CTHoaDon";
            DataTable db = dt.getDTB(sql);
            dataGridView1.DataSource = db;
        }

        private void loadCBMHD()
        {
            data dt = new data();
            string sql = "select * from HoaDon";
            DataSet db = dt.getDT(sql);

            cboxMHD.DataSource = db.Tables[0];
            cboxMHD.DisplayMember = "MaHD";
        }

        private void loadCBMS()
        {
            data dt = new data();
            string sql = "select * from Sach";
            DataSet db = dt.getDT(sql);

            cboxMS.DataSource = db.Tables[0];
            cboxMS.DisplayMember = "MaSach";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxMHD.Text) || string.IsNullOrEmpty(cboxMS.Text) || string.IsNullOrEmpty(txtDG.Text) || string.IsNullOrEmpty(txtSL.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            data dt = new data();
            string sql = $"Insert into CTHoaDon values (N'{cboxMHD.Text}', '{cboxMS.Text}', '{txtDG.Text}', '{txtSL.Text}')";
            int kq = dt.getNQR(sql);

            if (kq == 0)
            {
                MessageBox.Show("Chưa thêm");
            }
            else
            {
                MessageBox.Show("Thêm thành công");
                loadDataGri(); // Cập nhật lại dữ liệu ngay lập tức
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxMHD.Text))
            {
                MessageBox.Show("Vui lòng chọn Mã Hóa Đơn để xóa.");
                return;
            }

            data dt = new data();
            string sql = $"delete from CTHoaDon where MaHD = '{cboxMHD.Text}'";
            int kq = dt.getNQR(sql);

            if (kq == 0)
            {
                MessageBox.Show("Chưa xóa");
            }
            else
            {
                MessageBox.Show("Đã xóa");
                loadDataGri(); // Cập nhật lại dữ liệu ngay lập tức
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxMHD.Text))
            {
                MessageBox.Show("Vui lòng chọn Mã Hóa Đơn để sửa.");
                return;
            }

            data dt = new data();
            string sql = $"update CTHoaDon set donGia= '{txtDG.Text}', soLuong= '{txtSL.Text}' where MaHD='{cboxMHD.Text}'";
            int kq = dt.getNQR(sql);

            if (kq == 0)
            {
                MessageBox.Show("Chưa sửa");
            }
            else
            {
                MessageBox.Show("Đã sửa thành công!!!");
                loadDataGri(); // Cập nhật lại dữ liệu ngay lập tức
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboxMHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

        }

private void btnLuu_Click(object sender, EventArgs e)
{
    // Kiểm tra xem đã chọn Mã Hóa Đơn và Mã Sách chưa
    if (string.IsNullOrEmpty(cboxMHD.Text) || string.IsNullOrEmpty(cboxMS.Text))
    {
        MessageBox.Show("Vui lòng chọn Mã Hóa Đơn và Mã Sách trước khi lưu.");
        return;
    }

    // Kiểm tra xem giá trị đơn giá và số lượng có được nhập hay không
    if (string.IsNullOrEmpty(txtDG.Text) || string.IsNullOrEmpty(txtSL.Text))
    {
        MessageBox.Show("Vui lòng nhập đơn giá và số lượng trước khi lưu.");
        return;
    }

    // Thực hiện lưu dữ liệu vào CSDL hoặc các hành động khác tùy thuộc vào yêu cầu của bạn
    data dt = new data();
    string sql = $"INSERT INTO CTHoaDon VALUES (N'{cboxMHD.Text}', '{cboxMS.Text}', '{txtDG.Text}', '{txtSL.Text}')";
    int kq = dt.getNQR(sql);

    if (kq == 0)
    {
        MessageBox.Show("Chưa lưu được dữ liệu.");
    }
    else
    {
        MessageBox.Show("Đã lưu dữ liệu thành công.");

        // Cập nhật lại dữ liệu ngay lập tức sau khi lưu
        loadDataGri();
    }
}

    }
}
