using OfficeOpenXml;
using System.Data;
using System.Windows.Forms;

namespace Test_Excel
{
    public partial class Form1 : Form
    {
        private DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Class", typeof(string));
            table.Columns.Add("Date", typeof(string));
            dataGridView1.DataSource = table;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbClass.Text))
            {
                MessageBox.Show("Don't empty !","Note");
            }
            else
            {
                DataRow row = table.NewRow();
                row["Name"] = tbName.Text;
                row[1] =  tbClass.Text;
                row[2] = dateTime.Value.ToString("dd-MM-yyyy");
                table.Rows.Add(row);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 )
            {
                tbName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tbClass.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                try
                {
                    dateTime.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[2].Value;
                }
                catch(Exception ex)
                {
                    dateTime.Value = DateTime.Now;
                    MessageBox.Show("Row is empty !\n(" + ex.Message + ")", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("You want delete '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' ?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if(savefile.ShowDialog() == DialogResult.OK)
            {
                filePath = savefile.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using(ExcelPackage package = new ExcelPackage(filePath))
                {
                    package.Workbook.Worksheets.Add("Hori");
                    ExcelWorksheet worksheets = package.Workbook.Worksheets[0];
                    worksheets.Cells.Style.Font.Size = 11;
                    worksheets.Cells.Style.Font.Name = "Caribli";
                    for(int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        worksheets.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                        worksheets.Cells[1, i + 1].Style.Font.Size = 12;
                        worksheets.Cells[1, i + 1].Style.Fill.SetBackground(Color.LightBlue);
                        worksheets.Cells[1, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheets.Cells[1, i + 1].Style.Font.Bold = true;
                    }
                    for(int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for(int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            worksheets.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                        }
                    }
                    MessageBox.Show("Excel sucessfull !!", "Note");
                    worksheets.Columns.AutoFit();
                    Byte[] bin = package.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}