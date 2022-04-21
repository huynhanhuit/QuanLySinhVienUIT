using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class QuanLyMonHoc : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public QuanLyMonHoc()
        {
            InitializeComponent();
            Showdata();
            dataGridView1.Columns[0].HeaderText = "Mã môn học";
            dataGridView1.Columns[1].HeaderText = "Tên môn học";
            dataGridView1.Columns[2].HeaderText = "Số tín chỉ";
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        SqlCommand cmd;
        public void Showdata()
        {

            adpt = new SqlDataAdapter("Select * from MonHoc", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaMH.Text != "" & txtTenMH.Text != "" & txtSoTinChi.Text != "")
                try
                {
                    conn.Open();
                    string sqlQuery = "Insert into MonHoc(MaMonHoc,TenMonHoc,SoTinChi) Values (N'" + txtMaMH.Text + "',N'" + txtTenMH.Text + "','" + txtSoTinChi.Text + "')";
                    cmd = new SqlCommand(sqlQuery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
                }
            catch(Exception)
                {
                    MessageBox.Show("Mã môn học đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaMH.Text != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    using (SqlCommand cmd = new SqlCommand("delete Monhoc where MaMonHoc=@MaMonHoc", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaMonHoc", txtMaMH.Text);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMaMH.Text != "")
            {
                    using (SqlCommand cmd = new SqlCommand("update MonHoc set TenMonHoc=@TenMonHoc,SoTinChi=@SoTinChi where MaMonHoc=@MaMonHoc", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@TenMonHoc", txtTenMH.Text);
                    cmd.Parameters.AddWithValue("@SoTinChi", txtSoTinChi.Text);
                    cmd.Parameters.AddWithValue("@MaMonHoc", txtMaMH.Text);
                    cmd.ExecuteNonQuery();
                    Showdata();
                        MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtMaMH.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaMH.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenMH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoTinChi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //txtMaMH.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaMH.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenMH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoTinChi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void txtSearchMaMon_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from Monhoc where MaMonHoc like N'%" + txtSearchMaMon.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void txtSearchTenMon_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from Monhoc where TenMonHoc like N'%" + txtSearchTenMon.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
