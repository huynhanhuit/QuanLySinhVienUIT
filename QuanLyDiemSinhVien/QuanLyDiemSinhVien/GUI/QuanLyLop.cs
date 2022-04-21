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
    public partial class QuanLyLop : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;

        public QuanLyLop()
        {
            InitializeComponent();
            Showdata();
       
            dataGridView1.Columns[0].HeaderText = "Mã lớp";
            dataGridView1.Columns[1].HeaderText = "Tên lớp";
            dataGridView1.Columns[2].HeaderText = "Khoa";
            dataGridView1.Columns[3].HeaderText = "Hệ đào tạo";
            dataGridView1.Columns[4].HeaderText = "Năm nhập học";
            dataGridView1.Columns[5].HeaderText = "Sỉ số";
            dataGridView1.Columns[6].HeaderText = "Mã khoa";
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        SqlCommand cmd;
        public void Showdata()
        {

            adpt = new SqlDataAdapter("Select * from Lop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void QuanLyLop_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("Select * from KhoaDaoTao", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbTenKhoa.Items.Add(dt.Rows[i]["TenKhoa"]);
            }
            conn.Close();
        }

        private void cbbTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select MaKhoa from KhoaDaoTao where TenKhoa = @TenKhoa ", conn);
            cmd.Parameters.AddWithValue("@TenKhoa",cbbTenKhoa.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                txtMaKhoa.Text = da.GetValue(0).ToString();
                
            }
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // txtMaLop.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaLop.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenLop.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbTenKhoa.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbbHeDaoTao.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtNamNhapHoc.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtSiSo.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtMaKhoa.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //txtMaLop.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaLop.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenLop.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbTenKhoa.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbbHeDaoTao.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtNamNhapHoc.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtSiSo.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtMaKhoa.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }
         private void btnAdd_Click(object sender, EventArgs e)
         {
             if (txtMaLop.Text != "" & txtTenLop.Text != "" & cbbTenKhoa.Text != "" & cbbHeDaoTao.Text != "" & txtNamNhapHoc.Text != "" & txtSiSo.Text != "" & txtMaKhoa.Text != "")
                 try
                 {
                     conn.Open();
                     string sqlQuery = "Insert into Lop(MaLop,TenLop,Khoa,HeDaoTao,NamNhapHoc,SiSo,MaKhoa) Values (N'" + txtMaLop.Text + "',N'" + txtTenLop.Text + "',N'" + cbbTenKhoa.Text + "',N'" + cbbHeDaoTao.Text + "',N'" + txtNamNhapHoc.Text + "',N'" + txtSiSo.Text + "',N'" + txtMaKhoa.Text + "')";
                    
                     cmd = new SqlCommand(sqlQuery, conn);
                     cmd.ExecuteNonQuery();
                     conn.Close();
                     MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     Showdata();

                  
                    
                }
                 catch(Exception)
                 {
                     MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     conn.Close();
                 }
             else
             {
                 MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtMaLop.Text !="")
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    using (SqlCommand cmd = new SqlCommand("delete Lop where MaLop=@MaLop", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.ExecuteNonQuery();
                        Showdata();
                        MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
           else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtMaLop.Text !="")
            {
                using (SqlCommand cmd = new SqlCommand("update Lop set TenLop=@TenLop,Khoa=@Khoa,HeDaoTao=@HeDaoTao,NamNhapHoc=@NamNhapHoc,SiSo=@SiSo where MaLop=@MaLop", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                    cmd.Parameters.AddWithValue("@Khoa", cbbTenKhoa.Text);
                    cmd.Parameters.AddWithValue("@HeDaoTao", cbbHeDaoTao.Text);
                    cmd.Parameters.AddWithValue("@NamNhapHoc", txtNamNhapHoc.Text);
                    cmd.Parameters.AddWithValue("@SiSo", txtSiSo.Text);
                    cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
                }
            }
          else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLop.Text != "")
                {
                    using (SqlCommand cmd = new SqlCommand("update Lop set TenLop=@TenLop,Khoa=@Khoa,HeDaoTao=@HeDaoTao,NamNhapHoc=@NamNhapHoc,SiSo=@SiSo where MaLop=@MaLop", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                        cmd.Parameters.AddWithValue("@Khoa", cbbTenKhoa.Text);
                        cmd.Parameters.AddWithValue("@HeDaoTao", cbbHeDaoTao.Text);
                        cmd.Parameters.AddWithValue("@NamNhapHoc", txtNamNhapHoc.Text);
                        cmd.Parameters.AddWithValue("@SiSo", txtSiSo.Text);
                        cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);
                        cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Showdata();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         catch(Exception ex)
            {
                MessageBox.Show("Lớp đang có sỉ số lớn hơn sỉ số bạn muốn cập nhật. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
      

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from Lop where MaLop like N'%" + txtSearch.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
       
    }
}
