namespace bai_tap_lon
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.mnufile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuthoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudodung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnunhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhanghoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnukhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkhach = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnufile,
            this.mnudanhmuc,
            this.mnuhoadon,
            this.mnutimkiem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(680, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // mnufile
            // 
            this.mnufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuthoat});
            this.mnufile.Name = "mnufile";
            this.mnufile.Size = new System.Drawing.Size(55, 20);
            this.mnufile.Text = "&Tập tin";
            // 
            // mnuthoat
            // 
            this.mnuthoat.Name = "mnuthoat";
            this.mnuthoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuthoat.Size = new System.Drawing.Size(180, 22);
            this.mnuthoat.Text = "Thoát";
            this.mnuthoat.Click += new System.EventHandler(this.mnuthoat_Click);
            // 
            // mnudanhmuc
            // 
            this.mnudanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnudodung,
            this.mnunhanvien,
            this.mnuhanghoa,
            this.mnukhachhang});
            this.mnudanhmuc.Name = "mnudanhmuc";
            this.mnudanhmuc.Size = new System.Drawing.Size(74, 20);
            this.mnudanhmuc.Text = "&Danh mục";
            // 
            // mnudodung
            // 
            this.mnudodung.Image = ((System.Drawing.Image)(resources.GetObject("mnudodung.Image")));
            this.mnudodung.Name = "mnudodung";
            this.mnudodung.Size = new System.Drawing.Size(180, 22);
            this.mnudodung.Text = "Đồ dùng";
            this.mnudodung.Click += new System.EventHandler(this.mnudodung_Click);
            // 
            // mnunhanvien
            // 
            this.mnunhanvien.Image = ((System.Drawing.Image)(resources.GetObject("mnunhanvien.Image")));
            this.mnunhanvien.Name = "mnunhanvien";
            this.mnunhanvien.Size = new System.Drawing.Size(180, 22);
            this.mnunhanvien.Text = "Nhân viên";
            this.mnunhanvien.Click += new System.EventHandler(this.mnunhanvien_Click);
            // 
            // mnuhanghoa
            // 
            this.mnuhanghoa.Image = ((System.Drawing.Image)(resources.GetObject("mnuhanghoa.Image")));
            this.mnuhanghoa.Name = "mnuhanghoa";
            this.mnuhanghoa.Size = new System.Drawing.Size(180, 22);
            this.mnuhanghoa.Text = "Hàng hóa";
            this.mnuhanghoa.Click += new System.EventHandler(this.mnuhanghoa_Click);
            // 
            // mnukhachhang
            // 
            this.mnukhachhang.Image = ((System.Drawing.Image)(resources.GetObject("mnukhachhang.Image")));
            this.mnukhachhang.Name = "mnukhachhang";
            this.mnukhachhang.Size = new System.Drawing.Size(180, 22);
            this.mnukhachhang.Text = "Khách hàng";
            this.mnukhachhang.Click += new System.EventHandler(this.mnukhachhang_Click);
            // 
            // mnuhoadon
            // 
            this.mnuhoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuhoadonban});
            this.mnuhoadon.Name = "mnuhoadon";
            this.mnuhoadon.Size = new System.Drawing.Size(65, 20);
            this.mnuhoadon.Text = "&Hóa đơn";
            // 
            // mnuhoadonban
            // 
            this.mnuhoadonban.Name = "mnuhoadonban";
            this.mnuhoadonban.Size = new System.Drawing.Size(143, 22);
            this.mnuhoadonban.Text = "Hóa đơn bán";
            this.mnuhoadonban.Click += new System.EventHandler(this.mnuhoadonban_Click);
            // 
            // mnutimkiem
            // 
            this.mnutimkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutimhoadon,
            this.mnutimhang,
            this.mnutimkhach});
            this.mnutimkiem.Name = "mnutimkiem";
            this.mnutimkiem.Size = new System.Drawing.Size(68, 20);
            this.mnutimkiem.Text = "&Tìm kiếm";
            // 
            // mnutimhoadon
            // 
            this.mnutimhoadon.Name = "mnutimhoadon";
            this.mnutimhoadon.Size = new System.Drawing.Size(137, 22);
            this.mnutimhoadon.Text = "Hóa đơn";
            this.mnutimhoadon.Click += new System.EventHandler(this.mnutimhoadon_Click);
            // 
            // mnutimhang
            // 
            this.mnutimhang.Name = "mnutimhang";
            this.mnutimhang.Size = new System.Drawing.Size(137, 22);
            this.mnutimhang.Text = "Hàng";
            this.mnutimhang.Click += new System.EventHandler(this.mnutimhang_Click);
            // 
            // mnutimkhach
            // 
            this.mnutimkhach.Name = "mnutimkhach";
            this.mnutimkhach.Size = new System.Drawing.Size(137, 22);
            this.mnutimkhach.Text = "Khách hàng";
            this.mnutimkhach.Click += new System.EventHandler(this.mnutimkhach_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(151, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lí cửa hàng tạp hóa";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 357);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnufile;
        private System.Windows.Forms.ToolStripMenuItem mnuthoat;
        private System.Windows.Forms.ToolStripMenuItem mnudanhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnudodung;
        private System.Windows.Forms.ToolStripMenuItem mnunhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnuhanghoa;
        private System.Windows.Forms.ToolStripMenuItem mnukhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnutimkiem;
        private System.Windows.Forms.ToolStripMenuItem mnutimhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnutimhang;
        private System.Windows.Forms.ToolStripMenuItem mnutimkhach;
        private System.Windows.Forms.Label label1;
    }
}

