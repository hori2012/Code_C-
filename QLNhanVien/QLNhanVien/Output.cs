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
    public partial class Output : Form
    {
        private DataTable table = new DataTable();
        public Output()
        {
            InitializeComponent();
           
        }

        private void btLoc_Click(object sender, EventArgs e)
        {
            btLoc.BackColor = Color.LightSteelBlue;
            btQuaylai.BackColor = Color.White;
            btThoat.BackColor = Color.White;
            btSua.BackColor = Color.White;
            table.Clear();
            string[] gender = { "", "" };
            if (cbNam.Checked == true)
            {
                gender[0] = "Nam";
            }
            if (cbNu.Checked == true)
            {
                gender[1] = "Nữ";
            }
            string[] cv = { "", "" };
            if (cboxLetan.Checked == true)
            {
                cv[0] = "Lễ Tân";
            }
            if (cboxThungan.Checked == true)
            {
                cv[1] = "Thu Ngân";
            }
            if (numMin.Value > numMax.Value && ((int)numMin.Value >= 18 && (int)numMax.Value >= 18))
            {
                MessageBox.Show("Khoảng tuổi không hợp lý !!");
            }
            string sql = "";
            SqlConnection cnn = new SqlConnection();
            ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd;
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "')";
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "')";
                }
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and chucvu in (N'" + cv[0] + "', N'" + cv[1] + "')";
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))

            {
                sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and chucvu in (N'" + cv[0] + "', N'" + cv[1] + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "') and cv in (N'" + cv[0] + "', N'" + cv[1] + "')";
                }
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");
                }
                else
                {
                    sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
                }
            }
            if ((cbNam.Checked == true || cbNu.Checked == true) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  gioitinh in (N'" + gender[0] + "', N'" + gender[1] + "') and (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "') and chucvu in (N'" + cv[0] + "', N'" + cv[1] + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
                }
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "')";
                }
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "') and chucvu in (N'" + cv[0] + "', N'" + cv[1] + "')";
                }
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
                }
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value != 0 && (int)numMax.Value != 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                if ((int)numMin.Value < 18 || (int)numMax.Value < 18)
                {
                    MessageBox.Show("Tuổi phải từ 18 trở lên !!");

                }
                else
                {
                    sql = "select * from nhanvien where  (year(getdate()) - year(ngaysinh) >= '" + (int)numMin.Value + "' and year(getdate()) - year(ngaysinh) <= '" + (int)numMax.Value + "') and chucvu in (N'" + cv[0] + "', N'" + cv[1] + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
                }
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) == 0))
            {
                sql = "select * from nhanvien where  chucvu in (N'" + cv[0] + "', N'" + cv[1] + "')";
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == true || cboxThungan.Checked == true) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                sql = "select * from nhanvien where  chucvu in (N'" + cv[0] + "', N'" + cv[1] + "') and quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
            }
            if ((cbNam.Checked == false && cbNu.Checked == false) && ((int)numMin.Value == 0 && (int)numMax.Value == 0) && (cboxLetan.Checked == false && cboxThungan.Checked == false) && (string.Compare(cboxAdd.Text, "địa chỉ", true) != 0))
            {
                sql = "select * from nhanvien where  quequan = N'" + cboxAdd.SelectedItem.ToString() + "'";
            }
            if (sql.Length > 0)
            {
                cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataRow newRows = table.NewRow();
                    newRows["Mã nhân viên"] = (string)reader.GetValue(0);
                    newRows["Họ tên"] = (string)reader.GetValue(1);
                    newRows["Ngày sinh"] = (DateTime)reader.GetValue(2);
                    newRows["Giới tính"] = (string)reader.GetValue(3);
                    newRows["Địa chỉ"] = (string)reader.GetValue(4);
                    newRows["Liên lạc"] = (string)reader.GetValue(5);
                    newRows["Lương"] = (Double)reader.GetValue(6);
                    newRows["Chức vụ"] = (string)reader.GetValue(7);
                    table.Rows.Add(newRows);
                }
                cmd.Dispose();
                reader.Close();
            }
            cnn.Close();
            dtVDs.DataSource = table;
        }

        private void btQuaylai_Click(object sender, EventArgs e)
        {
            btLoc.BackColor = Color.White;
            btQuaylai.BackColor = Color.LightSteelBlue;
            btThoat.BackColor = Color.White;
            btSua.BackColor = Color.White;
            table.Clear();
            SqlConnection cnn = new SqlConnection();
            ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd;
            string sql = "select * from nhanvien";
            cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DataRow newRows = table.NewRow();
                newRows["Mã nhân viên"] = (string)reader.GetValue(0);
                newRows["Họ tên"] = (string)reader.GetValue(1);
                newRows["Ngày sinh"] = (DateTime)reader.GetValue(2);
                newRows["Giới tính"] = (string)reader.GetValue(3);
                newRows["Địa chỉ"] = (string)reader.GetValue(4);
                newRows["Liên lạc"] = (string)reader.GetValue(5);
                newRows["Lương"] = (Double)reader.GetValue(6);
                newRows["Chức vụ"] = (string)reader.GetValue(7);
                table.Rows.Add(newRows);
            }
            cmd.Dispose();
            reader.Close();
            cnn.Close();
            cboxAdd.Text = "Địa chỉ";
        }
        //thoat
        private void button3_Click(object sender, EventArgs e)
        {
            btXoa.BackColor = Color.White;
            btLoc.BackColor = Color.White;
            btQuaylai.BackColor = Color.White;
            btThoat.BackColor = Color.LightSteelBlue;
            btSua.BackColor = Color.White;
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                this.Close();
            }
        }
       

        private void btSua_Click(object sender, EventArgs e)
        {
            btXoa.BackColor = Color.White;
            btLoc.BackColor = Color.White;
            btQuaylai.BackColor = Color.White;
            btThoat.BackColor = Color.White;
            btSua.BackColor = Color.LightSteelBlue;
            Cursor = Cursors.Hand;
            string id = "";
            if (dtVDs.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dtVDs.SelectedRows)
                {
                    id = row.Cells[0].Value.ToString();
                }
                this.Hide();
                new Update(id).ShowDialog();
                this.Close();
            }
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            btXoa.BackColor = Color.LightSteelBlue;
            btLoc.BackColor = Color.White;
            btQuaylai.BackColor = Color.White;
            btThoat.BackColor = Color.White;
            btSua.BackColor = Color.White;
            if (dtVDs.SelectedRows.Count > 0)
            {
                string value1 = "", value2 = "";
                foreach (DataGridViewRow row in dtVDs.SelectedRows)
                {
                    value1 = row.Cells[0].Value.ToString();
                    value2 = row.Cells[1].Value.ToString();
                }
                DialogResult dialog = MessageBox.Show("Bạn có chắc \"" + value1 + " - " + value2 + "\" ra khỏi hệ thống !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dtVDs.SelectedRows)
                    {
                        dtVDs.Rows.RemoveAt(row.Index);
                    }
                    SqlConnection cnn = new SqlConnection();
                    ConnectionStringSql.connection(ref cnn);
                    cnn.Open();
                    SqlCommand cmd;
                    string sql = "delete from nhanvien where manv = '" + value1 + "'";
                    cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand(sql, cnn);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    cmd.Dispose();
                    cnn.Close();
                }
            }
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void Output_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Mã nhân viên", typeof(String));
            table.Columns.Add("Họ tên", typeof(String));
            table.Columns.Add("Ngày sinh", typeof(DateTime));
            table.Columns.Add("Giới tính", typeof(String));
            table.Columns.Add("Địa chỉ", typeof(String));
            table.Columns.Add("Liên lạc", typeof(String));
            table.Columns.Add("Lương", typeof(Double));
            table.Columns.Add("Chức vụ", typeof(String));
            SqlConnection cnn = new SqlConnection();
            ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd;
            string sql = "select * from nhanvien";
            string sql1 = "select distinct quequan from nhanvien";
            cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DataRow newRows = table.NewRow();
                newRows["Mã nhân viên"] = (string)reader.GetValue(0);
                newRows["Họ tên"] = (string)reader.GetValue(1);
                newRows["Ngày sinh"] = (DateTime)reader.GetValue(2);
                newRows["Giới tính"] = (string)reader.GetValue(3);
                newRows["Địa chỉ"] = (string)reader.GetValue(4);
                newRows["Liên lạc"] = (string)reader.GetValue(5);
                newRows["Lương"] = (Double)reader.GetValue(6);
                newRows["Chức vụ"] = (string)reader.GetValue(7);
                table.Rows.Add(newRows);
            }
            reader.Close();
            cmd = new SqlCommand(sql1, cnn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cboxAdd.Items.Add((string)reader.GetValue(0));
            }
            cmd.Dispose();
            reader.Close();
            cnn.Close();
            dtVDs.DataSource = table;
            dtVDs.Columns[1].Width = 180;
            dtVDs.Columns[3].Width = 100;
        }
    }
}
