using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }
        //private string name = "Unknows";
        private string id = " Unknows";
        private string phone = "Unknows";
        private string address = "Unknows";
        private string money = "Unknows";
        private string cv = "Unknows";
        private List<int> countLT = new List<int>();
        private List<int> countTN = new List<int>();
        public Update(string id)
        {
            InitializeComponent();
            this.id = id;
        }
       public int ConvertString(string str)
        {
            int answer = 0;
            string subStr = "";
            for(int i = 5; i < str.Length; i++)
            {
                subStr += str[i];
            }
            answer = subStr[0] - '0';
            for(int i = 1; i < subStr.Length; i++)
            {
                answer *= 10;
                answer += subStr[i];
            }
            return answer;
        }
        private void btCapnhat_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd;
            SqlDataAdapter adpter = new SqlDataAdapter();
            string sql = "";
            if (string.Compare(phone, tbSdt.Text) != 0)
            {
                sql = "update nhanvien set sodt = '" + tbSdt.Text + "' where manv = '" + this.id + "' ";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
            }
            if (string.Compare(address, tbAdd.Text) != 0)
            {
                sql = "update nhanvien set quequan = N'" + tbAdd.Text + "'where manv = '" + this.id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
            }
            if (string.Compare(money, tbMoney.Text) != 0)
            {
                sql = "update nhanvien set luong = '" + tbMoney.Text + "'where manv = '" + this.id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
            }
            if (rbThungan.Checked == true && string.Compare(rbLetan.Text, cv) == 0)
            {
                int count = 1;
                string gender = "";
                while (countTN.Contains(count))
                {
                    count++;
                }
                string idbkup = "NV.TN" + count;
                if (rbNam.Checked)
                {
                    gender = rbNam.Text;
                }
                if (rbNu.Checked)
                {
                    gender = rbNu.Text;
                }
                sql = "delete from nhanvien where manv = '" + id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.DeleteCommand = new SqlCommand(sql, cnn);
                adpter.DeleteCommand.ExecuteNonQuery();

                sql = "delete from taikhoan where tendn = '" + id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.DeleteCommand = new SqlCommand(sql, cnn);
                adpter.DeleteCommand.ExecuteNonQuery();

                sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbThungan.Text + "')";
                cmd = new SqlCommand(sql, cnn);
                adpter.InsertCommand = new SqlCommand(sql, cnn);
                adpter.InsertCommand.ExecuteNonQuery();

                sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                cmd = new SqlCommand(sql, cnn);
                adpter.InsertCommand = new SqlCommand(sql, cnn);
                adpter.InsertCommand.ExecuteNonQuery();
            }
            if (rbLetan.Checked == true && string.Compare(rbThungan.Text, cv) == 0)
            {
                int count = 1;
                string gender = "";
                while (countLT.Contains(count))
                {
                    count++;
                }
                string idbkup = "NV.LT" + count;
                if (rbNam.Checked)
                {
                    gender = rbNam.Text;
                }
                if (rbNu.Checked)
                {
                    gender = rbNu.Text;
                }
                sql = "delete from nhanvien where manv = '" + id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.DeleteCommand = new SqlCommand(sql, cnn);
                adpter.DeleteCommand.ExecuteNonQuery();

                sql = "delete from taikhoan where tendn = '" + id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.DeleteCommand = new SqlCommand(sql, cnn);
                adpter.DeleteCommand.ExecuteNonQuery();

                sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                cmd = new SqlCommand(sql, cnn);
                adpter.InsertCommand = new SqlCommand(sql, cnn);
                adpter.InsertCommand.ExecuteNonQuery();

                sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                cmd = new SqlCommand(sql, cnn);
                adpter.InsertCommand = new SqlCommand(sql, cnn);
                adpter.InsertCommand.ExecuteNonQuery();
            }
            if (string.Compare(phone, tbSdt.Text) != 0 && string.Compare(address, tbAdd.Text) != 0 && string.Compare(money, tbMoney.Text) == 0)
            {
                sql = "update nhanvien set sodt = '" + tbSdt.Text + "', quequan = n'" + tbAdd.Text + "' where manv = '" + this.id + "' ";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
                if (rbThungan.Checked == true && string.Compare(rbLetan.Text, cv) == 0)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    sql = "select manv from nhanvien where manv like '" + "NV.TN_" + "'";
                    cmd = new SqlCommand(sql, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        if (count == ConvertString(dataReader.GetString(0)))
                        {
                            count++;
                        }

                    }
                    dataReader.Close();
                    string gender = "";
                    string idbkup = "NV.TN" + count;

                    if (rbNam.Checked)
                    {
                        gender = rbNam.Text;
                    }
                    if (rbNu.Checked)
                    {
                        gender = rbNu.Text;
                    }
                    dataReader.Close();
                    sql = "delete from nhanvien where manv = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "delete from taikhoan where tendn = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();
                }
                if (rbLetan.Checked == true && string.Compare(rbThungan.Text, cv) == 0)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    sql = "select manv from nhanvien where manv like '" + "NV.LT_" + "'";
                    cmd = new SqlCommand(sql, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (count == ConvertString(dataReader.GetString(0)))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.LT" + count;
                    string gender = "";
                    if (rbNam.Checked)
                    {
                        gender = rbNam.Text;
                    }
                    if (rbNu.Checked)
                    {
                        gender = rbNu.Text;
                    }
                    dataReader.Close();
                    sql = "delete from nhanvien where manv = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "delete from taikhoan where tendn = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();
                }
            }
            if (string.Compare(phone, tbSdt.Text) != 0 && string.Compare(address, tbAdd.Text) == 0 && string.Compare(money, tbMoney.Text) != 0)
            {
                sql = "update nhanvien set sodt = '" + tbSdt.Text + "', luong = '" + tbMoney.Text + "' where manv = '" + this.id + "' ";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
                if (rbThungan.Checked == true && string.Compare(rbLetan.Text, cv) == 0)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    sql = "select manv from nhanvien where manv like '" + "NV.TN_" + "'";
                    cmd = new SqlCommand(sql, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (count == ConvertString(dataReader.GetString(0)))
                        {
                            count++;
                        }
                    }
                    dataReader.Close();
                    string gender = "";
                    string idbkup = "NV.TN" + count;

                    if (rbNam.Checked)
                    {
                        gender = rbNam.Text;
                    }
                    if (rbNu.Checked)
                    {
                        gender = rbNu.Text;
                    }
                    dataReader.Close();
                    sql = "delete from nhanvien where manv = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "delete from taikhoan where tendn = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();
                }
                if (rbLetan.Checked == true && string.Compare(rbThungan.Text, cv) == 0)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    sql = "select manv from nhanvien where manv like '" + "NV.LT_" + "'";
                    cmd = new SqlCommand(sql, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (count == ConvertString(dataReader.GetString(0)))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.LT" + count;
                    string gender = "";
                    if (rbNam.Checked)
                    {
                        gender = rbNam.Text;
                    }
                    if (rbNu.Checked)
                    {
                        gender = rbNu.Text;
                    }
                    dataReader.Close();
                    sql = "delete from nhanvien where manv = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "delete from taikhoan where tendn = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();
                }
            }
            if (string.Compare(phone, tbSdt.Text) == 0 && string.Compare(address, tbAdd.Text) != 0 && string.Compare(money, tbMoney.Text) != 0)
            {
                sql = "update nhanvien set luong = '" + tbMoney.Text + "', quequan = n'" + tbAdd.Text + "' where manv = '" + this.id + "' ";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
                if (rbThungan.Checked == true && string.Compare(rbLetan.Text, cv) == 0)
                 {
                    SqlDataReader dataReader;
                    int count = 1;
                    sql = "select manv from nhanvien where manv like '" + "NV.TN_" + "'";
                    cmd = new SqlCommand(sql, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                     {
                        if (count == ConvertString(dataReader.GetString(0)))
                        {
                            count++;
                        }
                    }
                    dataReader.Close();
                    string gender = "";
                    string idbkup = "NV.TN" + count;
                    if (rbNam.Checked)
                    {
                        gender = rbNam.Text;
                    }
                    if (rbNu.Checked)
                    {
                        gender = rbNu.Text;
                    }
                    dataReader.Close();
                    sql = "delete from nhanvien where manv = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "delete from taikhoan where tendn = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();
                }
                if (rbLetan.Checked == true && string.Compare(rbThungan.Text, cv) == 0)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    sql = "select manv from nhanvien where manv like '" + "NV.LT_" + "'";
                    cmd = new SqlCommand(sql, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (count == ConvertString(dataReader.GetString(0)))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.LT" + count;
                    string gender = "";
                    if (rbNam.Checked)
                    {
                        gender = rbNam.Text;
                    }
                    if (rbNu.Checked)
                    {
                       gender = rbNu.Text;
                    }
                    dataReader.Close();
                    sql = "delete from nhanvien where manv = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "delete from taikhoan where tendn = '" + id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand = new SqlCommand(sql, cnn);
                    adpter.DeleteCommand.ExecuteNonQuery();

                    sql = "insert into nhanvien values('" + idbkup + "', N'" + tbName.Text + "', '" + dateT.Value.ToString("yyyy-MM-dd") + "', N'" + gender + "', N'" + tbAdd.Text + "', '" + tbSdt.Text + "', '" + tbMoney.Text + "', N'" + rbLetan.Text + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    sql = "insert into taikhoan values('" + idbkup + "','" + dateT.Value.ToString("yyyy-MM-dd") + "')";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.InsertCommand = new SqlCommand(sql, cnn);
                    adpter.InsertCommand.ExecuteNonQuery();
                }
                }
                if (sql.Length > 0)
                {
                    cmd = new SqlCommand();
                    cmd.Dispose();
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cnn.Close();
            }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Output().ShowDialog();
            this.Close();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            ConnectionStringSql.connection(ref cnn);
            cnn.Open();
            SqlCommand cmd;
            string sql = "select * from nhanvien where manv = '" + id + "'";
            cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tbName.Text = (string)reader.GetValue(1);
                dateT.Value = (DateTime)reader.GetValue(2);
                if (string.Compare((string)reader.GetValue(3), "Nam", true) == 0)
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }
                tbAdd.Text = (string)reader.GetValue(4);
                address = tbAdd.Text;
                tbSdt.Text = (string)(reader.GetValue(5));
                phone = tbSdt.Text;
                tbMoney.Text = "" + (double)reader.GetValue(6);
                money = tbMoney.Text;
                if (string.Compare((string)reader.GetValue(7), "Lễ tân", true) == 0)
                {
                    rbLetan.Checked = true;
                    cv = rbLetan.Text;
                }
                else
                {
                    cv = rbThungan.Text;
                    rbThungan.Checked = true;
                }
            }
            reader.Close();
            cmd = new SqlCommand("Select manv from nhanvien", cnn);
            reader = cmd.ExecuteReader();
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
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            countLT.Sort();
            countTN.Sort();
        }
    }
}
