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
        private string id = "";
        private string phone = "Unknows";
        private string address = "Unknows";
        private string money = "Unknows";
        private string cv = "Unknows";
        public Update(string id)
        {
            InitializeComponent();
            this.id = id;
            SqlConnection cnn;
            string connectionString = @"Data Source = LAPTOP-7ABHDLJ3\SQLEXPRESS; Initial Catalog = QLNhanVien; User ID = CongHao; Password = conghao20";
            cnn = new SqlConnection(connectionString);
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
            cmd.Dispose();
            cnn.Close();
        }
        private void btCapnhat_Click(object sender, EventArgs e)
        {
            SqlConnection cnn;
            string connectionString = @"Data Source = LAPTOP-7ABHDLJ3\SQLEXPRESS; Initial Catalog = QLNhanVien; User ID = CongHao; Password = conghao20";
            cnn = new SqlConnection(connectionString);
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
            if (rbLetan.Checked == false)
            {
                SqlDataReader dataReader;
                int count = 1;
                string sql1 = "select manv from nhanvien";
                cmd = new SqlCommand(sql1, cnn);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader.GetString(0).Contains("NV.TN"))
                    {
                        count++;
                    }
                }
                string idbkup = "NV.TN" + count;
                dataReader.Close();
                sql = "update nhanvien set chucvu = N'" + rbThungan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
            }
            else
            {
                SqlDataReader dataReader;
                int count = 1;
                string sql1 = "select manv from nhanvien";
                cmd = new SqlCommand(sql1, cnn);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader.GetString(0).Contains("NV.LT"))
                    {
                        count++;
                    }
                }
                string idbkup = "NV.LT" + count;
                dataReader.Close();
                sql = "update nhanvien set chucvu = N'" + rbLetan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
            }
            if (string.Compare(phone, tbSdt.Text) != 0 && string.Compare(address, tbAdd.Text) != 0 && string.Compare(money, tbMoney.Text) == 0)
            {
                sql = "update nhanvien set sodt = '" + tbSdt.Text + "', quequan = n'" + tbAdd.Text + "' where manv = '" + this.id + "' ";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
                if (rbLetan.Checked == false)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    string sql1 = "select manv from nhanvien";
                    cmd = new SqlCommand(sql1, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader.GetString(0).Contains("NV.TN"))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.TN" + count;
                    dataReader.Close();
                    sql = "update nhanvien set chucvu = N'" + rbThungan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand.ExecuteNonQuery();
                }
                else
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    string sql1 = "select manv from nhanvien";
                    cmd = new SqlCommand(sql1, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader.GetString(0).Contains("NV.LT"))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.LT" + count;
                    dataReader.Close();
                    sql = "update nhanvien set chucvu = N'" + rbLetan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand.ExecuteNonQuery();
                }
            }
            if (string.Compare(phone, tbSdt.Text) != 0 && string.Compare(address, tbAdd.Text) == 0 && string.Compare(money, tbMoney.Text) != 0)
            {
                sql = "update nhanvien set sodt = '" + tbSdt.Text + "', luong = '" + tbMoney.Text + "' where manv = '" + this.id + "' ";
                cmd = new SqlCommand(sql, cnn);
                adpter.UpdateCommand = new SqlCommand(sql, cnn);
                adpter.UpdateCommand.ExecuteNonQuery();
                if (rbLetan.Checked == false)
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    string sql1 = "select manv from nhanvien";
                    cmd = new SqlCommand(sql1, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader.GetString(0).Contains("NV.TN"))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.TN" + count;
                    dataReader.Close();
                    sql = "update nhanvien set chucvu = N'" + rbThungan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand.ExecuteNonQuery();
                }
                else
                {
                    SqlDataReader dataReader;
                    int count = 1;
                    string sql1 = "select manv from nhanvien";
                    cmd = new SqlCommand(sql1, cnn);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader.GetString(0).Contains("NV.LT"))
                        {
                            count++;
                        }
                    }
                    string idbkup = "NV.LT" + count;
                    dataReader.Close();
                    sql = "update nhanvien set chucvu = N'" + rbLetan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand.ExecuteNonQuery();
                }
                if (string.Compare(phone, tbSdt.Text) == 0 && string.Compare(address, tbAdd.Text) != 0 && string.Compare(money, tbMoney.Text) != 0)
                {
                    sql = "update nhanvien set luong = '" + tbMoney.Text + "', quequan = n'" + tbAdd.Text + "' where manv = '" + this.id + "' ";
                    cmd = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand = new SqlCommand(sql, cnn);
                    adpter.UpdateCommand.ExecuteNonQuery();
                    if (rbLetan.Checked == false)
                    {
                        SqlDataReader dataReader;
                        int count = 1;
                        string sql1 = "select manv from nhanvien";
                        cmd = new SqlCommand(sql1, cnn);
                        dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            if (dataReader.GetString(0).Contains("NV.TN"))
                            {
                                count++;
                            }
                        }
                        string idbkup = "NV.TN" + count;
                        dataReader.Close();
                        sql = "update nhanvien set chucvu = N'" + rbThungan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                        cmd = new SqlCommand(sql, cnn);
                        adpter.UpdateCommand = new SqlCommand(sql, cnn);
                        adpter.UpdateCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlDataReader dataReader;
                        int count = 1;
                        string sql1 = "select manv from nhanvien";
                        cmd = new SqlCommand(sql1, cnn);
                        dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            if (dataReader.GetString(0).Contains("NV.LT"))
                            {
                                count++;
                            }
                        }
                        string idbkup = "NV.LT" + count;
                        dataReader.Close();
                        sql = "update nhanvien set chucvu = N'" + rbLetan.Text + "', manv = '" + idbkup + "' where manv = '" + this.id + "'";
                        cmd = new SqlCommand(sql, cnn);
                        adpter.UpdateCommand = new SqlCommand(sql, cnn);
                        adpter.UpdateCommand.ExecuteNonQuery();
                    }
                }
            }
            if (sql.Length > 0)
            {
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
    }
}
