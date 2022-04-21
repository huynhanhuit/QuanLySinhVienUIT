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
    public partial class QuanLySinhVien : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        public QuanLySinhVien()
        {
            InitializeComponent();
            Showdata();
            dataGridView1.Columns[0].HeaderText = "Mã số sinh viên";
            dataGridView1.Columns[1].HeaderText = "Họ đệm";
            dataGridView1.Columns[2].HeaderText = "Tên";
            dataGridView1.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView1.Columns[4].HeaderText = "Giới tính";
            dataGridView1.Columns[5].HeaderText = "Nơi sinh";
            dataGridView1.Columns[6].HeaderText = "Mã lớp";
            dataGridView1.Columns[7].HeaderText = "Hình ảnh";
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        string ImgLocation = "";
        SqlCommand cmd;
       public void Showdata()
        {
            adpt = new SqlDataAdapter("Select * from SinhVien", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void btnBrowsebutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png|*.png|jpg files(*.jpg)|.jpg|All files(*.*)|*.*";
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                ImgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = ImgLocation;
            }
        }
       /* private void btnAdd_Click(object sender, EventArgs e)
         {
             if(txtMaSV.Text != "" & txtHoDem.Text != "" & txtTen.Text != "" & dtpNgaySinh.Text != "" & cbbGioiTinh.Text != "" & txtDiaChi.Text != "" & cbbMaLop.Text != "" & pictureBox1.Image != null)
                 try
                 {
                     byte[] images = null;
                     FileStream Stream = new FileStream(ImgLocation, FileMode.Open, FileAccess.Read);
                     BinaryReader brs = new BinaryReader(Stream);
                     images = brs.ReadBytes((int)Stream.Length);

                     conn.Open();
                     string sqlQuery = "Insert into Sinhvien(MaSV,HoDem,Ten,NgaySinh,GioiTinh,NoiSinh,MaLop,picture) Values (N'" + txtMaSV.Text + "',N'" + txtHoDem.Text + "',N'" + txtTen.Text + "','" + dtpNgaySinh.Value.ToString() + "',N'" + cbbGioiTinh.Text + "',N'" + txtDiaChi.Text + "','" + cbbMaLop.Text + "',@images)";
                     cmd = new SqlCommand(sqlQuery, conn);
                     cmd.Parameters.Add(new SqlParameter("@images", images));
                     cmd.ExecuteNonQuery();
                     conn.Close();
                     MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     Showdata();
                 }
            catch(Exception)
                 {
                     MessageBox.Show("Mã số sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     conn.Close();
                 }
             else
             {
                 MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }

         }*/
       
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //txtMaSV.ReadOnly = true;
                int i;
                i = dataGridView1.CurrentRow.Index;
                txtMaSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtHoDem.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtTen.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                dtpNgaySinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                cbbGioiTinh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                cbbMaLop.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                byte[] imgdata = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream ms = new MemoryStream(imgdata);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch(Exception )
            {
                MessageBox.Show("Không có thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //txtMaSV.ReadOnly = true;
                int i;
                i = dataGridView1.CurrentRow.Index;
                txtMaSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtHoDem.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtTen.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                dtpNgaySinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                cbbGioiTinh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                cbbMaLop.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                byte[] imgdata = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream ms = new MemoryStream(imgdata);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                MessageBox.Show("Không có thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    using (SqlCommand cmd = new SqlCommand("delete SinhVien where MaSinhVien=@MaSinhVien", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaSinhVien", txtMaSV.Text);
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
            if (txtMaSV.Text != "")
                using (SqlCommand cmd = new SqlCommand("update SinhVien set HoDem=@HoDem,Ten=@Ten,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,NoiSinh=@NoiSinh,MaLop=@MaLop where MaSinhVien=@MaSinhVien", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@HoDem", txtHoDem.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString());
                cmd.Parameters.AddWithValue("@GioiTinh", cbbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NoiSinh", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@MaLop", cbbMaLop.Text);
                cmd.Parameters.AddWithValue("@MaSinhVien", txtMaSV.Text);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Showdata();
                }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (SqlCommand cmd1 = new SqlCommand("Update Sinhvien set HinhAnh=@images where MaSinhVien=@MaSinhVien", conn))
            {
                try
                {
                    byte[] images = null;
                    FileStream Stream = new FileStream(ImgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(Stream);
                    images = brs.ReadBytes((int)Stream.Length);
                    cmd1.Parameters.AddWithValue("@MaSinhVien", txtMaSV.Text);
                    cmd1.Parameters.Add(new SqlParameter("@images", images));
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Dữ liệu đã được cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
                }
               catch(Exception)
                {
                    MessageBox.Show("Vui lòng tạo lại đường dẫn đến hình ảnh ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }
        }
        private void txtSearchMSSV_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adpt = new SqlDataAdapter("Select * from Sinhvien where MaSinhVien like N'%" + txtSearchMSSV.Text.ToString() + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void QuanLySinhVien_Load(object sender, EventArgs e)
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
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtMaSV.Text != "" & txtHoDem.Text != "" & txtTen.Text != "" & dtpNgaySinh.Text != "" & cbbGioiTinh.Text != "" & txtDiaChi.Text != "" & cbbMaLop.Text != "" & pictureBox1.Image != null)
                try
                {
                    byte[] images = null;
                    FileStream Stream = new FileStream(ImgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(Stream);
                    images = brs.ReadBytes((int)Stream.Length);

                    conn.Open();
                    string sqlQuery = "Insert into SinhVien(MaSinhVien,HoDem,Ten,NgaySinh,GioiTinh,NoiSinh,MaLop,HinhAnh) Values (N'" + txtMaSV.Text + "',N'" + txtHoDem.Text + "',N'" + txtTen.Text + "','" + dtpNgaySinh.Value.ToString() + "',N'" + cbbGioiTinh.Text + "',N'" + txtDiaChi.Text + "','" + cbbMaLop.Text + "',@images)";
                    cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.Add(new SqlParameter("@images", images));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Showdata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Mã số sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
