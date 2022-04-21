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
    public partial class QuanLyBangDiem : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public QuanLyBangDiem()
        {
            InitializeComponent();
            Showdata();
            dataGridView1.Columns[0].HeaderText = "Mã môn học";
            dataGridView1.Columns[1].HeaderText = "Mã sinh viên";
            dataGridView1.Columns[2].HeaderText = "Điểm quá trình";
            dataGridView1.Columns[3].HeaderText = "Điểm giữa kì";
            dataGridView1.Columns[4].HeaderText = "Điểm thực hành";
            dataGridView1.Columns[5].HeaderText = "Điểm cuối kì";
            dataGridView1.Columns[6].HeaderText = "Điểm học phần";
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        SqlCommand cmd;
        public void Showdata()
        {

            adpt = new SqlDataAdapter("Select * from DiemThi", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void txtCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string diemqt = txtDiemQt.Text.ToString();
                string diemgk = txtDiemGk.Text.ToString();
                string diemth = txtDiemTh.Text.ToString();
                string diemck = txtDiemCk.Text.ToString();


                string trongsodiemqt = cbbDiemQt.Text.ToString();
                string trongsodiemgk = cbbDiemGk.Text.ToString();
                string trongsodiemth = cbbDiemTh.Text.ToString();
                string trongsodiemck = cbbDiemCk.Text.ToString();

                float tongdiemhp = (float.Parse(diemqt) * float.Parse(trongsodiemqt) + float.Parse(diemgk) * float.Parse(trongsodiemgk) + float.Parse(diemth) * float.Parse(trongsodiemth) + float.Parse(diemck) * float.Parse(trongsodiemck)) / 100;

                float tongtrongso = float.Parse(trongsodiemqt) + float.Parse(trongsodiemgk) + float.Parse(trongsodiemth) + float.Parse(trongsodiemck);

                if (tongtrongso == 100)
                {
                    txtDiemHp.Text = tongdiemhp.ToString();
                }
                else
                {
                    MessageBox.Show("Tổng trọng số phải bằng 100% ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin về các loại điểm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbMaMH.Text != "" & txtMaSV.Text != "")
                try
            {
                conn.Open();
                string sqlQuery = "Insert into DiemThi(MaMonHoc,MaSinhVien,DiemQuaTrinh,DiemGiuaKy,DiemThucHanh,DiemCuoiKy,DiemHocPhan) Values (N'" + cbbMaMH.Text + "',N'" + txtMaSV.Text + "','" + txtDiemQt.Text + "','" + txtDiemGk.Text + "','" + txtDiemTh.Text + "','" + txtDiemCk.Text + "','" + txtDiemHp.Text + "')";
                cmd = new SqlCommand(sqlQuery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
                }
           catch(Exception ex)
            {
                    if(ex != null)
                    MessageBox.Show(ex.Message);
                    else
                    {
                        MessageBox.Show("MSSV không tồn tại hoặc đã có dữ liệu điểm MSSV học môn này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                //MessageBox.Show("MSSV không tồn tại hoặc đã có dữ liệu điểm MSSV học môn này","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbMaMH.Text != "" & txtMaSV.Text != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    using (SqlCommand cmd = new SqlCommand("delete DiemThi where MaMonHoc='" + cbbMaMH.Text + "' AND MaSinhVien='" + txtMaSV.Text + "'", conn))
                {
                    conn.Open();
                    //cmd.Parameters.AddWithValue("@MaMH", cbbMaMH.Text);
                    //cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
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
            if (cbbMaMH.Text != "" & txtMaSV.Text != "")
                using (SqlCommand cmd = new SqlCommand("update DiemThi set DiemQuaTrinh=@DiemQuaTrinh,DiemGiuaKy=@DiemGiuaKy,DiemThucHanh=@DiemThucHanh,DiemCuoiKy=@DiemCuoiKy,DiemHocPhan=@DiemHocPhan where MaMonHoc=@MaMonHoc and MaSinhVien=@MaSinhVien", conn))
            {
               conn.Open();
                cmd.Parameters.AddWithValue("@DiemQuaTrinh", txtDiemQt.Text);
                cmd.Parameters.AddWithValue("@DiemGiuaKy", txtDiemGk.Text);
                cmd.Parameters.AddWithValue("@DiemThucHanh", txtDiemTh.Text);
                cmd.Parameters.AddWithValue("@DiemCuoiKy", txtDiemCk.Text);
                cmd.Parameters.AddWithValue("@DiemHocPhan", txtDiemHp.Text);
                cmd.Parameters.AddWithValue("@MaSinhVien", txtMaSV.Text);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // txtMaSV.ReadOnly = true;
           // cbbMaMH.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            cbbMaMH.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtMaSV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiemQt.Text= dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtDiemGk.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtDiemTh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiemCk.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtDiemHp.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // txtMaSV.ReadOnly = true;
            // cbbMaMH.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            cbbMaMH.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtMaSV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiemQt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtDiemGk.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtDiemTh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiemCk.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtDiemHp.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void txtSearchMSSV_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from DiemThi where MaSinhVien like N'%" + txtSearchMSSV.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void txtSearchMaMH_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from DiemThi where MaMonHoc like N'%" + txtSearchMaMH.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void QuanLyBangDiem_Load(object sender, EventArgs e)
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
