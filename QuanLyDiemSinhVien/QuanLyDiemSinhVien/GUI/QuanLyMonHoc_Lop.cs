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
    public partial class QuanLyMonHoc_Lop : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public QuanLyMonHoc_Lop()
        {
            InitializeComponent();
            loadcombobox();
            Showdata();
            dataGridView1.Columns[0].HeaderText = "Mã lớp";
            dataGridView1.Columns[1].HeaderText = "Mã môn học";
            dataGridView1.Columns[2].HeaderText = "Học kỳ";
            dataGridView1.Columns[3].HeaderText = "Niên khóa";
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        SqlCommand cmd;
        public void Showdata()
        {

            adpt = new SqlDataAdapter("Select * from MonHoc_Lop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void QuanLyMonHoc_Lop_Load(object sender, EventArgs e)
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
        void loadcombobox()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
            conn.Open();
            adpt = new SqlDataAdapter("Select * from Lop", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaLop.Items.Add(dt.Rows[i]["MaLop"]);
            }
            conn.Close();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //cbbMaLop.ReadOnly = true;
           // cbbMaMH.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            cbbMaLop.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbbMaMH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbHocKy.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbbNienKhoa.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //cbbMaLop.Enabled = false;
           //cbbMaMH.Enabled = false;
            int i;
            i = dataGridView1.CurrentRow.Index;
            cbbMaLop.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbbMaMH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbHocKy.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbbNienKhoa.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbMaLop.Text != "" & cbbMaMH.Text != "" & cbbHocKy.Text != "" & cbbNienKhoa.Text != "")
                try
                {
                    conn.Open();
                    string sqlQuery = "Insert into MonHoc_Lop(MaLop,MaMonHoc,HocKy,NienKhoa) Values (N'" + cbbMaLop.Text + "',N'" + cbbMaMH.Text + "',N'" + cbbHocKy.Text + "','" + cbbNienKhoa.Text + "')";
                    cmd = new SqlCommand(sqlQuery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
                }
                catch(Exception )
                {
                    MessageBox.Show("Mã môn học-lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbMaLop.Text != "" & cbbMaMH.Text != "")
                using (SqlCommand cmd = new SqlCommand("delete MonHoc_Lop where MaLop=@MaLop and MaMonHoc=@MaMonHoc", conn))
            {
                    if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        conn.Open();
                cmd.Parameters.AddWithValue("@MaLop",cbbMaLop.Text);
                cmd.Parameters.AddWithValue("@MaMonHoc", cbbMaMH.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbbMaLop.Text != "" & cbbMaMH.Text != "")
                using (SqlCommand cmd = new SqlCommand("update MonHoc_Lop set HocKy=@HocKy,NienKhoa=@NienKhoa where MaLop=@MaLop and MaMonHoc=@MaMonHoc", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@HocKy", cbbHocKy.Text);
                cmd.Parameters.AddWithValue("@NienKhoa", cbbNienKhoa.Text);
                cmd.Parameters.AddWithValue("@MaLop", cbbMaLop.Text);
                cmd.Parameters.AddWithValue("@MaMonHoc", cbbMaMH.Text);
                cmd.ExecuteNonQuery();
                    MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearchMaLop_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from MonHoc_Lop where MaLop like N'%" + txtSearchMaLop.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void txtSearchMaMon_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from MonHoc_Lop where MaMonHoc like N'%" + txtSearchMaMon.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
