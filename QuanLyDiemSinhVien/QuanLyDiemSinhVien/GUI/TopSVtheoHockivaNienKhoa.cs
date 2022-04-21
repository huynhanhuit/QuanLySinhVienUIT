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
    public partial class TopSVtheoHockivaNienKhoa : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public TopSVtheoHockivaNienKhoa()
        {

            InitializeComponent();
        }
        
        private void TopSVtheoHockivaNienKhoa_Load(object sender, EventArgs e)
        {
            load();
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Select distinct Hocky,NienKhoa from Monhoc_Lop  ", conn);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("Select distinct Hocky from Monhoc_Lop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbHocKi.Items.Add(dt.Rows[i]["Hocky"]);

            }
            conn.Close();
            //SqlDataReader da = cmd.ExecuteReader();
            //while (da.Read())
            //{
            //  cbbHocKi.Text = da.GetValue(0).ToString();
            //cbbNienkhoa.Text = da.GetValue(1).ToString();
            // }
            //conn.Close();
        }
        private void load()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("Select distinct NienKhoa from Monhoc_Lop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbNienkhoa.Items.Add(dt.Rows[i]["NienKhoa"]);
            }
            conn.Close();

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("select Top(3) dt.MaSinhVien,sv.MaLop,sv.HoDem,sv.Ten,SUM((dt.DiemHocPhan *mh.SoTinChi)) as TongDiem,SUM(mh.SoTinChi) as TongSoTinChi,SUM(dt.DiemHocPhan *mh.SoTinChi)/SUM(mh.SoTinChi) as DiemTrungBinh from DiemThi dt, MonHoc mh, SinhVien sv, MonHoc_Lop mhl where dt.MaMonHoc = mh.MaMonHoc and dt.MaSinhVien = sv.MaSinhVien and mh.MaMonHoc = mhl.MaMonHoc and mhl.HocKy = '" + cbbHocKi.Text+"' and mhl.NienKhoa = '"+cbbNienkhoa.Text+ "' group by dt.MaSinhVien, sv.MaLop, sv.HoDem, sv.Ten ORDER BY DiemTrungBinh DESC", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
