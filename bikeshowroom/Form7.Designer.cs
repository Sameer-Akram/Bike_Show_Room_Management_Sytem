namespace bikeshowroom
{
    partial class empControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(empControl));
            this.empGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hire_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fire_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.firEmpPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.hireEmpPanel = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rehireEmpPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.updateEmpPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel1.SuspendLayout();
            this.firEmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.hireEmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.rehireEmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.updateEmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // empGrid
            // 
            this.empGrid.AllowUserToAddRows = false;
            this.empGrid.AllowUserToDeleteRows = false;
            this.empGrid.AllowUserToResizeRows = false;
            this.empGrid.BackgroundColor = System.Drawing.Color.White;
            this.empGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.empGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.empGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.empGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.empGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NameE,
            this.Password,
            this.Contact,
            this.Address,
            this.Email,
            this.Hire_Date,
            this.Fire_Date,
            this.Status,
            this.Sales});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.empGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.empGrid.EnableHeadersVisualStyles = false;
            this.empGrid.GridColor = System.Drawing.Color.White;
            this.empGrid.Location = new System.Drawing.Point(253, 190);
            this.empGrid.Margin = new System.Windows.Forms.Padding(4);
            this.empGrid.Name = "empGrid";
            this.empGrid.ReadOnly = true;
            this.empGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.empGrid.RowHeadersVisible = false;
            this.empGrid.RowHeadersWidth = 62;
            this.empGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empGrid.Size = new System.Drawing.Size(1193, 446);
            this.empGrid.TabIndex = 52;
            this.empGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.empGrid_CellEnter);
            // 
            // ID
            // 
            this.ID.FillWeight = 94.4287F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 50;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 80;
            // 
            // NameE
            // 
            this.NameE.FillWeight = 112.7276F;
            this.NameE.HeaderText = "Name";
            this.NameE.MinimumWidth = 8;
            this.NameE.Name = "NameE";
            this.NameE.ReadOnly = true;
            this.NameE.Width = 130;
            // 
            // Password
            // 
            this.Password.FillWeight = 110.0673F;
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 8;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 130;
            // 
            // Contact
            // 
            this.Contact.FillWeight = 112.1963F;
            this.Contact.HeaderText = "Contact";
            this.Contact.MinimumWidth = 8;
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            this.Contact.Width = 130;
            // 
            // Address
            // 
            this.Address.FillWeight = 122.6263F;
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 8;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 150;
            // 
            // Email
            // 
            this.Email.FillWeight = 109.7701F;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // Hire_Date
            // 
            this.Hire_Date.FillWeight = 90.75098F;
            this.Hire_Date.HeaderText = "Hire Date";
            this.Hire_Date.MinimumWidth = 8;
            this.Hire_Date.Name = "Hire_Date";
            this.Hire_Date.ReadOnly = true;
            this.Hire_Date.Width = 130;
            // 
            // Fire_Date
            // 
            this.Fire_Date.FillWeight = 90.59508F;
            this.Fire_Date.HeaderText = "Fire Date";
            this.Fire_Date.MinimumWidth = 8;
            this.Fire_Date.Name = "Fire_Date";
            this.Fire_Date.ReadOnly = true;
            this.Fire_Date.Width = 130;
            // 
            // Status
            // 
            this.Status.FillWeight = 82.23215F;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // Sales
            // 
            this.Sales.FillWeight = 74.60538F;
            this.Sales.HeaderText = "Sales";
            this.Sales.MinimumWidth = 8;
            this.Sales.Name = "Sales";
            this.Sales.ReadOnly = true;
            this.Sales.Width = 150;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(269, 124);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(69, 38);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 51;
            this.pictureBox8.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(344, 121);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 46);
            this.label6.TabIndex = 50;
            this.label6.Text = "Employee Records";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.firEmpPanel);
            this.panel1.Controls.Add(this.hireEmpPanel);
            this.panel1.Controls.Add(this.rehireEmpPanel);
            this.panel1.Controls.Add(this.updateEmpPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 635);
            this.panel1.TabIndex = 49;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backBtn.BackgroundImage")));
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Location = new System.Drawing.Point(0, 0);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(264, 130);
            this.backBtn.TabIndex = 36;
            this.backBtn.UseVisualStyleBackColor = false;
         //   this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            this.backBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backBtn_MouseClick);
            this.backBtn.MouseEnter += new System.EventHandler(this.backBtn_MouseEnter);
            this.backBtn.MouseLeave += new System.EventHandler(this.backBtn_MouseLeave);
            // 
            // firEmpPanel
            // 
            this.firEmpPanel.BackColor = System.Drawing.Color.Transparent;
            this.firEmpPanel.Controls.Add(this.label7);
            this.firEmpPanel.Controls.Add(this.pictureBox4);
            this.firEmpPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.firEmpPanel.Location = new System.Drawing.Point(0, 363);
            this.firEmpPanel.Margin = new System.Windows.Forms.Padding(4);
            this.firEmpPanel.Name = "firEmpPanel";
            this.firEmpPanel.Size = new System.Drawing.Size(267, 118);
            this.firEmpPanel.TabIndex = 35;
            this.firEmpPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.firEmpPanel_MouseClick);
            this.firEmpPanel.MouseEnter += new System.EventHandler(this.firEmpPanel_MouseEnter);
            this.firEmpPanel.MouseLeave += new System.EventHandler(this.firEmpPanel_MouseLeave);
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(112, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 48);
            this.label7.TabIndex = 30;
            this.label7.Text = "Fire Employee";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Location = new System.Drawing.Point(4, 11);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(105, 94);
            this.pictureBox4.TabIndex = 29;
            this.pictureBox4.TabStop = false;
            // 
            // hireEmpPanel
            // 
            this.hireEmpPanel.BackColor = System.Drawing.Color.Transparent;
            this.hireEmpPanel.Controls.Add(this.pictureBox6);
            this.hireEmpPanel.Controls.Add(this.label9);
            this.hireEmpPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hireEmpPanel.Location = new System.Drawing.Point(0, 130);
            this.hireEmpPanel.Margin = new System.Windows.Forms.Padding(4);
            this.hireEmpPanel.Name = "hireEmpPanel";
            this.hireEmpPanel.Size = new System.Drawing.Size(267, 118);
            this.hireEmpPanel.TabIndex = 32;
            this.hireEmpPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hireEmpPanel_MouseClick);
            this.hireEmpPanel.MouseEnter += new System.EventHandler(this.hireEmpPanel_MouseEnter);
            this.hireEmpPanel.MouseLeave += new System.EventHandler(this.hireEmpPanel_MouseLeave);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Location = new System.Drawing.Point(7, 10);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(93, 94);
            this.pictureBox6.TabIndex = 29;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(116, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 52);
            this.label9.TabIndex = 30;
            this.label9.Text = "Hire Employee";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rehireEmpPanel
            // 
            this.rehireEmpPanel.BackColor = System.Drawing.Color.Transparent;
            this.rehireEmpPanel.Controls.Add(this.label8);
            this.rehireEmpPanel.Controls.Add(this.pictureBox5);
            this.rehireEmpPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rehireEmpPanel.Location = new System.Drawing.Point(0, 482);
            this.rehireEmpPanel.Margin = new System.Windows.Forms.Padding(4);
            this.rehireEmpPanel.Name = "rehireEmpPanel";
            this.rehireEmpPanel.Size = new System.Drawing.Size(267, 118);
            this.rehireEmpPanel.TabIndex = 34;
            this.rehireEmpPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rehireEmpPanel_MouseClick);
            this.rehireEmpPanel.MouseEnter += new System.EventHandler(this.rehireEmpPanel_MouseEnter);
            this.rehireEmpPanel.MouseLeave += new System.EventHandler(this.rehireEmpPanel_MouseLeave);
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(108, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 68);
            this.label8.TabIndex = 30;
            this.label8.Text = "Rehire Employee";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Location = new System.Drawing.Point(11, 14);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(77, 98);
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // updateEmpPanel
            // 
            this.updateEmpPanel.BackColor = System.Drawing.Color.Transparent;
            this.updateEmpPanel.Controls.Add(this.label5);
            this.updateEmpPanel.Controls.Add(this.pictureBox3);
            this.updateEmpPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateEmpPanel.Location = new System.Drawing.Point(0, 246);
            this.updateEmpPanel.Margin = new System.Windows.Forms.Padding(4);
            this.updateEmpPanel.Name = "updateEmpPanel";
            this.updateEmpPanel.Size = new System.Drawing.Size(267, 118);
            this.updateEmpPanel.TabIndex = 33;
            this.updateEmpPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.updateEmpPanel_MouseClick);
            this.updateEmpPanel.MouseEnter += new System.EventHandler(this.updateEmpPanel_MouseEnter);
            this.updateEmpPanel.MouseLeave += new System.EventHandler(this.updateEmpPanel_MouseLeave);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(112, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 62);
            this.label5.TabIndex = 30;
            this.label5.Text = "Update Information";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Location = new System.Drawing.Point(4, 14);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(99, 87);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(623, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 32);
            this.label3.TabIndex = 48;
            this.label3.Text = "Management System";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(616, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 42);
            this.label4.TabIndex = 46;
            this.label4.Text = "Bike Showroom \r\n";
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.Red;
            this.exitBtn.Location = new System.Drawing.Point(1465, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(61, 50);
            this.exitBtn.TabIndex = 53;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exitBtn_MouseClick);
            this.exitBtn.MouseEnter += new System.EventHandler(this.exitBtn_MouseEnter);
            this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(499, 21);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(121, 73);
            this.pictureBox7.TabIndex = 54;
            this.pictureBox7.TabStop = false;
            // 
            // empControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 635);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.empGrid);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "empControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel1.ResumeLayout(false);
            this.firEmpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.hireEmpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.rehireEmpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.updateEmpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView empGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hire_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fire_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel firEmpPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel hireEmpPanel;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel rehireEmpPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel updateEmpPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}