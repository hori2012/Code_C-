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

namespace QLNhanVien
{
    public partial class MenuStaff : Form
    {
        public MenuStaff()
        {
            InitializeComponent();
        }
        private string id = "";
        public MenuStaff(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void MenuStaff_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            dateT.Value = date;
            SqlConnection cnn = new SqlConnection();
            QLNhanVien.ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            string sql = "select hoten, ngaysinh from nhanvien where manv = '" + this.id + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tbName.Text = reader.GetString(0);
                dateBirth.Value = reader.GetDateTime(0);
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }
        //nhap
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Input().ShowDialog();
            this.Close();
        }
        //danh sach
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Output().ShowDialog();
            this.Close();
        }
        //thoat
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //trang chu
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
