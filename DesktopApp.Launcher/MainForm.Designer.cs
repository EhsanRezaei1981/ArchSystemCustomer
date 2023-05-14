namespace DesktopApp.Launcher
{
    partial class MainForm
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
            groupBox1 = new GroupBox();
            lblLastUpdateDateTime = new Label();
            _lblLastUpdateDateTime = new Label();
            lblCustomerId = new Label();
            _lblCustomerId = new Label();
            btnExport = new Button();
            btnSave = new Button();
            label6 = new Label();
            txtCountry = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            label3 = new Label();
            txtTel = new TextBox();
            txtIdNumber = new TextBox();
            label2 = new Label();
            txtSurname = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            dataGridViewCustomer = new DataGridView();
            dgwCustomerId = new DataGridViewTextBoxColumn();
            dgwName = new DataGridViewTextBoxColumn();
            dgwSurname = new DataGridViewTextBoxColumn();
            dgwIDNumber = new DataGridViewTextBoxColumn();
            dgwTel = new DataGridViewTextBoxColumn();
            dgwEmail = new DataGridViewTextBoxColumn();
            dgwCountry = new DataGridViewTextBoxColumn();
            dgwCreationDateTime = new DataGridViewTextBoxColumn();
            dgwLastUpdateDateTime = new DataGridViewTextBoxColumn();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomer).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblLastUpdateDateTime);
            groupBox1.Controls.Add(_lblLastUpdateDateTime);
            groupBox1.Controls.Add(lblCustomerId);
            groupBox1.Controls.Add(_lblCustomerId);
            groupBox1.Controls.Add(btnExport);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtCountry);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTel);
            groupBox1.Controls.Add(txtIdNumber);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtSurname);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtName);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1102, 162);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add / Modify Customer";
            // 
            // lblLastUpdateDateTime
            // 
            lblLastUpdateDateTime.AutoSize = true;
            lblLastUpdateDateTime.Location = new Point(742, 137);
            lblLastUpdateDateTime.Name = "lblLastUpdateDateTime";
            lblLastUpdateDateTime.Size = new Size(13, 15);
            lblLastUpdateDateTime.TabIndex = 14;
            lblLastUpdateDateTime.Text = "0";
            lblLastUpdateDateTime.Visible = false;
            // 
            // _lblLastUpdateDateTime
            // 
            _lblLastUpdateDateTime.AutoSize = true;
            _lblLastUpdateDateTime.Location = new Point(642, 137);
            _lblLastUpdateDateTime.Name = "_lblLastUpdateDateTime";
            _lblLastUpdateDateTime.Size = new Size(102, 15);
            _lblLastUpdateDateTime.TabIndex = 13;
            _lblLastUpdateDateTime.Text = "Last Update Date: ";
            _lblLastUpdateDateTime.Visible = false;
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(717, 120);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(13, 15);
            lblCustomerId.TabIndex = 12;
            lblCustomerId.Text = "0";
            lblCustomerId.Visible = false;
            // 
            // _lblCustomerId
            // 
            _lblCustomerId.AutoSize = true;
            _lblCustomerId.Location = new Point(642, 120);
            _lblCustomerId.Name = "_lblCustomerId";
            _lblCustomerId.Size = new Size(75, 15);
            _lblCustomerId.TabIndex = 11;
            _lblCustomerId.Text = "Customer Id:";
            _lblCustomerId.Visible = false;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(883, 94);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(134, 23);
            btnExport.TabIndex = 8;
            btnExport.Text = "Export To XML";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(635, 94);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(242, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(383, 97);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 9;
            label6.Text = "Country: ";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(444, 94);
            txtCountry.MaxLength = 20;
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(185, 23);
            txtCountry.TabIndex = 6;
            txtCountry.Text = "South Africa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(383, 39);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 7;
            label4.Text = "Email: ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(444, 36);
            txtEmail.MaxLength = 128;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(433, 23);
            txtEmail.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 68);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 5;
            label5.Text = "Tel: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 94);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 5;
            label3.Text = "ID. No:";
            // 
            // txtTel
            // 
            txtTel.Location = new Point(444, 65);
            txtTel.MaxLength = 20;
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(185, 23);
            txtTel.TabIndex = 5;
            // 
            // txtIdNumber
            // 
            txtIdNumber.Location = new Point(76, 91);
            txtIdNumber.MaxLength = 20;
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(185, 23);
            txtIdNumber.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Surname: ";
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(76, 62);
            txtSurname.MaxLength = 50;
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(185, 23);
            txtSurname.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Name: ";
            // 
            // txtName
            // 
            txtName.Location = new Point(76, 33);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(185, 23);
            txtName.TabIndex = 0;
            // 
            // dataGridViewCustomer
            // 
            dataGridViewCustomer.AllowUserToAddRows = false;
            dataGridViewCustomer.AllowUserToDeleteRows = false;
            dataGridViewCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomer.Columns.AddRange(new DataGridViewColumn[] { dgwCustomerId, dgwName, dgwSurname, dgwIDNumber, dgwTel, dgwEmail, dgwCountry, dgwCreationDateTime, dgwLastUpdateDateTime });
            dataGridViewCustomer.Dock = DockStyle.Fill;
            dataGridViewCustomer.Location = new Point(0, 162);
            dataGridViewCustomer.Name = "dataGridViewCustomer";
            dataGridViewCustomer.RowTemplate.Height = 25;
            dataGridViewCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustomer.Size = new Size(1102, 378);
            dataGridViewCustomer.TabIndex = 9;
            dataGridViewCustomer.RowStateChanged += dataGridViewCustomer_RowStateChanged;
            dataGridViewCustomer.KeyUp += dataGridViewCustomer_KeyUp;
            // 
            // dgwCustomerId
            // 
            dgwCustomerId.DataPropertyName = "CustomerId";
            dgwCustomerId.Frozen = true;
            dgwCustomerId.HeaderText = "CustomerId";
            dgwCustomerId.Name = "dgwCustomerId";
            dgwCustomerId.ReadOnly = true;
            // 
            // dgwName
            // 
            dgwName.DataPropertyName = "Name";
            dgwName.Frozen = true;
            dgwName.HeaderText = "Name";
            dgwName.Name = "dgwName";
            dgwName.ReadOnly = true;
            dgwName.Width = 132;
            // 
            // dgwSurname
            // 
            dgwSurname.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgwSurname.DataPropertyName = "Surname";
            dgwSurname.Frozen = true;
            dgwSurname.HeaderText = "Surname";
            dgwSurname.Name = "dgwSurname";
            dgwSurname.ReadOnly = true;
            dgwSurname.Width = 131;
            // 
            // dgwIDNumber
            // 
            dgwIDNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgwIDNumber.DataPropertyName = "IDNumber";
            dgwIDNumber.Frozen = true;
            dgwIDNumber.HeaderText = "IDNumber";
            dgwIDNumber.Name = "dgwIDNumber";
            dgwIDNumber.ReadOnly = true;
            dgwIDNumber.Width = 132;
            // 
            // dgwTel
            // 
            dgwTel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgwTel.DataPropertyName = "Tel";
            dgwTel.Frozen = true;
            dgwTel.HeaderText = "Tel";
            dgwTel.Name = "dgwTel";
            dgwTel.ReadOnly = true;
            dgwTel.Width = 132;
            // 
            // dgwEmail
            // 
            dgwEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgwEmail.DataPropertyName = "Email";
            dgwEmail.HeaderText = "Email";
            dgwEmail.Name = "dgwEmail";
            dgwEmail.ReadOnly = true;
            // 
            // dgwCountry
            // 
            dgwCountry.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgwCountry.DataPropertyName = "Country";
            dgwCountry.HeaderText = "Country";
            dgwCountry.Name = "dgwCountry";
            dgwCountry.ReadOnly = true;
            // 
            // dgwCreationDateTime
            // 
            dgwCreationDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgwCreationDateTime.DataPropertyName = "CreationDateTime";
            dgwCreationDateTime.HeaderText = "Creation Date";
            dgwCreationDateTime.Name = "dgwCreationDateTime";
            dgwCreationDateTime.ReadOnly = true;
            dgwCreationDateTime.Width = 120;
            // 
            // dgwLastUpdateDateTime
            // 
            dgwLastUpdateDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgwLastUpdateDateTime.DataPropertyName = "LastUpdateDateTime";
            dgwLastUpdateDateTime.HeaderText = "Last Update Date";
            dgwLastUpdateDateTime.Name = "dgwLastUpdateDateTime";
            dgwLastUpdateDateTime.ReadOnly = true;
            dgwLastUpdateDateTime.Width = 120;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1102, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(362, 17);
            toolStripStatusLabel1.Text = "F2: Modify | Delete: Delete | Escape: cancel modify | F6: Refresh data";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 540);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridViewCustomer);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Customer";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomer).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtSurname;
        private Label label1;
        private TextBox txtName;
        private Label label3;
        private TextBox txtIdNumber;
        private Label label6;
        private TextBox txtCountry;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtTel;
        private Button btnSave;
        private Button btnExport;
        private DataGridView dataGridViewCustomer;
        private DataGridViewTextBoxColumn dgwCustomerId;
        private DataGridViewTextBoxColumn dgwName;
        private DataGridViewTextBoxColumn dgwSurname;
        private DataGridViewTextBoxColumn dgwIDNumber;
        private DataGridViewTextBoxColumn dgwTel;
        private DataGridViewTextBoxColumn dgwEmail;
        private DataGridViewTextBoxColumn dgwCountry;
        private DataGridViewTextBoxColumn dgwCreationDateTime;
        private DataGridViewTextBoxColumn dgwLastUpdateDateTime;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label lblCustomerId;
        private Label _lblCustomerId;
        private Label lblLastUpdateDateTime;
        private Label _lblLastUpdateDateTime;
    }
}