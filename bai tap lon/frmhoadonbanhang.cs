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
    public partial class frmhoadonbanhang : Form
    {
        public frmhoadonbanhang()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaHang, b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia,a.ThanhTien FROM ChiTietHDBan AS a, Hang AS b WHERE a.MaHDBan = N'" + txtmahdban.Text + "' AND a.MaHang=b.MaHang";
            tblCTHDB = ham.GetDataToTable(sql);
            dgvhdbanhang.DataSource = tblCTHDB;
            dgvhdbanhang.Columns[0].HeaderText = "Mã hàng";
            dgvhdbanhang.Columns[1].HeaderText = "Tên hàng";
            dgvhdbanhang.Columns[2].HeaderText = "Số lượng";
            dgvhdbanhang.Columns[3].HeaderText = "Đơn giá";
            dgvhdbanhang.Columns[4].HeaderText = "Giảm giá %";
            dgvhdbanhang.Columns[5].HeaderText = "Thành tiền";
            dgvhdbanhang.Columns[0].Width = 80;
            dgvhdbanhang.Columns[1].Width = 130;
            dgvhdbanhang.Columns[2].Width = 80;
            dgvhdbanhang.Columns[3].Width = 90;
            dgvhdbanhang.Columns[4].Width = 90;
            dgvhdbanhang.Columns[5].Width = 90;
            dgvhdbanhang.AllowUserToAddRows = false;
            dgvhdbanhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HDBan WHERE MaHDBan = N'" + txtmahdban.Text + "'";
            txtngayban.Text = ham.ConvertDateTime(ham.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM HDBan WHERE MaHDBan = N'" + txtmahdban.Text + "'";
            cbxmanhanvien.Text = ham.GetFieldValues(str);
            str = "SELECT MaKhach FROM HDBan WHERE MaHDBan = N'" + txtmahdban.Text + "'";
            cbxmakhachhang.Text = ham.GetFieldValues(str);
            str = "SELECT TongTien FROM HDBan WHERE MaHDBan = N'" + txtmahdban.Text + "'";
            txttongtien.Text = ham.GetFieldValues(str);
            
        }
        private void frmhoadonbanhang_Load(object sender, EventArgs e)
        {

            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            txtmahdban.ReadOnly = true;
            txttennhanvien.ReadOnly = true;
            txttenkhachhang.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtdienthoai.ReadOnly = true;
            txttenhang.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtgiamgia.Text = "0";
            txttongtien.Text = "0";
            ham.FillCombo("SELECT MaKhach, TenKhach FROM Khach", cbxmakhachhang, "MaKhach", "MaKhach");
            cbxmakhachhang.SelectedIndex = -1;
            ham.FillCombo("SELECT MaNhanVien, TenNhanVien FROM NhanVien", cbxmanhanvien, "MaNhanVien", "Tenkhach");
            cbxmanhanvien.SelectedIndex = -1;
            ham.FillCombo("SELECT MaHang, TenHang FROM Hang", cbxmahang ,"MaHang", "MaHang");
            cbxmahang.SelectedIndex = -1;
            if (txtmahdban.Text != "")
            {
                LoadInfoHoaDon();
                
            }
            LoadDataGridView();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmahdban.Text = ham.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtmahdban.Text = "";
            txtngayban.Text = DateTime.Now.ToShortDateString();
            cbxmanhanvien.Text = "";
            cbxmakhachhang.Text = "";
            txttongtien.Text = "0";
           
            cbxmahang.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "0";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDBan FROM HDBan WHERE MaHDBan=N'" + txtmahdban.Text + "'";
            if (!ham.CheckKey(sql))
            {
                if (txtngayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtngayban.Focus();
                    return;
                }
                if (cbxmanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxmanhanvien.Focus();
                    return;
                }
                if (cbxmakhachhang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxmakhachhang.Focus();
                    return;
                }
                sql = "INSERT INTO HDBan(MaHDBan, NgayBan, MaNhanVien, MaKhach, TongTien) VALUES (N'" + txtmahdban.Text.Trim() + "','" +
                      ham.ConvertDateTime(txtngayban.Text.Trim()) + "',N'" + cbxmanhanvien.SelectedValue + "',N'" +
                        cbxmakhachhang.SelectedValue + "'," + txttongtien.Text + ")";
                ham.RunSQL(sql);
            }
          
            if (cbxmahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxmahang.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txtgiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgiamgia.Focus();
                return;
            }
            sql = "SELECT MaHang FROM ChiTietHDBan WHERE MaHang=N'" + cbxmahang.SelectedValue + "' AND MaHDBan = N'" + txtmahdban.Text.Trim() + "'";
            if (ham.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbxmahang.Focus();
                return;
            }

            sl = Convert.ToDouble(ham.GetFieldValues("SELECT SoLuong FROM Hang WHERE MaHang = N'" + cbxmahang.SelectedValue + "'"));
            if (Convert.ToDouble(txtsoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            sql = "INSERT INTO ChiTietHDBan(MaHDBan,MaHang,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtmahdban.Text.Trim() + "',N'" + cbxmahang.SelectedValue + "'," + txtsoluong.Text + "," + txtdongia.Text + "," + txtgiamgia.Text + "," + txtthanhtien.Text + ")";
           ham.RunSQL(sql);
            LoadDataGridView();
           
            SLcon = sl - Convert.ToDouble(txtsoluong.Text);
            sql = "UPDATE Hang SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cbxmahang.SelectedValue + "'";
            ham.RunSQL(sql);
          
            tong = Convert.ToDouble(ham.GetFieldValues("SELECT TongTien FROM HDBan WHERE MaHDBan = N'" + txtmahdban.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);
            sql = "UPDATE HDBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + txtmahdban.Text + "'";
            ham.RunSQL(sql);
            txttongtien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btnhuy.Enabled = true;
            btnthem.Enabled = true;
           
        }
        private void ResetValuesHang()
        {
            cbxmahang.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "0";
        }

        private void dgvhdbanhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvhdbanhang_DoubleClick(object sender, EventArgs e)
        {
            
            }

        private void btnhuy_Click(object sender, EventArgs e)
        {

        }

        private void cbxmanhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbxmanhanvien.Text == "")
                txttennhanvien.Text = "";          
            str = "Select TenNhanVien from NhanVien where MaNhanVien =N'" + cbxmanhanvien.SelectedValue + "'";
            txttennhanvien.Text = ham.GetFieldValues(str);
        }

        private void cbxmakhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbxmakhachhang.Text == "")
            {
                txttenkhachhang.Text = "";
                txtdiachi.Text = "";
                txtdienthoai.Text = "";
            }
           
            str = "Select TenKhach from Khach where MaKhach = N'" + cbxmakhachhang.SelectedValue + "'";
            txttenkhachhang.Text = ham.GetFieldValues(str);
            str = "Select DiaChi from Khach where MaKhach = N'" + cbxmakhachhang.SelectedValue + "'";
            txtdiachi.Text = ham.GetFieldValues(str);
            str = "Select DienThoai from Khach where MaKhach= N'" + cbxmakhachhang.SelectedValue + "'";
            txtdienthoai.Text = ham.GetFieldValues(str);
        }

        private void cbxmahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbxmahang.Text == "")
            {
                txttenhang.Text = "";
                txtdongia.Text = "";
            }
          
            str = "SELECT TenHang FROM Hang WHERE MaHang =N'" + cbxmahang.SelectedValue + "'";
            txttenhang.Text = ham.GetFieldValues(str);
            str = "SELECT DonGiaBan FROM Hang WHERE MaHang =N'" + cbxmahang.SelectedValue + "'";
            txtdongia.Text = ham.GetFieldValues(str);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {

            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgiamgia.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {

            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgiamgia.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbxmahdban.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxmahdban.Focus();
                return;
            }
            txtmahdban.Text = cbxmahdban.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            cbxmahdban.SelectedIndex = -1;
        }

        private void cbxmahdban_DropDown(object sender, EventArgs e)
        {
            ham.FillCombo("SELECT MaHDBan FROM HDBan", cbxmahdban, "MaHDBan", "MaHDBan");
            cbxmahdban.SelectedIndex = -1;
        }

        private void btnđóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
