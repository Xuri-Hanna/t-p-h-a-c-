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
    public partial class frmtimkiemhoadoncs : Form
    {
        public frmtimkiemhoadoncs()
        {
            InitializeComponent();
        }
        DataTable tblHDB;
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtmahdban.Focus();
        }
        private void frmtimkiemhoadoncs_Load(object sender, EventArgs e)
        {
            ResetValues();
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmahdban.Text == "") && (txtthang.Text == "") && (txtnam.Text == "") &&
               (txtmanhanvien.Text == "") && (txtmakhachhang.Text == "") &&
               (txttongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HDBan WHERE 1=1";
            if (txtmahdban.Text != "")
                sql = sql + " AND MaHDBan Like N'%" + txtmahdban.Text + "%'";
            if (txtthang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtthang.Text;
            if (txtnam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtnam.Text;
            if (txtmanhanvien.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + txtmanhanvien.Text + "%'";
            if (txtmakhachhang.Text != "")
                sql = sql + " AND MaKhach Like N'%" + txtmakhachhang.Text + "%'";
            if (txttongtien.Text != "")
                sql = sql + " AND TongTien <=" + txttongtien.Text;
            tblHDB = ham.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = tblHDB;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
           dataGridView1.Columns[0].HeaderText = "Mã HĐB";
            dataGridView1.Columns[1].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[2].HeaderText = "Ngày bán";
            dataGridView1.Columns[3].HeaderText = "Mã khách";
            dataGridView1.Columns[4].HeaderText = "Tổng tiền";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetValues();
        dataGridView1.DataSource = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
