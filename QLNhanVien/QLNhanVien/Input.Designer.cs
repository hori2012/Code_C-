namespace QLNhanVien
{
    partial class Input
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grThongtin = new System.Windows.Forms.GroupBox();
            this.lbNotify = new System.Windows.Forms.Label();
            this.btThoat = new System.Windows.Forms.Button();
            this.btLammoi = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.dateT = new System.Windows.Forms.DateTimePicker();
            this.lbVnd = new System.Windows.Forms.Label();
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.tbSdt = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pnChucvu = new System.Windows.Forms.Panel();
            this.rbThungan = new System.Windows.Forms.RadioButton();
            this.rbLetan = new System.Windows.Forms.RadioButton();
            this.pnGnder = new System.Windows.Forms.Panel();
            this.rbNu = new System.Windows.Forms.RadioButton();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.lbChucvu = new System.Windows.Forms.Label();
            this.lbMoney = new System.Windows.Forms.Label();
            this.lbSdt = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbAdd = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbTile = new System.Windows.Forms.Label();
            this.pnDS = new System.Windows.Forms.Panel();
            this.listVDs = new System.Windows.Forms.ListView();
            this.clMa = new System.Windows.Forms.ColumnHeader();
            this.clName = new System.Windows.Forms.ColumnHeader();
            this.clDate = new System.Windows.Forms.ColumnHeader();
            this.clGender = new System.Windows.Forms.ColumnHeader();
            this.clAdd = new System.Windows.Forms.ColumnHeader();
            this.clSdt = new System.Windows.Forms.ColumnHeader();
            this.clMoney = new System.Windows.Forms.ColumnHeader();
            this.clChucvu = new System.Windows.Forms.ColumnHeader();
            this.lbTileDs = new System.Windows.Forms.Label();
            this.grThongtin.SuspendLayout();
            this.pnChucvu.SuspendLayout();
            this.pnGnder.SuspendLayout();
            this.pnDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // grThongtin
            // 
            this.grThongtin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grThongtin.Controls.Add(this.lbNotify);
            this.grThongtin.Controls.Add(this.btThoat);
            this.grThongtin.Controls.Add(this.btLammoi);
            this.grThongtin.Controls.Add(this.btThem);
            this.grThongtin.Controls.Add(this.btXoa);
            this.grThongtin.Controls.Add(this.dateT);
            this.grThongtin.Controls.Add(this.lbVnd);
            this.grThongtin.Controls.Add(this.tbMoney);
            this.grThongtin.Controls.Add(this.tbAdd);
            this.grThongtin.Controls.Add(this.tbSdt);
            this.grThongtin.Controls.Add(this.tbName);
            this.grThongtin.Controls.Add(this.pnChucvu);
            this.grThongtin.Controls.Add(this.pnGnder);
            this.grThongtin.Controls.Add(this.lbChucvu);
            this.grThongtin.Controls.Add(this.lbMoney);
            this.grThongtin.Controls.Add(this.lbSdt);
            this.grThongtin.Controls.Add(this.lbGender);
            this.grThongtin.Controls.Add(this.lbAdd);
            this.grThongtin.Controls.Add(this.lbDate);
            this.grThongtin.Controls.Add(this.lbName);
            this.grThongtin.Controls.Add(this.lbTile);
            this.grThongtin.Location = new System.Drawing.Point(-2, -3);
            this.grThongtin.Name = "grThongtin";
            this.grThongtin.Size = new System.Drawing.Size(595, 519);
            this.grThongtin.TabIndex = 0;
            this.grThongtin.TabStop = false;
            this.grThongtin.Text = "Thông tin";
            // 
            // lbNotify
            // 
            this.lbNotify.AutoSize = true;
            this.lbNotify.Location = new System.Drawing.Point(253, 339);
            this.lbNotify.Name = "lbNotify";
            this.lbNotify.Size = new System.Drawing.Size(41, 20);
            this.lbNotify.TabIndex = 19;
            this.lbNotify.Text = "        ";
            // 
            // btThoat
            // 
            this.btThoat.AutoSize = true;
            this.btThoat.BackColor = System.Drawing.SystemColors.Control;
            this.btThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThoat.Location = new System.Drawing.Point(461, 429);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(66, 32);
            this.btThoat.TabIndex = 18;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = false;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btLammoi
            // 
            this.btLammoi.AutoSize = true;
            this.btLammoi.BackColor = System.Drawing.SystemColors.Control;
            this.btLammoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLammoi.Location = new System.Drawing.Point(324, 429);
            this.btLammoi.Name = "btLammoi";
            this.btLammoi.Size = new System.Drawing.Size(82, 32);
            this.btLammoi.TabIndex = 17;
            this.btLammoi.Text = "Làm mới";
            this.btLammoi.UseVisualStyleBackColor = false;
            this.btLammoi.Click += new System.EventHandler(this.btLammoi_Click);
            // 
            // btThem
            // 
            this.btThem.AutoSize = true;
            this.btThem.BackColor = System.Drawing.SystemColors.Control;
            this.btThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThem.Location = new System.Drawing.Point(188, 429);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(66, 32);
            this.btThem.TabIndex = 16;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.AutoSize = true;
            this.btXoa.BackColor = System.Drawing.SystemColors.Control;
            this.btXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btXoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btXoa.Location = new System.Drawing.Point(54, 429);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(66, 32);
            this.btXoa.TabIndex = 15;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // dateT
            // 
            this.dateT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateT.CustomFormat = "yyyy-MM-dd";
            this.dateT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateT.Location = new System.Drawing.Point(93, 164);
            this.dateT.Name = "dateT";
            this.dateT.Size = new System.Drawing.Size(170, 27);
            this.dateT.TabIndex = 14;
            // 
            // lbVnd
            // 
            this.lbVnd.AutoSize = true;
            this.lbVnd.Location = new System.Drawing.Point(536, 215);
            this.lbVnd.Name = "lbVnd";
            this.lbVnd.Size = new System.Drawing.Size(40, 20);
            this.lbVnd.TabIndex = 13;
            this.lbVnd.Text = "VND";
            // 
            // tbMoney
            // 
            this.tbMoney.Location = new System.Drawing.Point(381, 212);
            this.tbMoney.MaxLength = 8;
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.Size = new System.Drawing.Size(146, 27);
            this.tbMoney.TabIndex = 12;
            // 
            // tbAdd
            // 
            this.tbAdd.Location = new System.Drawing.Point(93, 212);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(170, 27);
            this.tbAdd.TabIndex = 11;
            // 
            // tbSdt
            // 
            this.tbSdt.Location = new System.Drawing.Point(381, 161);
            this.tbSdt.MaxLength = 10;
            this.tbSdt.Name = "tbSdt";
            this.tbSdt.Size = new System.Drawing.Size(146, 27);
            this.tbSdt.TabIndex = 10;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(93, 116);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(170, 27);
            this.tbName.TabIndex = 9;
            // 
            // pnChucvu
            // 
            this.pnChucvu.Controls.Add(this.rbThungan);
            this.pnChucvu.Controls.Add(this.rbLetan);
            this.pnChucvu.Location = new System.Drawing.Point(93, 259);
            this.pnChucvu.Name = "pnChucvu";
            this.pnChucvu.Size = new System.Drawing.Size(170, 37);
            this.pnChucvu.TabIndex = 8;
            // 
            // rbThungan
            // 
            this.rbThungan.AutoSize = true;
            this.rbThungan.Checked = true;
            this.rbThungan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbThungan.Location = new System.Drawing.Point(79, 3);
            this.rbThungan.Name = "rbThungan";
            this.rbThungan.Size = new System.Drawing.Size(91, 24);
            this.rbThungan.TabIndex = 10;
            this.rbThungan.TabStop = true;
            this.rbThungan.Text = "Thu ngân";
            this.rbThungan.UseVisualStyleBackColor = true;
            // 
            // rbLetan
            // 
            this.rbLetan.AutoSize = true;
            this.rbLetan.Checked = true;
            this.rbLetan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbLetan.Location = new System.Drawing.Point(3, 3);
            this.rbLetan.Name = "rbLetan";
            this.rbLetan.Size = new System.Drawing.Size(70, 24);
            this.rbLetan.TabIndex = 9;
            this.rbLetan.TabStop = true;
            this.rbLetan.Text = "Lễ tân";
            this.rbLetan.UseVisualStyleBackColor = true;
            // 
            // pnGnder
            // 
            this.pnGnder.Controls.Add(this.rbNu);
            this.pnGnder.Controls.Add(this.rbNam);
            this.pnGnder.Location = new System.Drawing.Point(381, 104);
            this.pnGnder.Name = "pnGnder";
            this.pnGnder.Size = new System.Drawing.Size(145, 39);
            this.pnGnder.TabIndex = 7;
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Checked = true;
            this.rbNu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNu.Location = new System.Drawing.Point(71, 10);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new System.Drawing.Size(50, 24);
            this.rbNu.TabIndex = 1;
            this.rbNu.TabStop = true;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Checked = true;
            this.rbNam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNam.Location = new System.Drawing.Point(3, 10);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(62, 24);
            this.rbNam.TabIndex = 0;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // lbChucvu
            // 
            this.lbChucvu.AutoSize = true;
            this.lbChucvu.Location = new System.Drawing.Point(11, 259);
            this.lbChucvu.Name = "lbChucvu";
            this.lbChucvu.Size = new System.Drawing.Size(64, 20);
            this.lbChucvu.TabIndex = 1;
            this.lbChucvu.Text = "Chức vụ:";
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Location = new System.Drawing.Point(275, 212);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(54, 20);
            this.lbMoney.TabIndex = 6;
            this.lbMoney.Text = "Lương:";
            // 
            // lbSdt
            // 
            this.lbSdt.AutoSize = true;
            this.lbSdt.Location = new System.Drawing.Point(275, 164);
            this.lbSdt.Name = "lbSdt";
            this.lbSdt.Size = new System.Drawing.Size(100, 20);
            this.lbSdt.TabIndex = 5;
            this.lbSdt.Text = "Số điện thoại:";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(275, 116);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(68, 20);
            this.lbGender.TabIndex = 4;
            this.lbGender.Text = "Giới tính:";
            // 
            // lbAdd
            // 
            this.lbAdd.AutoSize = true;
            this.lbAdd.Location = new System.Drawing.Point(11, 212);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(58, 20);
            this.lbAdd.TabIndex = 3;
            this.lbAdd.Text = "Địa chỉ:";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(11, 164);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(77, 20);
            this.lbDate.TabIndex = 2;
            this.lbDate.Text = "Ngày sinh:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(11, 116);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(76, 20);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Họ và tên:";
            // 
            // lbTile
            // 
            this.lbTile.AutoSize = true;
            this.lbTile.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTile.Location = new System.Drawing.Point(253, 37);
            this.lbTile.Name = "lbTile";
            this.lbTile.Size = new System.Drawing.Size(114, 25);
            this.lbTile.TabIndex = 0;
            this.lbTile.Text = "NHÂN VIÊN";
            // 
            // pnDS
            // 
            this.pnDS.Controls.Add(this.listVDs);
            this.pnDS.Controls.Add(this.lbTileDs);
            this.pnDS.Location = new System.Drawing.Point(590, 1);
            this.pnDS.Name = "pnDS";
            this.pnDS.Size = new System.Drawing.Size(708, 515);
            this.pnDS.TabIndex = 1;
            // 
            // listVDs
            // 
            this.listVDs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clMa,
            this.clName,
            this.clDate,
            this.clGender,
            this.clAdd,
            this.clSdt,
            this.clMoney,
            this.clChucvu});
            this.listVDs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listVDs.FullRowSelect = true;
            this.listVDs.GridLines = true;
            this.listVDs.Location = new System.Drawing.Point(3, 52);
            this.listVDs.Name = "listVDs";
            this.listVDs.Size = new System.Drawing.Size(705, 435);
            this.listVDs.TabIndex = 1;
            this.listVDs.UseCompatibleStateImageBehavior = false;
            this.listVDs.View = System.Windows.Forms.View.Details;
            // 
            // clMa
            // 
            this.clMa.Text = "Mã nhân viên";
            this.clMa.Width = 100;
            // 
            // clName
            // 
            this.clName.Text = "Họ tên";
            this.clName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clName.Width = 150;
            // 
            // clDate
            // 
            this.clDate.Text = "Ngày sinh";
            this.clDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clDate.Width = 100;
            // 
            // clGender
            // 
            this.clGender.Text = "Giới tính";
            this.clGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clGender.Width = 100;
            // 
            // clAdd
            // 
            this.clAdd.Text = "Địa chỉ";
            this.clAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clAdd.Width = 150;
            // 
            // clSdt
            // 
            this.clSdt.Text = "Liên lạc";
            this.clSdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clSdt.Width = 150;
            // 
            // clMoney
            // 
            this.clMoney.Text = "Lương";
            this.clMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clMoney.Width = 150;
            // 
            // clChucvu
            // 
            this.clChucvu.Text = "Chức vụ";
            this.clChucvu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clChucvu.Width = 100;
            // 
            // lbTileDs
            // 
            this.lbTileDs.AutoSize = true;
            this.lbTileDs.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTileDs.Location = new System.Drawing.Point(328, 17);
            this.lbTileDs.Name = "lbTileDs";
            this.lbTileDs.Size = new System.Drawing.Size(173, 23);
            this.lbTileDs.TabIndex = 0;
            this.lbTileDs.Text = "Danh sách nhân viên";
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1299, 515);
            this.Controls.Add(this.pnDS);
            this.Controls.Add(this.grThongtin);
            this.Name = "Input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên";
            this.Load += new System.EventHandler(this.Input_Load);
            this.grThongtin.ResumeLayout(false);
            this.grThongtin.PerformLayout();
            this.pnChucvu.ResumeLayout(false);
            this.pnChucvu.PerformLayout();
            this.pnGnder.ResumeLayout(false);
            this.pnGnder.PerformLayout();
            this.pnDS.ResumeLayout(false);
            this.pnDS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grThongtin;
        private Label lbChucvu;
        private Label lbMoney;
        private Label lbSdt;
        private Label lbGender;
        private Label lbAdd;
        private Label lbDate;
        private Label lbName;
        private Label lbTile;
        private Panel pnChucvu;
        private RadioButton rbThungan;
        private RadioButton rbLetan;
        private Panel pnGnder;
        private RadioButton rbNu;
        private RadioButton rbNam;
        private DateTimePicker dateT;
        private Label lbVnd;
        private TextBox tbMoney;
        private TextBox tbAdd;
        private TextBox tbSdt;
        private TextBox tbName;
        private Button btThoat;
        private Button btLammoi;
        private Button btThem;
        private Button btXoa;
        private Panel pnDS;
        private ListView listVDs;
        private ColumnHeader clMa;
        private ColumnHeader clName;
        private ColumnHeader clDate;
        private ColumnHeader clGender;
        private ColumnHeader clAdd;
        private ColumnHeader clSdt;
        private ColumnHeader clMoney;
        private ColumnHeader clChucvu;
        private Label lbTileDs;
        private Label lbNotify;
    }
}