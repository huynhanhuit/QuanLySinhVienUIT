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

namespace QuanLyDiemSinhVien.GUI
{
    public partial class ThongkeDTBsinhvientheolop : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public ThongkeDTBsinhvientheolop()
        {
            InitializeComponent();
            
           
        }
        private void ThongkeDTBsinhvientheolop_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("Select MaLop from Lop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaLop.Items.Add(dt.Rows[i]["MaLop"]);
            }
            conn.Close();
        }
        private void cbbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("select  dt.MaSinhVien,sv.MaLop,sv.HoDem,sv.Ten,SUM((dt.DiemHocPhan *mh.SoTinChi)) as TongDiem,SUM(mh.SoTinChi) as TongSoTinChi,SUM(dt.DiemHocPhan *mh.SoTinChi)/SUM(mh.SoTinChi) as DiemTrungBinh from DiemThi dt, MonHoc mh, SinhVien sv where(sv.MaLop='" + cbbMaLop.Text + "') and dt.MaMonHoc = mh.MaMonHoc and dt.MaSinhVien = sv.MaSinhVien group by sv.Ten, sv.HoDem, dt.MaSinhVien, sv.MaLop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;       
        }
    }
}
