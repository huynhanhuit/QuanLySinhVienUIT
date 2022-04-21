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
    public partial class BackupRestore : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J0FL45A;Initial Catalog=QLSV;Integrated Security=True");
        public BackupRestore()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                backupButton.Enabled = true;
            }
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("Nhap duong dan noi luu file back up");

            }
            else
            {
                string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + textBox1.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm") + ".bak'";
                con.Open();
                SqlCommand command = new SqlCommand(cmd, con);
                command.ExecuteNonQuery();
               // MessageBox.Show("Database back up done succesfully");
                MessageBox.Show("Database back up done succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                backupButton.Enabled = false;
            }
        }

        private void browseButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup File |*.bak";
            dlg.Title = "Database restore";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                restoreButton.Enabled = true;

            }
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();
            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, con);
                cmd1.ExecuteNonQuery();
                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + textBox2.Text + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, con);
                cmd2.ExecuteNonQuery();
                string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();
                //MessageBox.Show("Database restore done succesfully");
                MessageBox.Show("Database restore done succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
              
            }
            catch
            {

            }
        }
    }
}
