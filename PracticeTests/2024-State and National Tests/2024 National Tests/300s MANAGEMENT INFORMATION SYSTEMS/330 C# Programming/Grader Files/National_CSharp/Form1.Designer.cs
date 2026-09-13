namespace SanGabrielChasmaMining
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
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblMineralCode = new System.Windows.Forms.Label();
            this.txtMineralCode = new System.Windows.Forms.TextBox();
            this.lblTonQA = new System.Windows.Forms.Label();
            this.txtTonQA = new System.Windows.Forms.TextBox();
            this.lblTotalCounts = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            this.lblEstimatedValue = new System.Windows.Forms.Label();
            this.lblRetypeCommand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(34, 83);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(76, 26);
            this.txtCommand.TabIndex = 1;
            this.txtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommand_KeyPress);
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting.Location = new System.Drawing.Point(28, 24);
            this.lblGreeting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(86, 20);
            this.lblGreeting.TabIndex = 2;
            this.lblGreeting.Text = "lblGreeting";
            // 
            // lblMineralCode
            // 
            this.lblMineralCode.AutoSize = true;
            this.lblMineralCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMineralCode.Location = new System.Drawing.Point(28, 120);
            this.lblMineralCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMineralCode.Name = "lblMineralCode";
            this.lblMineralCode.Size = new System.Drawing.Size(113, 20);
            this.lblMineralCode.TabIndex = 3;
            this.lblMineralCode.Text = "lblMineralCode";
            this.lblMineralCode.Visible = false;
            // 
            // txtMineralCode
            // 
            this.txtMineralCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMineralCode.Location = new System.Drawing.Point(34, 159);
            this.txtMineralCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMineralCode.Name = "txtMineralCode";
            this.txtMineralCode.Size = new System.Drawing.Size(76, 26);
            this.txtMineralCode.TabIndex = 4;
            this.txtMineralCode.Visible = false;
            this.txtMineralCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSymbol_KeyPress);
            // 
            // lblTonQA
            // 
            this.lblTonQA.AutoSize = true;
            this.lblTonQA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTonQA.Location = new System.Drawing.Point(31, 200);
            this.lblTonQA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTonQA.Name = "lblTonQA";
            this.lblTonQA.Size = new System.Drawing.Size(74, 20);
            this.lblTonQA.TabIndex = 5;
            this.lblTonQA.Text = "lblTonQA";
            this.lblTonQA.Visible = false;
            // 
            // txtTonQA
            // 
            this.txtTonQA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTonQA.Location = new System.Drawing.Point(34, 235);
            this.txtTonQA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTonQA.Name = "txtTonQA";
            this.txtTonQA.Size = new System.Drawing.Size(76, 26);
            this.txtTonQA.TabIndex = 6;
            this.txtTonQA.Visible = false;
            this.txtTonQA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTonnage_KeyPress);
            // 
            // lblTotalCounts
            // 
            this.lblTotalCounts.AutoSize = true;
            this.lblTotalCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCounts.Location = new System.Drawing.Point(23, 17);
            this.lblTotalCounts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCounts.Name = "lblTotalCounts";
            this.lblTotalCounts.Size = new System.Drawing.Size(110, 20);
            this.lblTotalCounts.TabIndex = 7;
            this.lblTotalCounts.Text = "lblTotalCounts";
            this.lblTotalCounts.Visible = false;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.Location = new System.Drawing.Point(23, 109);
            this.lblList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(49, 20);
            this.lblList.TabIndex = 8;
            this.lblList.Text = "lblList";
            this.lblList.Visible = false;
            // 
            // lblEstimatedValue
            // 
            this.lblEstimatedValue.AutoSize = true;
            this.lblEstimatedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedValue.Location = new System.Drawing.Point(23, 60);
            this.lblEstimatedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstimatedValue.Name = "lblEstimatedValue";
            this.lblEstimatedValue.Size = new System.Drawing.Size(137, 20);
            this.lblEstimatedValue.TabIndex = 9;
            this.lblEstimatedValue.Text = "lblEstimatedValue";
            this.lblEstimatedValue.Visible = false;
            // 
            // lblRetypeCommand
            // 
            this.lblRetypeCommand.AutoSize = true;
            this.lblRetypeCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetypeCommand.Location = new System.Drawing.Point(28, 52);
            this.lblRetypeCommand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetypeCommand.Name = "lblRetypeCommand";
            this.lblRetypeCommand.Size = new System.Drawing.Size(148, 20);
            this.lblRetypeCommand.TabIndex = 10;
            this.lblRetypeCommand.Text = "lblRetypeCommand";
            this.lblRetypeCommand.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(933, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 12;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(933, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 13;
            this.label2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblEstimatedValue);
            this.panel1.Controls.Add(this.lblList);
            this.panel1.Controls.Add(this.lblTotalCounts);
            this.panel1.Location = new System.Drawing.Point(8, 337);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 337);
            this.panel1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 690);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRetypeCommand);
            this.Controls.Add(this.txtTonQA);
            this.Controls.Add(this.lblTonQA);
            this.Controls.Add(this.txtMineralCode);
            this.Controls.Add(this.lblMineralCode);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.txtCommand);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "SGCM Order Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtCommand;
        public System.Windows.Forms.Label lblGreeting;
        public System.Windows.Forms.Label lblMineralCode;
        public System.Windows.Forms.TextBox txtMineralCode;
        public System.Windows.Forms.Label lblTonQA;
        public System.Windows.Forms.TextBox txtTonQA;
        public System.Windows.Forms.Label lblTotalCounts;
        public System.Windows.Forms.Label lblList;
        public System.Windows.Forms.Label lblEstimatedValue;
        public System.Windows.Forms.Label lblRetypeCommand;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        //private System.Windows.Forms.Label lblCHK;
    }
}

