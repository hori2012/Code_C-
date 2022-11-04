using System.Data.SqlClient;
namespace QLNhanVien
{
    public partial class Input : Form
    {
        private List<int> countLT = new List<int>();
        private List<int> countTN = new List<int>();
        public Input()
        {
            InitializeComponent();                                 
        }

        public int ConvertString(string str)
        {
            int answer = 0;
            string subStr = "";
            for (int i = 5; i < str.Length; i++)
            {
                subStr += str[i];
            }
            answer = subStr[0] - '0';
            if (subStr.Length > 1)
            {
                for (int i = 1; i < subStr.Length; i++)
                {
                    answer *= 10;
                    answer += (subStr[i] - '0');
                }
            }
            return answer;
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
            SqlCommand cmd = new SqlCommand();
            string sql = "";
            int flag = listVDs.Items.Count;
            string id = "";
            string cv = "";
            string gender = "";
            int count = 1;
            ListViewItem lvi = new ListViewItem();
            if (rbLetan.Checked)
            {
                while (countLT.Contains(count))
                {
                    count++;
                }
                id = "NV.LT" + count;
                lvi = listVDs.Items.Add(id);
                cv = "Lễ Tân";
                countLT.Add(count);
                countLT.Sort();
            }
            if (rbThungan.Checked)
            {
                while (countTN.Contains(count))
                {
                    count++;
                }
                id = "NV.TN" + count;
                lvi = listVDs.Items.Add(id);
                cv = "Thu Ngân";
                countTN.Add(count);
                countTN.Sort();
            }
            string message = "";
            if (tbName.Text.Length == 0)
            {
                message += "Không được để trống tên !\n";
            }
            else
            {
                if (Fix.eventString(tbName.Text))
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
                sql = "insert into nhanvien values('" + id + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + cv + "')";
                cmd = new SqlCommand(sql, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                lbNotify.Text = "Thêm thành công !";
                sql = "insert into taikhoan values('" + id + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                cmd = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
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

        private void Input_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            QLNhanVien.ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select manv from nhanvien", cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Contains("NV.LT"))
                {
                    countLT.Add(ConvertString(reader.GetString(0)));
                }
                if (reader.GetString(0).Contains("NV.TN"))
                {
                    countTN.Add(ConvertString(reader.GetString(0)));
                }
            }
            countLT.Sort();
            countTN.Sort();
            reader.Close();
            cmd.Dispose();
            cnn.Close();

        }
    }
}