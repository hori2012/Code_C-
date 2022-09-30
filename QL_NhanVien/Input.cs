using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhanVien
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
            grbstt.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            lbThongb.Width = 150;
            lbThongb.Height = 250;
            
            lbThongb.BorderStyle = BorderStyle.Fixed3D;
            btThem.BackColor = Color.White;
            btThem.ForeColor = Color.DarkBlue;
            string message = "";
            string thongb = "";
            string name = tBName.Text;
            string birth = dateT.Value.ToString("D");
            string gender = "";
            int countlt = 1;
            int counttn = 1;
            if(dtVDs.Rows.Count > 0)
            {
                for(int i = 0; i < dtVDs.Rows.Count; i++)
                {
                    if (dtVDs.Rows[i].Cells[0] != null && string.Compare((string)dtVDs.Rows[i].Cells[8].Value, "Lễ tân") == 0)
                    {
                        countlt++;
                    }
                    if (dtVDs.Rows[i].Cells[0] != null && string.Compare((string)dtVDs.Rows[i].Cells[8].Value, "Thu ngân") == 0)
                    {
                        counttn++;
                    }
                }
            }
            if (rBNam.Checked)
            {
                gender = rBNam.Text;
            }
            if (rBNu.Checked)
            {
                gender = rBNu.Text;
            }
            string add = tBAdd.Text;
            string sdt = tBSDT.Text;
            string money = tbMoney.Text;
            string chucvu = "";
            string codeNv = "";
            DataGridViewRow newrow = new DataGridViewRow();
            newrow.CreateCells(dtVDs);
            newrow.Cells[0].Value = dtVDs.Rows.Count;
            if (rbLetan.Checked)
            {
                codeNv = "NV.LT" + countlt;
                chucvu = "Lễ tân";
            }
            if (rbThungan.Checked)
            {
                codeNv = "NV.TN" + counttn;
                chucvu = "Thu ngân";
            }
            newrow.Cells[1].Value = codeNv;
            
            if(name.Length == 0)
            {
                thongb += "Không được để trống tên!\n";
            }
            else if (NhanVien.eventString(name))
            {
                newrow.Cells[2].Value = name;
            }
            else
            {
                message += "Tên không được chứa ký tự đặt biệt và số !!\n";
            }
            newrow.Cells[3].Value = birth;
            newrow.Cells[4].Value =gender;
            if(add.Length == 0)
            {
                thongb += "Không được để trống địa chỉ!\n";
            }
            else
            {
                newrow.Cells[5].Value = add;
            }
            if(sdt.Length == 0)
            {
                thongb += "Không được để trống số điện thoại!\n";
            }
           else if (NhanVien.KTSDT(sdt))
            {
                newrow.Cells[6].Value = sdt;
            }
            else
            {
                message += "Số điện thoại chỉ được nhập số !!\n";
            }
            if (money.Length == 0)
            {
                thongb += "Không được để trống lương cơ bản!\n";
            }
            else if (NhanVien.KTSDT(money))
            {
                newrow.Cells[7].Value =money;
            }
            
            else
            {
                message += "Tiền chỉ được nhập số !!\n";
            }
            newrow.Cells[8].Value = chucvu;
            if(thongb.Length == 0)
            {
                if (message.Length != 0)
                {
                    MessageBox.Show(message + "\n Vui lòng nhập lại");
                }
                else
                {
                    dtVDs.Rows.Add(newrow);
                    lbThongb.Text = "Thêm thành công !!";
                    tBName.Clear();
                    tBAdd.Clear();
                    tBSDT.Clear();
                    tbMoney.Clear();
                }
            }
            else
            {
                lbThongb.Text = "Thêm không thành công !!";
                MessageBox.Show(thongb);
                
            }
            
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            grbstt.Show();
            btXoa.BackColor = Color.White;
            btXoa.ForeColor = Color.DarkBlue;
            
           
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            btThem.BackColor = Color.White;
            btThem.ForeColor = Color.DarkBlue;
            Application.Exit();
        }

        private void btOk_Click(object sender, EventArgs e)

        {
            if(dtVDs.Rows.Count > 0 && numStt.Value < dtVDs.Rows.Count)
            {
                for (int i = 0; i < dtVDs.Rows.Count; i++)
                {
                    if (numStt.Value == i + 1)
                    {
                        dtVDs.Rows.RemoveAt(i);
                    }
                }
            }
            else
            {
                lbThongb.Text = "Xóa không thành công !!";
                MessageBox.Show("Không tồn tại {0} !!\n", numStt.Value.ToString());
                
            }
            if (dtVDs.Rows.Count != 0)
            {
                for (int i = 0; i < dtVDs.Rows.Count; i++)
                {
                    dtVDs.Rows[i].Cells[0].Value = i + 1;
                }
                lbThongb.Text = "Xóa thành công !!";
            }
            lbThongb.Width = 150;
            lbThongb.Height = 250;
            lbThongb.BorderStyle = BorderStyle.Fixed3D;
            grbstt.Hide();
        }
    }
}
