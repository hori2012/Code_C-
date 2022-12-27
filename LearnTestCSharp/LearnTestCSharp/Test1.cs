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
using System.IO;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace LearnTestCSharp
{
    public partial class Test1 : Form
    {
        private DataTable table = new DataTable();
        private DataTable tableSQl = new DataTable();
        private DataTable tableEmtity = new DataTable();
        public Test1()
        {
            InitializeComponent();
            
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            string notice = "Thank you choice !!";
            if (chBoxCSharp.Checked == true)
            {
                notice += "\nC Sharp";
            }
            if (chBoxCplus.Checked == true)
            {
                notice += "\nC plus plus";
            }
            if (chBoxJava.Checked)
            {
                notice += "\nJava";
            }
            MessageBox.Show(notice, "Note");
        }

        private void btSubColor_Click(object sender, EventArgs e)
        {
            string notice = "You are select ";
            if (rbRed.Checked == true)
            {
                notice += "Red !!";
            }
            if (rbBlue.Checked == true)
            {
                notice += "Blue !!";
            }
            if (rbBlack.Checked == true)
            {
                notice += "Black !!";
            }
            MessageBox.Show(notice , "Note");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                string output = "All day";
               foreach(var item in comboBox1.Items)
                {
                    output = output +  "\n" + item.ToString();
                }
                MessageBox.Show(output, "Note");
            }
            else
            {
                MessageBox.Show(comboBox1.SelectedItem.ToString(), "Note");
            }
        }

        private void btAllday_Click(object sender, EventArgs e)
        {
            string output = "All day:";
            foreach (var item in comboBox1.Items)
            {
                output = output + "\n" + item.ToString();
            }
            MessageBox.Show(output, "Note");
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                string output = "Days select:" ;
                foreach (var item in listBox.SelectedItems)
                {
                    output = output + "\n" + item;
                }
                MessageBox.Show(output, "Note");
            }
            else
            {
                string output = "All day:";
                foreach (var item in listBox.Items)
                {
                    output = output + "\n" + item.ToString();
                }
                MessageBox.Show(output, "Note");
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown.Value.ToString();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            if (tbId.Text.Length != 0 && tbName.Text.Length != 0)
            {
                // ListView
                ListViewItem lvi = listView1.Items.Add(tbId.Text);
                lvi.SubItems.Add(tbName.Text);
                lvi.SubItems.Add("Unknows");

                //DataGridview
               
                DataRow row = table.NewRow();
                row[0] = tbId.Text;
                row[1] = tbName.Text;
                row[2] = "Unknows";
                table.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("Not empty !!", "Note");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.MultiSelect = false;
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    tbId.Text = listView1.SelectedItems[0].SubItems[0].Text;
                    tbName.Text = listView1.SelectedItems[0].SubItems[1].Text;
                }
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listView1.MultiSelect = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                tbId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tbName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            } 
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want " + listView1.SelectedItems[0].SubItems[1].Text + " delete ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " delete ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if(dialog == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            try
            {
                LearnTestCSharp.ConnectionSQl.ConnectionStringSettings(ref cnn);
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Successfull !!");
            cnn.Close();
        }

        private void Test1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("NAME", typeof(string));
            table.Columns.Add("NOTE", typeof(string));
            dataGridView1.DataSource = table;
            SqlConnection cnn = new SqlConnection();
            try
            {
                LearnTestCSharp.ConnectionSQl.ConnectionStringSettings(ref cnn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tableSQl.Columns.Add("Name", typeof(string));
            tableSQl.Columns.Add("Class", typeof(string));
            SqlCommand cmd = new SqlCommand("select * from sinhvien", cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DataRow row = tableSQl.NewRow();
                row[0] = reader.GetString(0).ToString();
                row[1] = reader.GetString(1).ToString();
                tableSQl.Rows.Add(row);
            }
            reader.Close();
            dataGridViewSQL1.DataSource = tableSQl;
            cmd.Dispose();
            cnn.Close();
            tableEmtity.Columns.Add("Name", typeof(string));
            tableEmtity.Columns.Add("Class", typeof(string));
            dataGridViewSQLENtity.DataSource = tableEmtity;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbNameClass.Text) || string.IsNullOrEmpty(tbClass.Text))
            {
                MessageBox.Show("Don't empty !", "Note");
            }
            else
            {
                DataRow row = tableEmtity.NewRow();
                row[0] = tbNameClass.Text;
                row[1] = tbClass.Text;
                tableEmtity.Rows.Add(row);
            }
        }

        private void dataGridViewSQL1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewSQL1.SelectedRows.Count > 0)
            {
                tbNameClass.Text = dataGridViewSQL1.SelectedRows[0].Cells[0].Value.ToString();
                tbClass.Text = dataGridViewSQL1.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void dataGridViewSQL1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want " + dataGridViewSQL1.SelectedRows[0].Cells[0].Value.ToString() + " delete ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (dataGridViewSQL1.SelectedRows.Count > 0)
                {
                    SqlConnection cnn = new SqlConnection();
                    try
                    {
                        LearnTestCSharp.ConnectionSQl.ConnectionStringSettings(ref cnn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    SqlCommand cmd = new SqlCommand("delete from sinhvien where hoten = N'" + dataGridViewSQL1.SelectedRows[0].Cells[0].Value.ToString() + "' and lop = N'" + dataGridViewSQL1.SelectedRows[0].Cells[1].Value.ToString() + "'", cnn);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand("delete from sinhvien where hoten = N'" + dataGridViewSQL1.SelectedRows[0].Cells[0].Value.ToString() + "' and lop = N'" + dataGridViewSQL1.SelectedRows[0].Cells[1].Value.ToString() + "'", cnn);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    cmd.Dispose();
                    cnn.Close();
                    dataGridViewSQL1.Rows.Remove(dataGridViewSQL1.SelectedRows[0]);
                    MessageBox.Show("Detele sucessfull !!", "Note");
                }
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            if(string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Path is not empty !");
                return;
            }
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(filePath))
                {
                    package.Workbook.Worksheets.Add("Hori");
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    worksheet.Cells.Style.Font.Size = 11;
                    worksheet.Cells.Style.Font.Name = "calibri";
                    int colIndex = 1;
                    int rowIndex = 1;
                    for(int i = 0; i < dataGridViewSQL1.Columns.Count; i++)
                    {
                        worksheet.Cells[rowIndex, colIndex].Value = dataGridViewSQL1.Columns[i].HeaderText;
                        worksheet.Cells[rowIndex, colIndex].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[rowIndex, colIndex].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                        worksheet.Cells[rowIndex, colIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        colIndex++;
                    }
                   for(int i = 0; i < dataGridViewSQL1.RowCount; i++)
                    {
                        for(int j = 0; j < dataGridViewSQL1.ColumnCount; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridViewSQL1.Rows[i].Cells[j].Value;
                        }
                    }
                    worksheet.Columns.AutoFit();
                    Byte[] bin = package.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                    MessageBox.Show("Excel Sucessfull !!\n" + filePath, "Note");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Excel !!\n" + ex.Message, "Note");
            }
        }

        private void btEx_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFile.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Error Path !", "Note");
                return;
            }
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(filePath))
                {
                    package.Workbook.Worksheets.Add("Hori");
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    worksheet.Cells.Style.Font.Size = 11;
                    worksheet.Cells.Style.Font.Name = "Calibri";
                    for(int i = 0; i < dataGridViewSQLENtity.ColumnCount; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGridViewSQLENtity.Columns[i].HeaderText;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Style.Fill.SetBackground(Color.LightBlue);
                        worksheet.Cells[1, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                    }
                    for (int i = 0; i < dataGridViewSQLENtity.RowCount; i++)
                    {
                        for(int j = 0; j < dataGridViewSQLENtity.ColumnCount; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridViewSQLENtity.Rows[i].Cells[j].Value;
                        }
                    }
                    worksheet.Columns.AutoFit();
                    Byte[] bin = package.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                    MessageBox.Show("Excel sucessfull !\n" + filePath, "Note");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Excel !!\n" + ex.Message, "Note");
            }
        }

        private void dataGridViewSQLENtity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewSQLENtity.SelectedRows.Count > 0)
            {
                tbNameClass.Text = dataGridViewSQLENtity.SelectedRows[0].Cells[0].Value.ToString();
                tbClass.Text = dataGridViewSQLENtity.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void dataGridViewSQLENtity_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridViewSQLENtity.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("You want delete " + dataGridViewSQLENtity.SelectedRows[0].Cells[0].Value.ToString() + " ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    dataGridViewSQLENtity.Rows.Remove(dataGridViewSQLENtity.SelectedRows[0]);
                }
            }
        }
    }
}
