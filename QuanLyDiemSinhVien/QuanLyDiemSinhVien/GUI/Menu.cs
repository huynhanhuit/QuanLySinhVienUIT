using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class Menu : Form
    {
        string MaNguoiDung="",TenNguoiDung = "", MatKhau = "", Quyen = "";
       
        public Menu()
        { 
            InitializeComponent();
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            QuanLyKhoa qlkhoa = new QuanLyKhoa();
            qlkhoa.Show();
        }

        private void btnQLDiem_Click(object sender, EventArgs e)
        {
            QuanLyBangDiem qldiem = new QuanLyBangDiem();
            qldiem.Show();
        }

        private void btnMonHoc_Lop_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc_Lop qlmonhoc_lop = new QuanLyMonHoc_Lop();
            qlmonhoc_lop.Show();
        }

        private void btnQLMonHoc_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc qlmonhoc = new QuanLyMonHoc();
            qlmonhoc.Show();
        }

        private void btnQuanLiLop_Click(object sender, EventArgs e)
        {
            QuanLyLop qllop = new QuanLyLop();
            qllop.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                BackupRestore backuprestore = new BackupRestore();
                backuprestore.Show();
                // MessageBox.Show("duoc phep lam");

            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnBackup1_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                BackupRestore backuprestore = new BackupRestore();
                backuprestore.Show();
                // MessageBox.Show("duoc phep lam");

            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Menu(string MaNguoiDung,string TenNguoiDung, string MatKhau, string Quyen)
        {
            InitializeComponent();
            this.MaNguoiDung = MaNguoiDung;
            this.TenNguoiDung = TenNguoiDung;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;

        }

            
        private void btnQLSV_Click(object sender, EventArgs e)
        {
            QuanLySinhVien qlsv = new QuanLySinhVien();
            qlsv.Show();
        }
        private void txtThongKe_Click(object sender, EventArgs e)
        {
           if(Quyen=="admin")
            {
                Thongke thongke = new Thongke();
                thongke.Show();
               // MessageBox.Show("duoc phep lam");

            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
