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
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }

        private void btnThongkeSVtheoMH_Click(object sender, EventArgs e)
        {
            ThongkeSVtheomonhoc thongke1 = new ThongkeSVtheomonhoc();
            thongke1.Show();
        }

        private void btndiemtrungbinh_Click(object sender, EventArgs e)
        {
            ThongkeDTBsinhvientheolop thongke2 = new ThongkeDTBsinhvientheolop();
            thongke2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TopSVtheoHockivaNienKhoa thongke3 = new TopSVtheoHockivaNienKhoa();
            thongke3.Show();
        }
    }
}
