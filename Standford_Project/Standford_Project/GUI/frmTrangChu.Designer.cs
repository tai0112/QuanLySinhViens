namespace Standford_Project
{
    partial class frmTrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuanLySinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChuyenKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPhongThi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemDiemThi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemTraCuu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeThong,
            this.menuNghiepVu,
            this.menuDanhMuc,
            this.menuBaoCao,
            this.menuTroGiup});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // menuHeThong
            // 
            this.menuHeThong.Image = global::Standford_Project.Properties.Resources.Home_2;
            this.menuHeThong.Name = "menuHeThong";
            resources.ApplyResources(this.menuHeThong, "menuHeThong");
            // 
            // menuNghiepVu
            // 
            this.menuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemQuanLySinhVien,
            this.menuItemChuyenKhoa,
            this.menuItemMonHoc,
            this.menuItemPhongThi,
            this.menuItemThemDiemThi,
            this.toolStripSeparator1,
            this.menuItemTraCuu});
            this.menuNghiepVu.Image = global::Standford_Project.Properties.Resources.Group_Idea;
            this.menuNghiepVu.Name = "menuNghiepVu";
            resources.ApplyResources(this.menuNghiepVu, "menuNghiepVu");
            // 
            // menuItemQuanLySinhVien
            // 
            this.menuItemQuanLySinhVien.Image = global::Standford_Project.Properties.Resources._002;
            this.menuItemQuanLySinhVien.Name = "menuItemQuanLySinhVien";
            resources.ApplyResources(this.menuItemQuanLySinhVien, "menuItemQuanLySinhVien");
            this.menuItemQuanLySinhVien.Click += new System.EventHandler(this.menuItemQuanLySinhVien_Click);
            // 
            // menuItemChuyenKhoa
            // 
            this.menuItemChuyenKhoa.Name = "menuItemChuyenKhoa";
            resources.ApplyResources(this.menuItemChuyenKhoa, "menuItemChuyenKhoa");
            this.menuItemChuyenKhoa.Click += new System.EventHandler(this.menuItemChuyenKhoa_Click);
            // 
            // menuItemMonHoc
            // 
            this.menuItemMonHoc.Name = "menuItemMonHoc";
            resources.ApplyResources(this.menuItemMonHoc, "menuItemMonHoc");
            this.menuItemMonHoc.Click += new System.EventHandler(this.menuItemMonHoc_Click);
            // 
            // menuItemPhongThi
            // 
            this.menuItemPhongThi.Name = "menuItemPhongThi";
            resources.ApplyResources(this.menuItemPhongThi, "menuItemPhongThi");
            this.menuItemPhongThi.Click += new System.EventHandler(this.menuItemPhongThi_Click);
            // 
            // menuItemThemDiemThi
            // 
            this.menuItemThemDiemThi.Name = "menuItemThemDiemThi";
            resources.ApplyResources(this.menuItemThemDiemThi, "menuItemThemDiemThi");
            this.menuItemThemDiemThi.Click += new System.EventHandler(this.menuItemThemDiemThi_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // menuItemTraCuu
            // 
            this.menuItemTraCuu.Name = "menuItemTraCuu";
            resources.ApplyResources(this.menuItemTraCuu, "menuItemTraCuu");
            this.menuItemTraCuu.Click += new System.EventHandler(this.menuItemTraCuu_Click);
            // 
            // menuDanhMuc
            // 
            this.menuDanhMuc.Name = "menuDanhMuc";
            resources.ApplyResources(this.menuDanhMuc, "menuDanhMuc");
            // 
            // menuBaoCao
            // 
            this.menuBaoCao.Name = "menuBaoCao";
            resources.ApplyResources(this.menuBaoCao, "menuBaoCao");
            // 
            // menuTroGiup
            // 
            this.menuTroGiup.Name = "menuTroGiup";
            resources.ApplyResources(this.menuTroGiup, "menuTroGiup");
            // 
            // frmTrangChu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTrangChu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem menuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuanLySinhVien;
        private System.Windows.Forms.ToolStripMenuItem menuItemChuyenKhoa;
        private System.Windows.Forms.ToolStripMenuItem menuItemMonHoc;
        private System.Windows.Forms.ToolStripMenuItem menuItemPhongThi;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemDiemThi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemTraCuu;
    }
}

