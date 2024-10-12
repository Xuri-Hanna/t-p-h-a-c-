using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using bai_tap_lon.Class;


namespace bai_tap_lon
{
    public partial class frmdanhmucnhanvein : Form
    {
        public frmdanhmucnhanvein()
        {
            InitializeComponent();
        }
        DataTable tblNV;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROm nhanvien";
            tblNV = ham.GetDataToTable(sql);
           dgvnhanvien.DataSource = tblNV;
            dgvnhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgvnhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgvnhanvien.Columns[2].HeaderText = "Giới tính";
            dgvnhanvien.Columns[3].HeaderText = "Địa chỉ";
            dgvnhanvien.Columns[4].HeaderText = "Điện thoại";
            dgvnhanvien.Columns[5].HeaderText = "Ngày sinh";
            dgvnhanvien.Columns[0].Width = 100;
            dgvnhanvien.Columns[1].Width = 150;
            dgvnhanvien.Columns[2].Width = 100;
            dgvnhanvien.Columns[3].Width = 150;
            dgvnhanvien.Columns[4].Width = 100;
            dgvnhanvien.Columns[5].Width = 100;
            dgvnhanvien.AllowUserToAddRows = false;
           // dgvnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvnhanvien_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanhanvien.Text = dgvnhanvien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txttennhanvien.Text = dgvnhanvien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (dgvnhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chkgioitinh.Checked = true;
            else chkgioitinh.Checked = false;
            txtdiachi.Text = dgvnhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
           txtdienthoai.Text = dgvnhanvien.CurrentRow.Cells["DienThoai"].Value.ToString();
           mtbngaysinh.Text = dgvnhanvien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            
        }
        private void frmdanhmucnhanvein_Load(object sender, EventArgs e)
        {
            txtmanhanvien.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            LoadDataGridView();
        }

        private void ResetValues()
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            chkgioitinh.Checked = false;
            txtdiachi.Text = "";
            mtbngaysinh.Text = "";
            txtdienthoai.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmanhanvien.Enabled = true;
            txtmanhanvien.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtmanhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtdienthoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            if (mtbngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbngaysinh.Focus();
                return;
            }
           
            if (chkgioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT MaNhanVien FROM nhanvien WHERE MaNhanVien=N'" + txtmanhanvien.Text.Trim() + "'";
            if (ham.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                txttennhanvien.Text = "";
                return;
            }
            sql = "INSERT INTO nhanvien(MaNhanVien,TenNhanVien,GioiTinh, DiaChi,DienThoai, NgaySinh) VALUES (N'" + txtmanhanvien.Text.Trim() + "',N'" + txttennhanvien.Text.Trim() + "',N'" + gt + "',N'" + txtdiachi.Text.Trim() + "','" + txtdienthoai.Text + "','" + ham.ConvertDateTime(mtbngaysinh.Text) + "')";
            ham.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtmanhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtdienthoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            if (mtbngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbngaysinh.Focus();
                return;
            }

            if (chkgioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE nhanvien SET  TenNhanVien=N'" + txttennhanvien.Text.Trim().ToString() +
                    "',DiaChi=N'" + txtdiachi.Text.Trim().ToString() +
                    "',DienThoai='" + txtdienthoai.Text.ToString() + "',GioiTinh=N'" + gt +
                    "',NgaySinh='" + ham.ConvertDateTime(mtbngaysinh.Text) +
                    "' WHERE MaNhanVien=N'" + txtmanhanvien.Text + "'";
            ham.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE nhanvien WHERE MaNhanVien=N'" + txtmanhanvien.Text + "'";
                ham.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
                ResetValues();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmdanhmucnhanvein_Load_1(object sender, EventArgs e)
        {
            txtmanhanvien.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            LoadDataGridView();
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanhanvien.Text = dgvnhanvien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txttennhanvien.Text = dgvnhanvien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (dgvnhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chkgioitinh.Checked = true;
            else chkgioitinh.Checked = false;
            txtdiachi.Text = dgvnhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtdienthoai.Text = dgvnhanvien.CurrentRow.Cells["DienThoai"].Value.ToString();
            mtbngaysinh.Text = dgvnhanvien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }
    }
}
