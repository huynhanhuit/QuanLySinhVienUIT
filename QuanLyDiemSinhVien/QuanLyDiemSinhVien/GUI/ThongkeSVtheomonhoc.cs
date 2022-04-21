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
    public partial class ThongkeSVtheomonhoc : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public ThongkeSVtheomonhoc()
        {
          
            InitializeComponent();
            

        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        SqlCommand cmd;
        

        
        private void cbbMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
            adpt = new SqlDataAdapter("select Distinct sv.MaSinhVien,sv.HoDem,sv.Ten,sv.NgaySinh,dt.DiemHocPhan from SinhVien sv, DiemThi dt, MonHoc mh where  (dt.MaMonHoc='" + cbbMaMH.Text+ "') and (dt.MaSinhVien = sv.MaSinhVien)", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        void loaddata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select TenMonHoc,SoTinChi from Monhoc where MaMonHoc = @MaMonHoc ", conn);
            cmd.Parameters.AddWithValue("@MaMonHoc", cbbMaMH.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                txtTenMH.Text = da.GetValue(0).ToString();
                txtSoTinChi.Text = da.GetValue(1).ToString();
            }
            conn.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ThongkeSVtheomonhoc_Load_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("Select * from MonHoc", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaMH.Items.Add(dt.Rows[i]["MaMonHoc"]);
            }
            conn.Close();
        }
    }
}
