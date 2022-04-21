namespace QuanLyDiemSinhVien.GUI
{
    partial class Menu
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
            this.btnQLSV = new System.Windows.Forms.Button();
            this.txtThongKe = new System.Windows.Forms.Button();
            this.btnQLKhoa = new System.Windows.Forms.Button();
            this.btnQLDiem = new System.Windows.Forms.Button();
            this.btnMonHoc_Lop = new System.Windows.Forms.Button();
            this.btnQLMonHoc = new System.Windows.Forms.Button();
            this.btnQuanLiLop = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBackup1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQLSV
            // 
            this.btnQLSV.BackColor = System.Drawing.SystemColors.Window;
            this.btnQLSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLSV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQLSV.Location = new System.Drawing.Point(49, 24);
            this.btnQLSV.Name = "btnQLSV";
            this.btnQLSV.Size = new System.Drawing.Size(178, 40);
            this.btnQLSV.TabIndex = 0;
            this.btnQLSV.Text = "Quản lí sinh viên";
            this.btnQLSV.UseVisualStyleBackColor = false;
            this.btnQLSV.Click += new System.EventHandler(this.btnQLSV_Click);
            // 
            // txtThongKe
            // 
            this.txtThongKe.BackColor = System.Drawing.SystemColors.Window;
            this.txtThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongKe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtThongKe.Location = new System.Drawing.Point(197, 292);
            this.txtThongKe.Name = "txtThongKe";
            this.txtThongKe.Size = new System.Drawing.Size(178, 40);
            this.txtThongKe.TabIndex = 1;
            this.txtThongKe.Text = "Thống kê";
            this.txtThongKe.UseVisualStyleBackColor = false;
            this.txtThongKe.Click += new System.EventHandler(this.txtThongKe_Click);
            // 
            // btnQLKhoa
            // 
            this.btnQLKhoa.BackColor = System.Drawing.SystemColors.Window;
            this.btnQLKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKhoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQLKhoa.Location = new System.Drawing.Point(49, 128);
            this.btnQLKhoa.Name = "btnQLKhoa";
            this.btnQLKhoa.Size = new System.Drawing.Size(178, 40);
            this.btnQLKhoa.TabIndex = 2;
            this.btnQLKhoa.Text = "Quản lí khoa";
            this.btnQLKhoa.UseVisualStyleBackColor = false;
            this.btnQLKhoa.Click += new System.EventHandler(this.btnQLKhoa_Click);
            // 
            // btnQLDiem
            // 
            this.btnQLDiem.BackColor = System.Drawing.SystemColors.Window;
            this.btnQLDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQLDiem.Location = new System.Drawing.Point(49, 232);
            this.btnQLDiem.Name = "btnQLDiem";
            this.btnQLDiem.Size = new System.Drawing.Size(178, 40);
            this.btnQLDiem.TabIndex = 3;
            this.btnQLDiem.Text = "Quản lí điểm";
            this.btnQLDiem.UseVisualStyleBackColor = false;
            this.btnQLDiem.Click += new System.EventHandler(this.btnQLDiem_Click);
            // 
            // btnMonHoc_Lop
            // 
            this.btnMonHoc_Lop.BackColor = System.Drawing.SystemColors.Window;
            this.btnMonHoc_Lop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonHoc_Lop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMonHoc_Lop.Location = new System.Drawing.Point(561, 24);
            this.btnMonHoc_Lop.Name = "btnMonHoc_Lop";
            this.btnMonHoc_Lop.Size = new System.Drawing.Size(235, 40);
            this.btnMonHoc_Lop.TabIndex = 4;
            this.btnMonHoc_Lop.Text = "Quản lí môn học- lớp";
            this.btnMonHoc_Lop.UseVisualStyleBackColor = false;
            this.btnMonHoc_Lop.Click += new System.EventHandler(this.btnMonHoc_Lop_Click);
            // 
            // btnQLMonHoc
            // 
            this.btnQLMonHoc.BackColor = System.Drawing.SystemColors.Window;
            this.btnQLMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMonHoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQLMonHoc.Location = new System.Drawing.Point(571, 232);
            this.btnQLMonHoc.Name = "btnQLMonHoc";
            this.btnQLMonHoc.Size = new System.Drawing.Size(178, 40);
            this.btnQLMonHoc.TabIndex = 5;
            this.btnQLMonHoc.Text = "Quản lí môn học";
            this.btnQLMonHoc.UseVisualStyleBackColor = false;
            this.btnQLMonHoc.Click += new System.EventHandler(this.btnQLMonHoc_Click);
            // 
            // btnQuanLiLop
            // 
            this.btnQuanLiLop.BackColor = System.Drawing.SystemColors.Window;
            this.btnQuanLiLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLiLop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuanLiLop.Location = new System.Drawing.Point(571, 128);
            this.btnQuanLiLop.Name = "btnQuanLiLop";
            this.btnQuanLiLop.Size = new System.Drawing.Size(178, 40);
            this.btnQuanLiLop.TabIndex = 6;
            this.btnQuanLiLop.Text = "Quản lí lớp";
            this.btnQuanLiLop.UseVisualStyleBackColor = false;
            this.btnQuanLiLop.Click += new System.EventHandler(this.btnQuanLiLop_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Image = global::QuanLyDiemSinhVien.Properties.Resources._465_4651857_hiring_manager_icon_png_transparent_png;
            this.pictureBox2.Location = new System.Drawing.Point(272, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(254, 271);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyDiemSinhVien.Properties.Resources.pexels_mike_424154;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(836, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnBackup1
            // 
            this.btnBackup1.BackColor = System.Drawing.SystemColors.Window;
            this.btnBackup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBackup1.Location = new System.Drawing.Point(405, 292);
            this.btnBackup1.Name = "btnBackup1";
            this.btnBackup1.Size = new System.Drawing.Size(175, 40);
            this.btnBackup1.TabIndex = 10;
            this.btnBackup1.Text = "Sao lưu dữ liệu";
            this.btnBackup1.UseVisualStyleBackColor = false;
            this.btnBackup1.Click += new System.EventHandler(this.btnBackup1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 450);
            this.Controls.Add(this.btnBackup1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnQuanLiLop);
            this.Controls.Add(this.btnQLMonHoc);
            this.Controls.Add(this.btnMonHoc_Lop);
            this.Controls.Add(this.btnQLDiem);
            this.Controls.Add(this.btnQLKhoa);
            this.Controls.Add(this.txtThongKe);
            this.Controls.Add(this.btnQLSV);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQLSV;
        private System.Windows.Forms.Button txtThongKe;
        private System.Windows.Forms.Button btnQLKhoa;
        private System.Windows.Forms.Button btnQLDiem;
        private System.Windows.Forms.Button btnMonHoc_Lop;
        private System.Windows.Forms.Button btnQLMonHoc;
        private System.Windows.Forms.Button btnQuanLiLop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnBackup1;
    }
}