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
    public partial class frmdanhmucdodung : Form
    {
        public frmdanhmucdodung()
        {
            InitializeComponent();
        }

        private void frmdanhmucdodung_Load(object sender, EventArgs e)
        {
            txtmadodung.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
           LoadDataGridView(); 
        }
        DataTable tbldodung;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT   madodung, dodung FROM dodung";
            tbldodung = Class.ham.GetDataToTable(sql); 
            dgvdodung.DataSource = tbldodung;           
            dgvdodung.Columns[0].HeaderText = "Mã đồ dùng";
            dgvdodung.Columns[1].HeaderText = "Tên đồ dùng";
            dgvdodung.Columns[0].Width = 100;
            dgvdodung.Columns[1].Width = 300;
            dgvdodung.AllowUserToAddRows = false; 
            dgvdodung.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void dgvdodung_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadodung.Focus();
                return;
            }
            if (tbldodung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmadodung.Text = dgvdodung.CurrentRow.Cells["madodung"].Value.ToString();
            txtdodung.Text = dgvdodung.CurrentRow.Cells["dodung"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnboqua_Click(object sender, EventArgs e) {
            ResetValue();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmadodung.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql; 
            if (txtmadodung.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadodung.Focus();
                return;
            }
            if (txtdodung.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdodung.Focus();
                return;
            }
            sql = "Select madodung From dodung where madodung =N'" + txtmadodung
                .Text.Trim() + "'";
            if (Class.ham.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmadodung.Focus();
                return;
            }

            sql = "INSERT INTO dodung VALUES(N'" +
                txtmadodung.Text + "',N'" + txtdodung.Text + "')";
            Class.ham.RunSQL(sql); 
            LoadDataGridView(); 
            ResetValue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmadodung.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResetValue()
        {
            txtmadodung.Text = "";
            txtdodung.Text = "";
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValue(); 
            txtmadodung.Enabled = true; 
            txtdodung.Focus();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldodung.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmadodung.Text == "") 
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtdodung.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn chưa nhập tên đồ dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE dodung SET dodung=N'" +
                txtdodung.Text.ToString() +
                "' WHERE madodung=N'" + txtmadodung.Text + "'";
            Class.ham.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldodung.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmadodung.Text == "") 
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE dodung WHERE madodung=N'" + txtmadodung.Text + "'";
                Class.ham.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void frmdanhmucdodung_Load_1(object sender, EventArgs e)
        {
            txtmadodung.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            LoadDataGridView();
        }

        private void dgvdodung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvdodung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadodung.Focus();
                return;
            }
            if (tbldodung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmadodung.Text = dgvdodung.CurrentRow.Cells["madodung"].Value.ToString();
            txtdodung.Text = dgvdodung.CurrentRow.Cells["dodung"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }
    }
}
