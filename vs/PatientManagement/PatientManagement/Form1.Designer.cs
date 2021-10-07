
namespace PatientManagement
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datBirthday = new System.Windows.Forms.DateTimePicker();
            this.btnMale = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cheBedWetter = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOefnen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSpeichern = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBeenden = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listPatient = new System.Windows.Forms.ListBox();
            this.btnRmPatient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firstname:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lastname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Birthday";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // datBirthday
            // 
            this.datBirthday.Location = new System.Drawing.Point(161, 152);
            this.datBirthday.Name = "datBirthday";
            this.datBirthday.Size = new System.Drawing.Size(239, 22);
            this.datBirthday.TabIndex = 3;
            // 
            // btnMale
            // 
            this.btnMale.AutoSize = true;
            this.btnMale.Checked = true;
            this.btnMale.Location = new System.Drawing.Point(6, 21);
            this.btnMale.Name = "btnMale";
            this.btnMale.Size = new System.Drawing.Size(59, 21);
            this.btnMale.TabIndex = 5;
            this.btnMale.TabStop = true;
            this.btnMale.Text = "Male";
            this.btnMale.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 21);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // cheBedWetter
            // 
            this.cheBedWetter.AutoSize = true;
            this.cheBedWetter.Location = new System.Drawing.Point(69, 353);
            this.cheBedWetter.Name = "cheBedWetter";
            this.cheBedWetter.Size = new System.Drawing.Size(98, 21);
            this.cheBedWetter.TabIndex = 7;
            this.cheBedWetter.Text = "Bed-wetter";
            this.cheBedWetter.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(432, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 92);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOefnen,
            this.menuSpeichern,
            this.menuBeenden});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "menu";
            // 
            // menuOefnen
            // 
            this.menuOefnen.Name = "menuOefnen";
            this.menuOefnen.Size = new System.Drawing.Size(157, 26);
            this.menuOefnen.Text = "Öffnen";
            this.menuOefnen.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // menuSpeichern
            // 
            this.menuSpeichern.Name = "menuSpeichern";
            this.menuSpeichern.Size = new System.Drawing.Size(157, 26);
            this.menuSpeichern.Text = "Speichern";
            this.menuSpeichern.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // menuBeenden
            // 
            this.menuBeenden.Name = "menuBeenden";
            this.menuBeenden.Size = new System.Drawing.Size(157, 26);
            this.menuBeenden.Text = "Beenden";
            this.menuBeenden.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(179, 36);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(181, 22);
            this.txtFirstName.TabIndex = 12;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(179, 77);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(181, 22);
            this.txtLastName.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMale);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(72, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sex";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // listPatient
            // 
            this.listPatient.FormattingEnabled = true;
            this.listPatient.ItemHeight = 16;
            this.listPatient.Location = new System.Drawing.Point(613, 31);
            this.listPatient.Name = "listPatient";
            this.listPatient.Size = new System.Drawing.Size(236, 180);
            this.listPatient.TabIndex = 15;
            this.listPatient.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // btnRmPatient
            // 
            this.btnRmPatient.Location = new System.Drawing.Point(651, 247);
            this.btnRmPatient.Name = "btnRmPatient";
            this.btnRmPatient.Size = new System.Drawing.Size(169, 23);
            this.btnRmPatient.TabIndex = 16;
            this.btnRmPatient.Text = "Remove Patient";
            this.btnRmPatient.UseVisualStyleBackColor = true;
            this.btnRmPatient.Click += new System.EventHandler(this.btnRmPatient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 450);
            this.Controls.Add(this.btnRmPatient);
            this.Controls.Add(this.listPatient);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cheBedWetter);
            this.Controls.Add(this.datBirthday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datBirthday;
        private System.Windows.Forms.RadioButton btnMale;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox cheBedWetter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOefnen;
        private System.Windows.Forms.ToolStripMenuItem menuSpeichern;
        private System.Windows.Forms.ToolStripMenuItem menuBeenden;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listPatient;
        private System.Windows.Forms.Button btnRmPatient;
    }
}

