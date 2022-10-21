using System.Data.SqlClient;
namespace QLNhanVien
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();                                 
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            btXoa.BackColor = Color.LightSteelBlue;
            btThem.BackColor = Color.White;
            btLammoi.BackColor = Color.White;
            int index = listVDs.SelectedItems.Count;
            string value = "";          
            if(index > 0)
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa '" + listVDs.SelectedItems[0].Text + "' không ?", "THONG BAO" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                value = listVDs.SelectedItems[0].Text;
                if (dialog == DialogResult.Yes)
                {
                    SqlConnection cnn = new SqlConnection();
                    ConnectionStringSql.connection(ref cnn);
                    cnn.Open();
                    SqlCommand cmd;
                    string sql = "delete from nhanvien where manv = '" + listVDs.SelectedItems[0].Text + "'";
                    cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(sql, cnn);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    listVDs.Items.Remove(listVDs.SelectedItems[0]);
                    MessageBox.Show("Xóa thành công " + value + " !!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmd.Dispose();
                    cnn.Close();
                }
            }
            else
            {
                MessageBox.Show("Xóa không thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            btThem.BackColor = Color.LightSteelBlue;
            btXoa.BackColor = Color.White;
            btLammoi.BackColor = Color.White;
            SqlConnection cnn = new SqlConnection();
            ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd;
            string sql = "select manv from nhanvien";
            SqlDataReader dataReader;
            cmd = new SqlCommand(sql, cnn);
            dataReader = cmd.ExecuteReader();
            int count1 = 1, count2 = 1;
            int flag = listVDs.Items.Count;
            while (dataReader.Read())
            {
                if (dataReader.GetString(0).Contains("NV.LT"))
                {
                    count1++;
                }

                if (dataReader.GetString(0).Contains("NV.TN"))
                {
                    count2++;
                }
            }
            dataReader.Close();
            string cv = "";
            string id = "";
            string gender = "";
            ListViewItem lvi = new ListViewItem();
            if (rbLetan.Checked)
            {
                id = "NV.LT" + count1;
                lvi = listVDs.Items.Add(id);
                cv = "Lễ Tân";
            }
            if (rbThungan.Checked)
            {
                id = "NV.TN" + count2;
                lvi = listVDs.Items.Add(id);
                cv = "Thu Ngân";
            }
            string message = "";
            if (tbName.Text.Length == 0)
            {
                message += "Không được để trống tên !\n";
            }
            else
            {
                if (Fix.eventString(lbName.Text))
                {
                    lvi.SubItems.Add(tbName.Text);
                }
                else
                {
                    message += "Tên không chứa ký tự đặt biệt hoặc số !\n";
                }
            }
            lvi.SubItems.Add(dateT.Value.ToShortDateString());
            if (rbNam.Checked)
            {
                lvi.SubItems.Add(rbNam.Text);
                gender = rbNam.Text;
            }
            if (rbNu.Checked)
            {
                lvi.SubItems.Add(rbNu.Text);
                gender = rbNu.Text;
            }
            if (tbAdd.Text.Length == 0)
            {
                message += "Không để trống địa chỉ! \n";
            }
            else
            {
                lvi.SubItems.Add(tbAdd.Text);
            }
            if (tbSdt.Text.Length == 0)
            {
                message += "Không được để trống số điện thoại !\n";
            }
            else
            {

                if (Fix.KTSDT(tbSdt.Text))
                {
                    lvi.SubItems.Add(tbSdt.Text);
                    if (tbSdt.Text.Length != 10)
                    {
                        message += "Số điện thoại không đủ 10 số !\n";
                    }
                }
                else
                {
                    message += "Không được nhập ký tự trong số điện thoại !\n";
                }
            }
            if (tbMoney.Text.Length == 0)
            {
                message += "Không được để trống lương !\n";
            }
            else if (Fix.KTSDT(tbMoney.Text))
            {
                lvi.SubItems.Add(tbMoney.Text);
            }
            else
            {
                message += "Không được nhập ký tự trong lương !\n";
            }
            lvi.SubItems.Add(cv);
            if (message.Length == 0)
            {
                string sql1 = "insert into nhanvien values('" + id + "', N'" + tbName.Text + "', N'" + dateT.Value + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + cv + "')";
                cmd = new SqlCommand(sql1, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(sql1, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                lbNotify.Text = "Thêm thành công !";
                //string sql2 = "insert into taikhoan values('" + id + "', '" + dateT.Value + "'";
                //cmd = new SqlCommand(sql2, cnn);
                //adapter.InsertCommand = new SqlCommand(sql2, cnn);
                //adapter.InsertCommand.ExecuteNonQuery();
            }
            else
            {
                listVDs.Items.RemoveAt(flag);
                MessageBox.Show(message + "\nVui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lbNotify.Text = "Thêm không thành công !";
            }
            cmd.Dispose();
            cnn.Close();
        }

        private void btLammoi_Click(object sender, EventArgs e)
        {
            btLammoi.BackColor = Color.LightSteelBlue;
            btXoa.BackColor = Color.White;
            btThem.BackColor = Color.White;
            tbName.Clear();
            tbAdd.Clear();
            tbSdt.Clear();
            tbMoney.Clear();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                this.Hide();
                new MenuStaff().ShowDialog();
                this.Close();
            }
           
        }
    }
}