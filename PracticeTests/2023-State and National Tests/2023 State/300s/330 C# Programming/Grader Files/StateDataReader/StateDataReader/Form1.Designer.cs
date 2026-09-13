namespace StateDataReader
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
            this.btnReadFile = new System.Windows.Forms.Button();
            this.lstNames = new System.Windows.Forms.ListBox();
            this.lstAtoZ = new System.Windows.Forms.ListBox();
            this.btnAtoZ = new System.Windows.Forms.Button();
            this.btnZtoA = new System.Windows.Forms.Button();
            this.lstZtoA = new System.Windows.Forms.ListBox();
            this.btnLastAtoZ = new System.Windows.Forms.Button();
            this.lstLastName = new System.Windows.Forms.ListBox();
            this.btnWordTotal = new System.Windows.Forms.Button();
            this.lblWordTotal = new System.Windows.Forms.Label();
            this.lblCharTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReadFile
            // 
            this.btnReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadFile.Location = new System.Drawing.Point(31, 10);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(137, 36);
            this.btnReadFile.TabIndex = 0;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // lstNames
            // 
            this.lstNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNames.FormattingEnabled = true;
            this.lstNames.ItemHeight = 18;
            this.lstNames.Location = new System.Drawing.Point(31, 52);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(209, 652);
            this.lstNames.TabIndex = 1;
            // 
            // lstAtoZ
            // 
            this.lstAtoZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAtoZ.FormattingEnabled = true;
            this.lstAtoZ.ItemHeight = 18;
            this.lstAtoZ.Location = new System.Drawing.Point(262, 52);
            this.lstAtoZ.Name = "lstAtoZ";
            this.lstAtoZ.Size = new System.Drawing.Size(196, 652);
            this.lstAtoZ.TabIndex = 1;
            // 
            // btnAtoZ
            // 
            this.btnAtoZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtoZ.Location = new System.Drawing.Point(262, 8);
            this.btnAtoZ.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtoZ.Name = "btnAtoZ";
            this.btnAtoZ.Size = new System.Drawing.Size(81, 36);
            this.btnAtoZ.TabIndex = 2;
            this.btnAtoZ.Text = "A to Z";
            this.btnAtoZ.UseVisualStyleBackColor = true;
            this.btnAtoZ.Click += new System.EventHandler(this.btnAtoZ_Click);
            // 
            // btnZtoA
            // 
            this.btnZtoA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZtoA.Location = new System.Drawing.Point(481, 9);
            this.btnZtoA.Margin = new System.Windows.Forms.Padding(2);
            this.btnZtoA.Name = "btnZtoA";
            this.btnZtoA.Size = new System.Drawing.Size(83, 36);
            this.btnZtoA.TabIndex = 3;
            this.btnZtoA.Text = "Z to A";
            this.btnZtoA.UseVisualStyleBackColor = true;
            this.btnZtoA.Click += new System.EventHandler(this.btnZtoA_Click);
            // 
            // lstZtoA
            // 
            this.lstZtoA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstZtoA.FormattingEnabled = true;
            this.lstZtoA.ItemHeight = 18;
            this.lstZtoA.Location = new System.Drawing.Point(481, 52);
            this.lstZtoA.Name = "lstZtoA";
            this.lstZtoA.Size = new System.Drawing.Size(202, 652);
            this.lstZtoA.TabIndex = 1;
            // 
            // btnLastAtoZ
            // 
            this.btnLastAtoZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastAtoZ.Location = new System.Drawing.Point(707, 9);
            this.btnLastAtoZ.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastAtoZ.Name = "btnLastAtoZ";
            this.btnLastAtoZ.Size = new System.Drawing.Size(140, 35);
            this.btnLastAtoZ.TabIndex = 4;
            this.btnLastAtoZ.Text = "Last Name A-Z";
            this.btnLastAtoZ.UseVisualStyleBackColor = true;
            this.btnLastAtoZ.Click += new System.EventHandler(this.btnLastAtoZ_Click);
            // 
            // lstLastName
            // 
            this.lstLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLastName.FormattingEnabled = true;
            this.lstLastName.ItemHeight = 18;
            this.lstLastName.Location = new System.Drawing.Point(707, 49);
            this.lstLastName.Name = "lstLastName";
            this.lstLastName.Size = new System.Drawing.Size(197, 652);
            this.lstLastName.TabIndex = 1;
            // 
            // btnWordTotal
            // 
            this.btnWordTotal.Enabled = false;
            this.btnWordTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWordTotal.Location = new System.Drawing.Point(950, 50);
            this.btnWordTotal.Name = "btnWordTotal";
            this.btnWordTotal.Size = new System.Drawing.Size(152, 64);
            this.btnWordTotal.TabIndex = 5;
            this.btnWordTotal.Text = "Word/Char Total";
            this.btnWordTotal.UseVisualStyleBackColor = true;
            this.btnWordTotal.Click += new System.EventHandler(this.btnWordTotal_Click);
            // 
            // lblWordTotal
            // 
            this.lblWordTotal.AutoSize = true;
            this.lblWordTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordTotal.Location = new System.Drawing.Point(950, 130);
            this.lblWordTotal.Name = "lblWordTotal";
            this.lblWordTotal.Size = new System.Drawing.Size(74, 25);
            this.lblWordTotal.TabIndex = 6;
            this.lblWordTotal.Text = "Words";
            // 
            // lblCharTotal
            // 
            this.lblCharTotal.AutoSize = true;
            this.lblCharTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharTotal.Location = new System.Drawing.Point(955, 175);
            this.lblCharTotal.Name = "lblCharTotal";
            this.lblCharTotal.Size = new System.Drawing.Size(58, 25);
            this.lblCharTotal.TabIndex = 7;
            this.lblCharTotal.Text = "Char";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 722);
            this.Controls.Add(this.lblCharTotal);
            this.Controls.Add(this.lblWordTotal);
            this.Controls.Add(this.btnWordTotal);
            this.Controls.Add(this.btnLastAtoZ);
            this.Controls.Add(this.btnZtoA);
            this.Controls.Add(this.btnAtoZ);
            this.Controls.Add(this.lstLastName);
            this.Controls.Add(this.lstZtoA);
            this.Controls.Add(this.lstAtoZ);
            this.Controls.Add(this.lstNames);
            this.Controls.Add(this.btnReadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.ListBox lstNames;
        private System.Windows.Forms.ListBox lstAtoZ;
        private System.Windows.Forms.Button btnAtoZ;
        private System.Windows.Forms.Button btnZtoA;
        private System.Windows.Forms.ListBox lstZtoA;
        private System.Windows.Forms.Button btnLastAtoZ;
        private System.Windows.Forms.ListBox lstLastName;
        private System.Windows.Forms.Button btnWordTotal;
        private System.Windows.Forms.Label lblWordTotal;
        private System.Windows.Forms.Label lblCharTotal;
    }
}

