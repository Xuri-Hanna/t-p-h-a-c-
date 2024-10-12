using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_tap_lon
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.ham.Connect();
        }

        private void mnuthoat_Click(object sender, EventArgs e)
        {
            Class.ham.Disconnect();
            Application.Exit();
        }

        private void mnudodung_Click(object sender, EventArgs e)
        {
            frmdanhmucdodung frmdodung = new frmdanhmucdodung(); 
            frmdodung.ShowDialog();
        }

        private void mnunhanvien_Click(object sender, EventArgs e)
        {
            frmdanhmucnhanvein frmnhanvien = new frmdanhmucnhanvein(); //Khởi tạo đối tượng
            frmnhanvien.ShowDialog();
        }

        private void mnuhanghoa_Click(object sender, EventArgs e)
        {
            frmdanhmuchanghoa fr = new frmdanhmuchanghoa();
            fr.ShowDialog();
        }

        private void mnukhachhang_Click(object sender, EventArgs e)
        {
            frmdanhmuckhachdang fr = new frmdanhmuckhachdang();
            fr.ShowDialog();
        }

        private void mnuhoadonban_Click(object sender, EventArgs e)
        {
            frmhoadonbanhang fr = new frmhoadonbanhang();
            fr.ShowDialog();
        }

        private void mnutimhoadon_Click(object sender, EventArgs e)
        {
            frmtimkiemhoadoncs fr = new frmtimkiemhoadoncs();
            fr.ShowDialog();
        }

        private void mnutimhang_Click(object sender, EventArgs e)
        {

            frmdanhmuchanghoa fr = new frmdanhmuchanghoa();
            fr.ShowDialog();
        }

        private void mnutimkhach_Click(object sender, EventArgs e)
        {
            frmdanhmuckhachdang fr = new frmdanhmuckhachdang();
            fr.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
