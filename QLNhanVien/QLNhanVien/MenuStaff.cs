using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class MenuStaff : Form
    {
        public MenuStaff()
        {
            InitializeComponent();
        }

        private void MenuStaff_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            dateT.Value = date;
            //tbName.Text = date.ToString();
            //dateBirth.Value = ;
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
            //new 
            this.Close();
        }
    }
}
