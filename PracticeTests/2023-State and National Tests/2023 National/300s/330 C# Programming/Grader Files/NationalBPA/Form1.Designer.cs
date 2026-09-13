namespace NationalBPA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_A_Key = new System.Windows.Forms.Label();
            this.lbl_P_Key = new System.Windows.Forms.Label();
            this.lbl_B_Key = new System.Windows.Forms.Label();
            this.pb_Target_A = new System.Windows.Forms.PictureBox();
            this.pb_Target_P = new System.Windows.Forms.PictureBox();
            this.pb_Target_B = new System.Windows.Forms.PictureBox();
            this.cmbLetters = new System.Windows.Forms.ComboBox();
            this.pb_letter_P = new System.Windows.Forms.PictureBox();
            this.pb_letter_B = new System.Windows.Forms.PictureBox();
            this.pb_letter_A = new System.Windows.Forms.PictureBox();
            this.txtStateName = new System.Windows.Forms.TextBox();
            this.lblStateName = new System.Windows.Forms.Label();
            this.lblStateID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstStates = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target_P)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_letter_P)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_letter_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_letter_A)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbl_A_Key);
            this.panel1.Controls.Add(this.lbl_P_Key);
            this.panel1.Controls.Add(this.lbl_B_Key);
            this.panel1.Controls.Add(this.pb_Target_A);
            this.panel1.Controls.Add(this.pb_Target_P);
            this.panel1.Controls.Add(this.pb_Target_B);
            this.panel1.Controls.Add(this.cmbLetters);
            this.panel1.Controls.Add(this.pb_letter_P);
            this.panel1.Controls.Add(this.pb_letter_B);
            this.panel1.Controls.Add(this.pb_letter_A);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 521);
            this.panel1.TabIndex = 0;
            // 
            // lbl_A_Key
            // 
            this.lbl_A_Key.AutoSize = true;
            this.lbl_A_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_A_Key.ForeColor = System.Drawing.Color.Red;
            this.lbl_A_Key.Location = new System.Drawing.Point(489, 312);
            this.lbl_A_Key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_A_Key.Name = "lbl_A_Key";
            this.lbl_A_Key.Size = new System.Drawing.Size(124, 37);
            this.lbl_A_Key.TabIndex = 3;
            this.lbl_A_Key.Text = "FALSE";
            // 
            // lbl_P_Key
            // 
            this.lbl_P_Key.AutoSize = true;
            this.lbl_P_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_P_Key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_P_Key.Location = new System.Drawing.Point(310, 312);
            this.lbl_P_Key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_P_Key.Name = "lbl_P_Key";
            this.lbl_P_Key.Size = new System.Drawing.Size(124, 37);
            this.lbl_P_Key.TabIndex = 3;
            this.lbl_P_Key.Text = "FALSE";
            // 
            // lbl_B_Key
            // 
            this.lbl_B_Key.AutoSize = true;
            this.lbl_B_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_B_Key.ForeColor = System.Drawing.Color.Blue;
            this.lbl_B_Key.Location = new System.Drawing.Point(135, 312);
            this.lbl_B_Key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_B_Key.Name = "lbl_B_Key";
            this.lbl_B_Key.Size = new System.Drawing.Size(124, 37);
            this.lbl_B_Key.TabIndex = 3;
            this.lbl_B_Key.Text = "FALSE";
            // 
            // pb_Target_A
            // 
            this.pb_Target_A.BackColor = System.Drawing.Color.Transparent;
            this.pb_Target_A.Location = new System.Drawing.Point(480, 154);
            this.pb_Target_A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_Target_A.Name = "pb_Target_A";
            this.pb_Target_A.Size = new System.Drawing.Size(150, 154);
            this.pb_Target_A.TabIndex = 2;
            this.pb_Target_A.TabStop = false;
            // 
            // pb_Target_P
            // 
            this.pb_Target_P.BackColor = System.Drawing.Color.Transparent;
            this.pb_Target_P.Location = new System.Drawing.Point(300, 154);
            this.pb_Target_P.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_Target_P.Name = "pb_Target_P";
            this.pb_Target_P.Size = new System.Drawing.Size(150, 154);
            this.pb_Target_P.TabIndex = 2;
            this.pb_Target_P.TabStop = false;
            // 
            // pb_Target_B
            // 
            this.pb_Target_B.BackColor = System.Drawing.Color.Transparent;
            this.pb_Target_B.Location = new System.Drawing.Point(126, 154);
            this.pb_Target_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_Target_B.Name = "pb_Target_B";
            this.pb_Target_B.Size = new System.Drawing.Size(150, 154);
            this.pb_Target_B.TabIndex = 2;
            this.pb_Target_B.TabStop = false;
            // 
            // cmbLetters
            // 
            this.cmbLetters.FormattingEnabled = true;
            this.cmbLetters.Items.AddRange(new object[] {
            "Letter B",
            "Letter P",
            "Letter A"});
            this.cmbLetters.Location = new System.Drawing.Point(336, 29);
            this.cmbLetters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLetters.Name = "cmbLetters";
            this.cmbLetters.Size = new System.Drawing.Size(180, 28);
            this.cmbLetters.TabIndex = 1;
            this.cmbLetters.Text = "Choose A Letter";
            this.cmbLetters.SelectedIndexChanged += new System.EventHandler(this.cmbLetters_SelectedIndexChanged);
            // 
            // pb_letter_P
            // 
            this.pb_letter_P.Image = ((System.Drawing.Image)(resources.GetObject("pb_letter_P.Image")));
            this.pb_letter_P.Location = new System.Drawing.Point(90, 0);
            this.pb_letter_P.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_letter_P.Name = "pb_letter_P";
            this.pb_letter_P.Size = new System.Drawing.Size(60, 62);
            this.pb_letter_P.TabIndex = 0;
            this.pb_letter_P.TabStop = false;
            // 
            // pb_letter_B
            // 
            this.pb_letter_B.Image = ((System.Drawing.Image)(resources.GetObject("pb_letter_B.Image")));
            this.pb_letter_B.Location = new System.Drawing.Point(0, 0);
            this.pb_letter_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_letter_B.Name = "pb_letter_B";
            this.pb_letter_B.Size = new System.Drawing.Size(60, 62);
            this.pb_letter_B.TabIndex = 0;
            this.pb_letter_B.TabStop = false;
            // 
            // pb_letter_A
            // 
            this.pb_letter_A.Image = ((System.Drawing.Image)(resources.GetObject("pb_letter_A.Image")));
            this.pb_letter_A.Location = new System.Drawing.Point(180, 0);
            this.pb_letter_A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_letter_A.Name = "pb_letter_A";
            this.pb_letter_A.Size = new System.Drawing.Size(60, 62);
            this.pb_letter_A.TabIndex = 0;
            this.pb_letter_A.TabStop = false;
            // 
            // txtStateName
            // 
            this.txtStateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStateName.Location = new System.Drawing.Point(26, 600);
            this.txtStateName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStateName.Name = "txtStateName";
            this.txtStateName.Size = new System.Drawing.Size(308, 40);
            this.txtStateName.TabIndex = 1;
            // 
            // lblStateName
            // 
            this.lblStateName.AutoSize = true;
            this.lblStateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateName.Location = new System.Drawing.Point(20, 565);
            this.lblStateName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStateName.Name = "lblStateName";
            this.lblStateName.Size = new System.Drawing.Size(68, 29);
            this.lblStateName.TabIndex = 2;
            this.lblStateName.Text = "State";
            // 
            // lblStateID
            // 
            this.lblStateID.AutoSize = true;
            this.lblStateID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateID.Location = new System.Drawing.Point(24, 649);
            this.lblStateID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStateID.Name = "lblStateID";
            this.lblStateID.Size = new System.Drawing.Size(97, 29);
            this.lblStateID.TabIndex = 4;
            this.lblStateID.Text = "State ID";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(30, 685);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(308, 40);
            this.txtID.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(386, 565);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 35);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(507, 565);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 35);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(628, 565);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 35);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstStates
            // 
            this.lstStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStates.FormattingEnabled = true;
            this.lstStates.ItemHeight = 33;
            this.lstStates.Location = new System.Drawing.Point(386, 609);
            this.lstStates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstStates.Name = "lstStates";
            this.lstStates.Size = new System.Drawing.Size(354, 334);
            this.lstStates.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 1005);
            this.Controls.Add(this.lstStates);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblStateID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblStateName);
            this.Controls.Add(this.txtStateName);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target_P)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Target_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_letter_P)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_letter_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_letter_A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_letter_P;
        private System.Windows.Forms.PictureBox pb_letter_B;
        private System.Windows.Forms.PictureBox pb_letter_A;
        private System.Windows.Forms.ComboBox cmbLetters;
        private System.Windows.Forms.PictureBox pb_Target_A;
        private System.Windows.Forms.PictureBox pb_Target_P;
        private System.Windows.Forms.PictureBox pb_Target_B;
        private System.Windows.Forms.Label lbl_A_Key;
        private System.Windows.Forms.Label lbl_P_Key;
        private System.Windows.Forms.Label lbl_B_Key;
        private System.Windows.Forms.TextBox txtStateName;
        private System.Windows.Forms.Label lblStateName;
        private System.Windows.Forms.Label lblStateID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstStates;
    }
}

