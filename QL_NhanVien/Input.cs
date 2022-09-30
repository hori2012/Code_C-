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
                    if (dtVDs.Rows[i].Cells[0] != null && string.Compare((string)dtVDs.Rows[i].Cells[7].Value, "Lễ tân") == 0)
                    {
                        countlt++;
                    }
                    if (dtVDs.Rows[i].Cells[0] != null && string.Compare((string)dtVDs.Rows[i].Cells[7].Value, "Thu ngân") == 0)
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
            //int i = 1;
            //int j = 1;
            string codeNv = "";
            DataGridViewRow newrow = new DataGridViewRow();
            newrow.CreateCells(dtVDs);
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
            newrow.Cells[0].Value = codeNv;
            
            if(name.Length == 0)
            {
                thongb += "Không được để trống tên!\n";
            }
            else if (NhanVien.eventString(name))
            {
                newrow.Cells[1].Value = name;
            }
            else
            {
                message += "Tên không được chứa ký tự đặt biệt và số !!\n";
            }
            newrow.Cells[2].Value = birth;
            newrow.Cells[3].Value =gender;
            if(add.Length == 0)
            {
                thongb += "Không được để trống địa chỉ!\n";
            }
            else
            {
                newrow.Cells[4].Value = add;
            }
            if(sdt.Length == 0)
            {
                thongb += "Không được để trống số điện thoại!\n";
            }
           else if (NhanVien.KTSDT(sdt))
            {
                newrow.Cells[5].Value = sdt;
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
                newrow.Cells[6].Value =money;
            }
            
            else
            {
                message += "Tiền chỉ được nhập số !!\n";
            }
            newrow.Cells[7].Value = chucvu;
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
            lbThongb.Width = 150;
            lbThongb.Height = 250;
            lbThongb.Text = "Xóa thành công !!";
            lbThongb.BorderStyle = BorderStyle.Fixed3D;
            btXoa.BackColor = Color.White;
            btXoa.ForeColor = Color.DarkBlue;
           
        }

        private void btThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
