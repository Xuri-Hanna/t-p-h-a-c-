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
    public partial class frmdanhmuchanghoa : Form
    {
        public frmdanhmuchanghoa()
        {
            InitializeComponent();
        }
        DataTable tblH;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from Hang";
            tblH = ham.GetDataToTable(sql);
           dgvhang.DataSource = tblH;
            dgvhang.Columns[0].HeaderText = "Mã hàng";
            dgvhang.Columns[1].HeaderText = "Tên hàng";
            dgvhang.Columns[2].HeaderText = "Đồ dùng";
            dgvhang.Columns[3].HeaderText = "Số lượng";
            dgvhang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvhang.Columns[5].HeaderText = "Đơn giá bán";
            dgvhang.Columns[0].Width = 80;
            dgvhang.Columns[1].Width = 140;
            dgvhang.Columns[2].Width = 80;
            dgvhang.Columns[3].Width = 80;
            dgvhang.Columns[4].Width = 100;
            dgvhang.Columns[5].Width = 100;
            dgvhang.AllowUserToAddRows = false;
            dgvhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtmahang.Text = "";
            txttenhang.Text = "";
            cbxmadodung.Text = "";
            txtsoluong.Text = "0";
            txtdongianhap.Text = "0";
            txtdongiaban.Text = "0";
            txtsoluong.Enabled = true;
            txtdongianhap.Enabled = false;
            txtdongiaban.Enabled = false;
        
        }
        private void frmdanhmuchanghoa_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from dodung";
            txtmahang.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            LoadDataGridView();
            ham.FillCombo(sql, cbxmadodung, "madodung", "tendodung");
            cbxmadodung.SelectedIndex = -1;
            ResetValues();
        }

        private void dgvhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string madodung;
            string sql;
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahang.Text = dgvhang.CurrentRow.Cells["MaHang"].Value.ToString();
            txttenhang.Text = dgvhang.CurrentRow.Cells["TenHang"].Value.ToString();
            madodung = dgvhang.CurrentRow.Cells["MaDoDung"].Value.ToString();
            sql = "SELECT dodung FROM dodung WHERE madodung=N'" + madodung + "'";
            cbxmadodung.Text = ham.GetFieldValues(sql);
            txtsoluong.Text = dgvhang.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtdongianhap.Text = dgvhang.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtdongiaban.Text = dgvhang.CurrentRow.Cells["DonGiaBan"].Value.ToString();          
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmahang.Enabled = true;
            txtmahang.Focus();
            txtsoluong.Enabled = true;
            txtdongianhap.Enabled = true;
            txtdongiaban.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            if (txttenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenhang.Focus();
                return;
            }
            if (cbxmadodung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đồ dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxmadodung.Focus();
                return;
            }
            
            sql = "SELECT MaHang FROM Hang WHERE MaHang=N'" + txtmahang.Text.Trim() + "'";
            if (ham.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            sql = "INSERT INTO Hang(MaHang,TenHang,madodung,SoLuong,DonGiaNhap, DonGiaBan) VALUES(N'"
                + txtmahang.Text.Trim() + "',N'" + txttenhang.Text.Trim() +
                "',N'" + cbxmadodung.SelectedValue.ToString() +
                "'," + txtsoluong.Text.Trim() + "," + txtdongianhap.Text +
                "," + txtdongiaban.Text + ")";

            ham.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmahang.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahang.Focus();
                return;
            }
            if (txttenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenhang.Focus();
                return;
            }
            if (cbxmadodung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đồ dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxmadodung.Focus();
                return;
            }
         
            sql = "UPDATE Hang SET TenHang=N'" + txttenhang.Text.Trim().ToString() +
                "',madodung=N'" + cbxmadodung.SelectedValue.ToString() +
                "',SoLuong=" + txtsoluong.Text +
                " WHERE MaHang=N'" + txtmahang.Text + "'";
            ham.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Hang WHERE MaHang=N'" + txtmahang.Text + "'";
                ham.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnthem.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmahang.Enabled = false;
        
    }

     

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmahang.Text == "") && (txttenhang.Text == "") && (cbxmadodung.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Hang WHERE 1=1";
            if (txtmahang.Text != "")
                sql += " AND MaHang LIKE N'%" + txtmahang.Text + "%'";
            if (txttenhang.Text != "")
                sql += " AND TenHang LIKE N'%" + txttenhang.Text + "%'";
            if (cbxmadodung.Text != "")
                sql += " AND madodung LIKE N'%" + cbxmadodung.SelectedValue + "%'";
            tblH = ham.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvhang.DataSource = tblH;
            ResetValues();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHang,TenHang,madodung,SoLuong,DonGiaNhap,DonGiaBan FROM Hang";
            tblH =ham.GetDataToTable(sql);
            dgvhang.DataSource = tblH;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
