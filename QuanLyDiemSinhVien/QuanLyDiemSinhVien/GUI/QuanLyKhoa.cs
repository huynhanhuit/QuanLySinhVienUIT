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
using System.IO;
namespace QuanLyDiemSinhVien.GUI
{
    public partial class QuanLyKhoa : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public QuanLyKhoa()
        {

            InitializeComponent();
            Showdata();
            dataGridView1.Columns[0].HeaderText = "Mã khoa";
            dataGridView1.Columns[1].HeaderText = "Tên khoa";
            dataGridView1.Columns[2].HeaderText = "SĐT";
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        SqlCommand cmd;
        public void Showdata()
        {
            adpt = new SqlDataAdapter("Select * from KhoaDaoTao", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text != "" & txtTenKhoa.Text != "" & txtDienThoai.Text != "")
                try
            {
                conn.Open();
                string sqlQuery = "Insert into KhoaDaoTao(MaKhoa,TenKhoa,DienThoai) Values (N'" + txtMaKhoa.Text + "',N'" + txtTenKhoa.Text + "','" + txtDienThoai.Text + "')";
                cmd = new SqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
            }
            catch(Exception )
            {
                    MessageBox.Show("Mã khoa đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    using (SqlCommand cmd = new SqlCommand("delete KhoaDaoTao where MaKhoa=@MaKhoa", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);
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
            if (txtMaKhoa.Text != "")
                using (SqlCommand cmd = new SqlCommand("update KhoaDaoTao set TenKhoa=@TenKhoa,DienThoai=@DienThoai where MaKhoa=@MaKhoa", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TenKhoa",txtTenKhoa.Text);
                cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", txtMaKhoa.Text);
                cmd.ExecuteNonQuery();
                    MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtMaKhoa.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaKhoa.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenKhoa.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDienThoai.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
           

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // txtMaKhoa.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaKhoa.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenKhoa.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDienThoai.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from KhoaDaoTao where MaKhoa like N'%" + txtSearch.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from KhoaDaoTao where TenKhoa like N'%" + txtSearch1.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
