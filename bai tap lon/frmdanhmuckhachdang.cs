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
    public partial class frmdanhmuckhachdang : Form
    {
        public frmdanhmuckhachdang()
        {
            InitializeComponent();
        }
        DataTable tblKH;

        private void label5_Click(object sender, EventArgs e)
        {

        }
     
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from khach";
            tblKH = ham.GetDataToTable(sql); 
            dgvkhachhang.DataSource = tblKH;
            dgvkhachhang.Columns[0].HeaderText = "Mã khách";
            dgvkhachhang.Columns[1].HeaderText = "Tên khách";
            dgvkhachhang.Columns[2].HeaderText = "Địa chỉ";
            dgvkhachhang.Columns[3].HeaderText = "Điện thoại";
            dgvkhachhang.Columns[0].Width = 100;
            dgvkhachhang.Columns[1].Width = 150;
            dgvkhachhang.Columns[2].Width = 150;
            dgvkhachhang.Columns[3].Width = 150;
            dgvkhachhang.AllowUserToAddRows = false;
            dgvkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frmdanhmuckhachdang_Load(object sender, EventArgs e)
        {
            txtmakhach.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            LoadDataGridView();
        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhach.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmakhach.Text = dgvkhachhang.CurrentRow.Cells["MaKhach"].Value.ToString();
            txttenkhach.Text = dgvkhachhang.CurrentRow.Cells["TenKhach"].Value.ToString();
            txtdiachi.Text = dgvkhachhang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtdienthoai.Text = dgvkhachhang.CurrentRow.Cells["DienThoai"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }
        private void ResetValues()
        {
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            txtdiachi.Text = "";
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
            txtmakhach.Enabled = true;
            txtmakhach.Focus();

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhach.Focus();
                return;
            }
            if (txttenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkhach.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (txtdienthoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdienthoai.Focus();
                return;
            }
            
            sql = "SELECT MaKhach FROM Khach WHERE MaKhach=N'" + txtmakhach.Text.Trim() + "'";
            if (ham.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhach.Focus();
                return;
            }
           
            sql = "INSERT INTO Khach VALUES (N'" + txtmakhach.Text.Trim() +
                "',N'" + txttenkhach.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + txtdienthoai.Text + "')";
            ham.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmakhach.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkhach.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (txtdienthoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdienthoai.Focus();
                return;
            }
            sql = "UPDATE Khach SET TenKhach=N'" + txttenkhach.Text.Trim().ToString() + "',DiaChi=N'" +
                txtdiachi.Text.Trim().ToString() + "',DienThoai='" + txtdienthoai.Text.ToString() +
                "' WHERE MaKhach=N'" + txtmakhach.Text + "'";
         ham.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Khach WHERE MaKhach=N'" + txtmakhach.Text + "'";
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
            txtmakhach.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
